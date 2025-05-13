using InvestingManagerApp.Models;
using System.Collections.Generic;
using InvestingManagerApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InvestingManagerApp.ViewModels
{
    public class AdminPageViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;
        public Security? EditingSecurity {  get; set; }
        public string EditedPriceText {  get; set; }


        private string _newTicker;
        public string NewTicker
        {
            get { return _newTicker; }
            set
            {
                _newTicker = value;
                OnPropertyChanged(nameof(NewTicker));
            }
        }
        private string _newCompany;
        public string NewCompany
        {
            get { return _newCompany; }
            set
            {
                _newCompany = value;
                OnPropertyChanged(nameof(NewCompany));
            }
        }
        private string _newName;
        public string NewName
        {
            get { return _newName; }
            set
            {
                _newName = value;
                OnPropertyChanged(nameof(NewName));
            }
        }
        private string _typeOfNewSecurityText;
        public string TypeOfNewSecurityText
        {
            get { return _typeOfNewSecurityText; }
            set
            {
                _typeOfNewSecurityText = value;
                OnPropertyChanged(nameof(TypeOfNewSecurityText));

                if (value == "Акция")
                    _newSecurityType = SecurityType.Stock;
                if (value == "Фонд")
                    _newSecurityType = SecurityType.Fund;
                if (value == "Облигация")
                    _newSecurityType = SecurityType.Bond;
            }
        }

        public SecurityType _newSecurityType { get; set; }

        private string _newCurrentPriceText;
        public string CurrentPriceText
        {
            get { return _newCurrentPriceText; }
            set
            {
                _newCurrentPriceText = value;
                OnPropertyChanged(nameof(CurrentPriceText));
                var normalized = value.Replace('.', ',');

                if (decimal.TryParse(normalized, out var parsed))
                    DecimalCurrentPrice = parsed;
            }
        }

        public decimal DecimalCurrentPrice { get; set; } = 0;

        private ObservableCollection<Security> _securities;
        public ObservableCollection<Security> Securities 
        { 
            get => _securities;
            set
            {
                _securities = value;
                OnPropertyChanged(nameof(Securities));
            } 
        }
        public ICommand SaveCommand { get; }
        public ICommand DeleteItemCommand { get; }
        public ICommand EditItemCommand { get; }

        private ICommand _startEditCommand;
        public ICommand StartEditCommand
        {
            get
            {
                if (_startEditCommand == null)
                {
                    _startEditCommand = new RelayCommand<Security>(security =>
                    {
                        EditingSecurity = security;
                        EditedPriceText = security.CurrentPrice.ToString();
                        OnPropertyChanged(nameof(EditingSecurity));
                        OnPropertyChanged(nameof(EditedPriceText));
                    });
                }
                return _startEditCommand;
            }
        }

        public ICommand SaveEditCommand => new RelayCommand<Security>(security =>
        {
            if (decimal.TryParse(EditedPriceText, out var newPrice))
            {
                security.ChangeCurrentPrice(newPrice);
                // возможно, нужно обновить JSON
            }
            EditingSecurity = null;
            OnPropertyChanged(nameof(EditingSecurity));
        });
        public ICommand CancelEditCommand => new RelayCommand(() =>
        {
            EditingSecurity = null;
            OnPropertyChanged(nameof(EditingSecurity));
        });

        public AdminPageViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            Securities = new ObservableCollection<Security>(SecurityStorage.GetAllSecurities());
            SaveCommand = new RelayCommand(SaveData);
            DeleteItemCommand = new RelayCommand<Security>(DeleteSecurity);
            EditItemCommand = new RelayCommand<Security>(EditSecurityPrice);
        }

        private void SaveData()
        {
            Security newSecurity = new Security(NewTicker, NewName, NewCompany, _newSecurityType, DecimalCurrentPrice);
            SecurityStorage.AddSecurity(newSecurity);
            Securities.Add(newSecurity);

            NewTicker = "";
            NewName = "";
            NewCompany = "";
            TypeOfNewSecurityText = "";
            CurrentPriceText = "";
        }

        private void DeleteSecurity(Security security)
        {
            SecurityStorage.RemoveSecurityFromJson(security.Id);
            Securities.Remove(security);
        }
        private void EditSecurityPrice(Security security)
        {

        }
    }
}
