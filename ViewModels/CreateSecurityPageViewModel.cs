using InvestingManagerApp.Models;
using InvestingManagerApp.Services;
using InvestingManagerApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InvestingManagerApp.ViewModels
{
    class CreateSecurityPageViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;
        private readonly Security EditingSecurity;
        private string _name;
        private string _ticker;
        private string _company;
        private SecurityType _securityType;
        private ObservableCollection<SecurityType> _securityTypes;
        private string _currentPriceText;
        private string _errorMessage;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Ticker
        {
            get => _ticker;
            set
            {
                _ticker = value;
                OnPropertyChanged(nameof(Ticker));
            }
        }

        public string Company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged(nameof(Company));
            }
        }

        public SecurityType TheSecurityType
        {
            get => _securityType;
            set
            {
                _securityType = value;
                OnPropertyChanged(nameof(TheSecurityType));
            }
        }

        public ObservableCollection<SecurityType> SecurityTypes
        {
            get => _securityTypes;
            set
            {
                _securityTypes = value;
                OnPropertyChanged(nameof(SecurityTypes));
            }
        }

        public string CurrentPriceText
        {
            get => _currentPriceText;
            set
            {
                _currentPriceText = value;
                OnPropertyChanged(nameof(CurrentPriceText));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand SaveSecurityCommand { get; }
        public ICommand CancelCommand { get; }
        public CreateSecurityPageViewModel(MainViewModel mainViewModel) 
        {
            _mainViewModel = mainViewModel;

            SaveSecurityCommand = new RelayCommand(SaveSecurity);
            CancelCommand = new RelayCommand(NavigateToAdminSecurities);

            SecurityTypes = new ObservableCollection<SecurityType>(
                Enum.GetValues(typeof(SecurityType)).Cast<SecurityType>());
        }

        public CreateSecurityPageViewModel(MainViewModel mainViewModel, int securityId) : this(mainViewModel)
        {
            EditingSecurity = mainViewModel.SecurityService.GetSecurityById(securityId);

            Name = EditingSecurity.Name;
            Ticker = EditingSecurity.Ticker;
            Company = EditingSecurity.Company;
            TheSecurityType = EditingSecurity.Type;
            CurrentPriceText = EditingSecurity.CurrentPrice.ToString();
        }

        public void SaveSecurity()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Ticker) || string.IsNullOrWhiteSpace(Company)) 
            {
                ErrorMessage = "Заполните обязательные поля";
                return;
            }

            if (!decimal.TryParse(CurrentPriceText, out var currentPrice))
            {
                ErrorMessage = "Некорректная цена";
                return;
            }
            if (currentPrice <= 0)
            {
                ErrorMessage = "Цена должна быть больше нуля";
                return;
            }

            var newSecurity = new Security(Ticker, Name, Company, TheSecurityType, currentPrice);

            if (EditingSecurity != null) 
            { 
                newSecurity.Id = EditingSecurity.Id;
                _mainViewModel.SecurityService.EditSecurity(newSecurity);
                NavigateToAdminSecurities();
                return;
            }
            _mainViewModel.SecurityService.AddSecurity(newSecurity);
            NavigateToAdminSecurities();

        }

        public void NavigateToAdminSecurities()
        {
            var adminSecurityPageViewModel = new AdminSecurityPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new AdminSecurityPage { DataContext = adminSecurityPageViewModel });
        }
    }
}
