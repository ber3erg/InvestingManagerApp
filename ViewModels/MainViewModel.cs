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
        public Page CurrentPage
        {
            get => _currentPage;
            set=> SetProperty(ref _currentPage, value, nameof(CurrentPage));
        }

        public MainViewModel()
        {
            ShowLoginPage();
        }

        public void NavigateTo(Page page)
        {
            CurrentPage = page;
        }

        public void ShowLoginPage()
        {
            PersonSession session = new PersonSession();
            AuthService authService = new AuthService();
            var loginVM = new LoginPageViewModel(this, authService, session);
            CurrentPage = new LoginPage { DataContext = loginVM };
            OnPropertyChanged(nameof(CurrentPage));
        }

        public void Logout()
        {
            ShowLoginPage();
        }
    }
}
