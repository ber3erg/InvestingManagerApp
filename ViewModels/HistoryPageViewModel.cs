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
    public class HistoryPageViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;

        private ObservableCollection<TransactionInfoForTable> _transactionsAssets;
        public ObservableCollection<TransactionInfoForTable> TransactionsAssets
        {
            get => _transactionsAssets;
            set
            {
                _transactionsAssets = value;
                OnPropertyChanged(nameof(TransactionsAssets));
            }
        }

        public ICommand RemoveTransactionCommand { get; }
        public ICommand AddTransactionCommand { get; }
        public ICommand EditTransactionCommand { get; }

        public ICommand NavigateToMainCommand { get; }
        public ICommand NavigateToHistoryCommand { get; }
        public ICommand NavigateToSearchCommand { get; }
        public ICommand LogoutCommand { get; }

        public HistoryPageViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            NavigateToMainCommand = new RelayCommand(NavigateToMain);
            NavigateToHistoryCommand = new RelayCommand(NavigateToHistory);
            NavigateToSearchCommand = new RelayCommand(NavigateToSearch);
            LogoutCommand = new RelayCommand(Logout);

            EditTransactionCommand = new RelayCommand<TransactionInfoForTable>(EditTransactionNavigate);
            AddTransactionCommand = new RelayCommand(NavigateToAddTransactionPage);
            RemoveTransactionCommand = new RelayCommand<TransactionInfoForTable>(RemoveTransaction);

            TransactionsAssets = BuildTransactionInfoForTables();

        }


        public ObservableCollection<TransactionInfoForTable> BuildTransactionInfoForTables()
        {
            ObservableCollection<TransactionInfoForTable> result = new ObservableCollection<TransactionInfoForTable>();
            
            var transactions = _mainViewModel.TransactionService.GetTransactionsByPerson(_mainViewModel.PersonSession.CurrentPerson.Id);
            foreach (var transaction in transactions) 
            {
                var CurrentTransactionInfo = new TransactionInfoForTable();
                CurrentTransactionInfo.CurrentTransaction = transaction;
                CurrentTransactionInfo.CurrentSecurity = _mainViewModel.SecurityService.GetSecurityById(transaction.SecurityId);

                var currentPortfolio = _mainViewModel.PortfolioService.GetPortfolioById(transaction.PortfolioId);
                if (currentPortfolio != null) 
                {
                    CurrentTransactionInfo.PortfolioName = currentPortfolio.Name;
                }

                result.Add(CurrentTransactionInfo);
            }
            
            return result;

        }

        public void EditTransactionNavigate(TransactionInfoForTable transactionInfo)
        {
            var createTransactionPageViewModel = new CreateTransactionPageViewModel(_mainViewModel, transactionInfo.CurrentTransaction);
            _mainViewModel.NavigateTo( new CreateTransactionPage { DataContext = createTransactionPageViewModel });
        }

        public void RemoveTransaction(TransactionInfoForTable transaction)
        {
            _mainViewModel.TransactionService.RemoveTransaction(transaction.CurrentTransaction.Id);
            TransactionsAssets = BuildTransactionInfoForTables();
        }

        public void NavigateToAddTransactionPage()
        {
            var createTransactionPageViewModel = new CreateTransactionPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new CreateTransactionPage { DataContext = createTransactionPageViewModel });
        }

        private void Logout()
        {
            _mainViewModel.PersonSession.SignOut();
            var loginPageViewModel = new LoginPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new LoginPage { DataContext = loginPageViewModel });
        }

        public void NavigateToMain()
        {
            var mainPageViewModel = new MainPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new MainPage { DataContext = mainPageViewModel });
        }
        public void NavigateToHistory()
        {
            var historyPageViewModel = new HistoryPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new HistoryPage { DataContext = historyPageViewModel });
        }
        public void NavigateToSearch()
        {
            var searchPageViewModel = new SearchPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new SearchPage { DataContext = searchPageViewModel });
        }
    }

    public class TransactionInfoForTable 
    { 
        public Transaction CurrentTransaction { get; set; }
        public Security CurrentSecurity { get; set;  }
        public string SecurityName => CurrentSecurity.Name;
        public string PortfolioName { get; set; }
        public decimal TotalPrice => CurrentTransaction.PricePerUnit * CurrentTransaction.Amount;
        public string TransactionTypeText =>
        CurrentTransaction.Type switch
        {
            TransactionType.Buy => "Покупка",
            TransactionType.Sell => "Продажа",
            TransactionType.Dividend => "Дивиденд",
            TransactionType.Coupon => "Купон",
            _ => ""
        };
        public string SecurityTypeText =>
        CurrentSecurity.Type switch
        {
            SecurityType.Stock => "Акция",
            SecurityType.Bond => "Облигация",
            SecurityType.Fund => "Фонд",
        };
    }
}
