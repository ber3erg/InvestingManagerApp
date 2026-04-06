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
    public class PortfolioPageViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;
        private readonly int _portfolioId;

        private ObservableCollection<PortfolioAssetForTable> _assetsForTable;

        public ObservableCollection<PortfolioAssetForTable> AssetsForTables
        {
            get => _assetsForTable;
            set
            {
                _assetsForTable = value;
                OnPropertyChanged(nameof(AssetsForTables));
            }
        }

        public ICommand AddTransactionCommand { get; }
        public ICommand OpenSecurityCommand { get; }

        public ICommand NavigateToMainCommand { get; }
        public ICommand NavigateToHistoryCommand { get; }
        public ICommand NavigateToSearchCommand { get; }
        public ICommand LogoutCommand { get; }

        public PortfolioPageViewModel(MainViewModel mainViewModel, int portfolioId)
        {
            _mainViewModel = mainViewModel;
            _portfolioId = portfolioId;

            NavigateToMainCommand = new RelayCommand(NavigateToMain);
            NavigateToHistoryCommand = new RelayCommand(NavigateToHistory);
            NavigateToSearchCommand = new RelayCommand(NavigateToSearch);
            LogoutCommand = new RelayCommand(Logout);

            AddTransactionCommand = new RelayCommand(NavigateToAddTransactionPage);
            OpenSecurityCommand = new RelayCommand<PortfolioAssetForTable>(OpenSecurity);

            AssetsForTables = BuildAssetsForTable();

        }
        
        public ObservableCollection<PortfolioAssetForTable> BuildAssetsForTable()
        {
            ObservableCollection<PortfolioAssetForTable> result = new ObservableCollection<PortfolioAssetForTable>();

            List<PortfolioAsset> portfolioAssets = _mainViewModel.PortfolioAnalyticsService.BuildPortfolioAssets(_portfolioId);

            foreach (PortfolioAsset asset in portfolioAssets) 
            {
                PortfolioAssetForTable currentAssetTable = new PortfolioAssetForTable();
                currentAssetTable.PortfolioAsset = asset;
                currentAssetTable.SecurityName = _mainViewModel.SecurityService.GetSecurityById(asset.SecurityId).Name;
                result.Add(currentAssetTable);
            }
            return result;
        }

        public void NavigateToAddTransactionPage()
        {
            var currentPortfolio = _mainViewModel.PortfolioService.GetPortfolioById(_portfolioId);
            var createTransactionPageViewModel = new CreateTransactionPageViewModel(_mainViewModel, currentPortfolio);
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

        private void Logout()
        {
            _mainViewModel.PersonSession.SignOut();
            var loginPageViewModel = new LoginPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new LoginPage { DataContext = loginPageViewModel });
        }

        public void OpenSecurity(PortfolioAssetForTable portfolioAsset)
        {
            var securityPageViewModel = new SecurityPageViewModel(_mainViewModel, portfolioAsset.PortfolioAsset.SecurityId);
            _mainViewModel.NavigateTo(new SecurityPage { DataContext = securityPageViewModel });
        }

    }

    public class PortfolioAssetForTable
    {
        public string SecurityName { get; set; } = "";
        public PortfolioAsset PortfolioAsset { get; set; }
        public decimal totalValue => PortfolioAsset.CurrentPrice * PortfolioAsset.Quantity;
        public decimal totalProfit => PortfolioAsset.TotalSellPrice + PortfolioAsset.CurrentPrice * PortfolioAsset.Quantity + PortfolioAsset.IncomeRecieved - PortfolioAsset.TotalBuyPrice;
    }
}
