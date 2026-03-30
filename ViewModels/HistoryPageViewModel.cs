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


        public ICommand AddTransactionCommand { get; }
        public ICommand NavigateToMainCommand { get; }
        public ICommand NavigateToHistoryCommand { get; }
        public ICommand NavigateToSearchCommand { get; }


        public HistoryPageViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            NavigateToMainCommand = new RelayCommand(NavigateToMain);
            NavigateToHistoryCommand = new RelayCommand(NavigateToHistory);
            NavigateToSearchCommand = new RelayCommand(NavigateToSearch);

            AddTransactionCommand = new RelayCommand(NavigateToAddTransactionPage);

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
                CurrentTransactionInfo.SecurityName = _mainViewModel.SecurityService.GetSecurityById(transaction.SecurityId).Name;

                var currentPortfolio = _mainViewModel.PortfolioService.GetPortfolioById(transaction.PortfolioId);
                if (currentPortfolio != null) 
                {
                    CurrentTransactionInfo.PortfolioName = currentPortfolio.Name;
                }

                result.Add(CurrentTransactionInfo);
            }
            
            return result;

        }

        public void NavigateToAddTransactionPage()
        {
            var createTransactionPageViewModel = new CreateTransactionPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new CreateTransactionPage { DataContext = createTransactionPageViewModel });
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
        public string SecurityName { get; set; }
        public string PortfolioName { get; set; }
        public decimal TotalPrice => CurrentTransaction.PricePerUnit * CurrentTransaction.Amount;
    }
}
