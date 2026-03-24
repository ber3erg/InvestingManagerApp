using InvestingManagerApp.Data;
using InvestingManagerApp.Models;
using InvestingManagerApp.Services;
using InvestingManagerApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InvestingManagerApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;
        private readonly PersonSession _personSession;
        public ObservableCollection<PortfolioCardModel> PortfolioCards { get; set; }

        public ICommand OpenPortfolioCommand {  get; set; }
        public ICommand NavigateToMainCommand { get; set; }
        public ICommand NavigateToHistoryCommand { get; set; }
        public ICommand NavigateToSearchCommand { get; set; }

        public MainPageViewModel(MainViewModel mainViewModel, PersonSession personSession)
        {
            _mainViewModel = mainViewModel;
            _personSession = personSession;

            OpenPortfolioCommand = new RelayCommand(OpenPortfolio);
            NavigateToMainCommand = new RelayCommand(NavigateToMain);
            NavigateToHistoryCommand = new RelayCommand(NavigateToHistory);
            NavigateToSearchCommand = new RelayCommand(NavigateToSearch);
        }

        public void OpenPortfolio() { }
        public void NavigateToMain() { }
        public void NavigateToHistory() { }
        public void NavigateToSearch() { }

    }

    public class PortfolioCardModel
    {
        public int PortfolioId { get; set; }
        public string Name { get; set; } = "";
        public decimal TotalValue { get; set; }
        public decimal TotalProfit { get; set; }
    }
}

