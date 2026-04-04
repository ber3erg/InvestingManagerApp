using InvestingManagerApp.Models;
using InvestingManagerApp.Services;
using InvestingManagerApp.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InvestingManagerApp.ViewModels
{
    public class AdminPageViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;

        public ICommand NavigateToSecuritiesCommand { get; }
        public ICommand NavigateToUsersCommand { get; }
        public ICommand LogoutCommand { get; }

        public AdminPageViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            NavigateToSecuritiesCommand = new RelayCommand(NavigateToSecurities);
            NavigateToUsersCommand = new RelayCommand(NavigateToUsers);
            LogoutCommand = new RelayCommand(Logout);
        }

        public void NavigateToSecurities()
        {
            var adminSecurityPageViewModel = new AdminSecurityPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new AdminSecurityPage { DataContext = adminSecurityPageViewModel });
        }

        public void NavigateToUsers()
        {
            var adminUserPageViewModel = new AdminUserPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new AdminUserPage { DataContext = adminUserPageViewModel });
        }
        private void Logout()
        {
            _mainViewModel.PersonSession.SignOut();
            var loginPageViewModel = new LoginPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new LoginPage { DataContext = loginPageViewModel });
        }

    }
}
