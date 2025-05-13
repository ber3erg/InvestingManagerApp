using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using InvestingManagerApp.Models;
using InvestingManagerApp.Services;
using InvestingManagerApp.ViewModels;
using InvestingManagerApp.Views;

namespace InvestingManagerApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Page _currentPage;
        public UserSession CurrentUser { get; private set; }
        public Page CurrentPage
        {
            get => _currentPage;
            set=> SetProperty(ref _currentPage, value, nameof(CurrentPage));
        }

        public MainViewModel()
        {
            CurrentUser = new UserSession();
            ShowLoginPage();
        }

        public void NavigateTo(Page page)
        {
            CurrentPage = page;
        }

        public void ShowLoginPage()
        {
            var loginVM = new LoginPageViewModel(this);
            CurrentPage = new LoginPage { DataContext = loginVM };
            OnPropertyChanged(nameof(CurrentPage));
        }

        public void Logout()
        {
            CurrentUser.Logout();
            ShowLoginPage();
        }
    }
}
