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
    public class SearchPageViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;

        private ObservableCollection<Security> _searchedSecurities;
        private string _searchText;
        private string _errorMessage;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
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

        public ObservableCollection<Security> SearchedSecurities
        {
            get => _searchedSecurities;
            set
            {
                _searchedSecurities = value;
                OnPropertyChanged(nameof(SearchedSecurities));
            }
        }

        public ICommand NavigateToMainCommand { get; }
        public ICommand NavigateToHistoryCommand { get; }
        public ICommand NavigateToSearchCommand { get; }
        public ICommand LogoutCommand { get; }

        public ICommand BuySecurityCommand { get; }
        public ICommand SearchSecuritiesCommand { get; }
        public SearchPageViewModel(MainViewModel mainViewModel) 
        {
            _mainViewModel = mainViewModel;

            NavigateToMainCommand = new RelayCommand(NavigateToMain);
            NavigateToHistoryCommand = new RelayCommand(NavigateToHistory);
            NavigateToSearchCommand = new RelayCommand(NavigateToSearch);
            LogoutCommand = new RelayCommand(Logout);

            BuySecurityCommand = new RelayCommand<Security>(BuySecurityNavigate);
            SearchSecuritiesCommand = new RelayCommand(SearchSecurities);

            SearchedSecurities = new ObservableCollection<Security>();
        }

        public void SearchSecurities()
        {
            SearchedSecurities.Clear();
            var securityList = _mainViewModel.SecurityService.SearchSecurities(SearchText);
            if (securityList.Count() == 0) 
            {
                ErrorMessage = "Ничего не найдено";
                return;
            }
            ErrorMessage = "";

            foreach (var security in securityList)
            {
                SearchedSecurities.Add(security);
            }
        }

        public void BuySecurityNavigate(Security security)
        {
            var createTransactionPageViewModel = new CreateTransactionPageViewModel(_mainViewModel, security);
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
    }
}
