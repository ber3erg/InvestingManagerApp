using InvestingManagerApp.Data;
using InvestingManagerApp.Models;
using InvestingManagerApp.Services;
using InvestingManagerApp.Views;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace InvestingManagerApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;
        private ObservableCollection<PortfolioCardModel> _portfolioCards;

        public ObservableCollection<PortfolioCardModel> PortfolioCards
        {
            get => _portfolioCards;
            set
            {
                _portfolioCards = value;
                OnPropertyChanged(nameof(PortfolioCards));
            }
        }

        public ICommand OpenPortfolioCommand {  get; }
        public ICommand NavigateToMainCommand { get; }
        public ICommand NavigateToHistoryCommand { get; }
        public ICommand NavigateToSearchCommand { get; }
        public ICommand LogoutCommand { get; }

        public ICommand AddNewPortfolioCommand { get; }
        public ICommand RemovePortfolioCommand { get; }

        public ICommand StartRenamePortfolioCommand { get; }
        public ICommand SavePortfolioNameCommand { get; }

        public MainPageViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            OpenPortfolioCommand = new RelayCommand<PortfolioCardModel>(OpenPortfolio);
            RemovePortfolioCommand = new RelayCommand<PortfolioCardModel>(RemovePortfolio);
            AddNewPortfolioCommand = new RelayCommand(AddNewPortfolio);
            StartRenamePortfolioCommand = new RelayCommand<PortfolioCardModel>(StartRenamePortfolio);
            SavePortfolioNameCommand = new RelayCommand<PortfolioCardModel>(SavePortfolioName);

            NavigateToMainCommand = new RelayCommand(NavigateToMain);
            NavigateToHistoryCommand = new RelayCommand(NavigateToHistory);
            NavigateToSearchCommand = new RelayCommand(NavigateToSearch);
            LogoutCommand = new RelayCommand(Logout);

            BuildPortfolioCardModels();
        }

        public void BuildPortfolioCardModels()
        {
            // собираем portfoliocards
            // собираем список портфелей
            // по каждому портфелю собираем portfolioCardModel
            List<Portfolio> portfolios = _mainViewModel.PortfolioService.GetPortfoliosByPersonId(_mainViewModel.PersonSession.CurrentPerson.Id);

            PortfolioCards = new ObservableCollection<PortfolioCardModel>();
            foreach (Portfolio portfolio in portfolios)
            {
                PortfolioCardModel currentModel = new PortfolioCardModel();

                currentModel.PortfolioId = portfolio.Id;
                currentModel.Name = portfolio.Name;
                currentModel.TotalProfit = _mainViewModel.PortfolioAnalyticsService.CalculatePortfolioTotalProfit(portfolio.Id);
                currentModel.TotalValue = _mainViewModel.PortfolioAnalyticsService.CalculatePortfolioTotalValue(portfolio.Id);

                PortfolioCards.Add(currentModel);
            }
        }

        private void StartRenamePortfolio(PortfolioCardModel item)
        {
            if (item == null)
                return;

            item.EditableName = item.Name;
            item.IsEditingName = true;
        }

        private void SavePortfolioName(PortfolioCardModel item)
        {
            if (item == null)
                return;

            var newName = item.EditableName?.Trim();

            if (string.IsNullOrWhiteSpace(newName))
                return;

            item.Name = newName;
            _mainViewModel.PortfolioService.UpdatePortfolioName(item.PortfolioId, newName);
            item.IsEditingName = false;
            BuildPortfolioCardModels();
        }

        public void RemovePortfolio(PortfolioCardModel model)
        {
            _mainViewModel.PortfolioService.RemovePortfolio(model.PortfolioId);
            BuildPortfolioCardModels();
        }

        public void AddNewPortfolio()
        {
            _mainViewModel.PortfolioService.AddPortfolio(new Portfolio("Безымянный", _mainViewModel.PersonSession.CurrentPerson.Id));
            BuildPortfolioCardModels();
        }

        public void OpenPortfolio(PortfolioCardModel portfolioCard) 
        {
            var portfolioPage = new PortfolioPageViewModel(_mainViewModel, portfolioCard.PortfolioId);
            _mainViewModel.NavigateTo(new PortfolioPage { DataContext = portfolioPage });
        }
        public void NavigateToMain() 
        { 
            var mainPageViewModel = new MainPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new MainPage { DataContext = mainPageViewModel });
        }

        private void Logout()
        {
            _mainViewModel.PersonSession.SignOut();
            var loginPageViewModel = new LoginPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new LoginPage { DataContext = loginPageViewModel });
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

    public class PortfolioCardModel : ViewModelBase
    {
        public int PortfolioId { get; set; }
        public string Name { get; set; } = "";
        public decimal TotalValue { get; set; }
        public decimal TotalProfit { get; set; }
        private bool _isEditingName;
        private string _editableName;
        public bool IsEditingName
        {
            get => _isEditingName;
            set
            {
                _isEditingName = value;
                OnPropertyChanged(nameof(IsEditingName));
            }
        }

        public string EditableName
        {
            get => _editableName;
            set
            {
                _editableName = value;
                OnPropertyChanged(nameof(EditableName));
            }
        }
        public PortfolioCardModel() {}
    }
}

