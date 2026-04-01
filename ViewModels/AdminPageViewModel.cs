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

        public AdminPageViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            NavigateToSecuritiesCommand = new RelayCommand(NavigateToSecurities);
            NavigateToUsersCommand = new RelayCommand(NavigateToUsers);
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

    }
}
