using InvestingManagerApp.Models;
using InvestingManagerApp.Services;
using InvestingManagerApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace InvestingManagerApp.ViewModels
{
    class CreateTransactionPageViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;

        private ObservableCollection<Portfolio> _portfolios;
        private ObservableCollection<Security> _securities;
        private ObservableCollection<TransactionType> _transactionTypes;

        private Portfolio? _selectedPortfolio;
        private Security? _selectedSecurity;
        private TransactionType _selectedTransactionType;
        private string _pricePerUnitText;
        private string _amountText;
        private DateTime? _selectedDate;
        private string _selectedTime = "";
        private string _errorMessage = "";


        public ObservableCollection<Portfolio> Portfolios 
        {
            get => _portfolios;
            set 
            {
                _portfolios = value;
                OnPropertyChanged(nameof(Portfolios));
            } 
        }
        public ObservableCollection<Security> Securities { 
            get => _securities; 
            set
            {
                _securities = value;
                OnPropertyChanged(nameof(Securities));
            }
        }
        public ObservableCollection<TransactionType> TransactionTypes
        {
            get => _transactionTypes;
            set
            {
                _transactionTypes = value;
                OnPropertyChanged(nameof(TransactionTypes));
            }
        }
        public Portfolio? SelectedPortfolio
        {
            get => _selectedPortfolio;
            set
            {
                _selectedPortfolio = value;
                OnPropertyChanged(nameof(SelectedPortfolio));
            }
        }

        public Security? SelectedSecurity
        {
            get => _selectedSecurity;
            set
            {
                _selectedSecurity = value;
                OnPropertyChanged(nameof(SelectedSecurity));
            }
        }

        public TransactionType SelectedTransactionType
        {
            get => _selectedTransactionType;
            set
            {
                _selectedTransactionType = value;
                OnPropertyChanged(nameof(SelectedTransactionType));
            }
        }

        public string PricePerUnitText
        {
            get => _pricePerUnitText;
            set
            {
                _pricePerUnitText = value;
                OnPropertyChanged(nameof(PricePerUnitText));
            }
        }
        public string AmountText
        {
            get => _amountText;
            set
            {
                _amountText = value;
                OnPropertyChanged(nameof(AmountText));
            }
        }

        public DateTime? SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            }
        }

        public string SelectedTime
        {
            get => _selectedTime;
            set
            {
                _selectedTime = value;
                OnPropertyChanged(nameof(SelectedTime));
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

        public ICommand SaveTransactionCommand { get; }
        public ICommand NavigateToMainCommand { get; }

        public CreateTransactionPageViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            var portfoliosList = _mainViewModel.PortfolioService.GetPortfoliosByPersonId(_mainViewModel.PersonSession.CurrentPerson.Id);
            Portfolios = new ObservableCollection<Portfolio>(portfoliosList);
            var securityList = _mainViewModel.SecurityService.GetSecurities();
            Securities = new ObservableCollection<Security>(securityList);
            TransactionTypes = new ObservableCollection<TransactionType>(
                Enum.GetValues(typeof(TransactionType)).Cast<TransactionType>());

            SelectedDate = DateTime.Today;
            SelectedTime = "12:00";

            SaveTransactionCommand = new RelayCommand(SaveTransaction);
            NavigateToMainCommand = new RelayCommand(NavigateToMain);
        }
        public CreateTransactionPageViewModel(MainViewModel mainViewModel, int portfolioId) : this(mainViewModel)
        {

        }

        public void SaveTransaction()
        {
            if (SelectedPortfolio == null || SelectedSecurity == null || SelectedDate == null)
            {
                ErrorMessage = "Заполните обязательные поля";
                return;
            }

            if (!TimeSpan.TryParse(SelectedTime, out var time))
            {
                ErrorMessage = "Неверный формат времени";
                return;
            }
            if (!int.TryParse(AmountText, out var amount))
            {
                ErrorMessage = "Неверное количество";
                return;
            }
            if (!decimal.TryParse(PricePerUnitText, out var pricePerUnit))
            {
                ErrorMessage = "Неверная цена";
                return;
            }
            if (amount <= 0 || pricePerUnit <= 0)
            {
                ErrorMessage = "Количество и цена должны быть больше нуля";
                return;
            }

            var transactionDateTime = SelectedDate.Value.Date + time;

            var transaction = new Transaction
            {
                PortfolioId = SelectedPortfolio.Id,
                SecurityId = SelectedSecurity.Id,
                Type = SelectedTransactionType,
                Amount = amount,
                PricePerUnit = pricePerUnit,
                Date = transactionDateTime
            };

            _mainViewModel.TransactionService.AddTransaction(transaction);
            NavigateToMain();
        }

        public void NavigateToMain()
        {
            var mainPageViewModel = new MainPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new MainPage { DataContext = mainPageViewModel });
        }


    }
}
