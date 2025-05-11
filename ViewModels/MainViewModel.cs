using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using InvestingManagerApp.ViewModels;

namespace InvestingManagerApp
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
            var loginView = new LoginPageViewModel(this);
            CurrentPage = new LoginPage { DataContext = loginView };
        }

        public void NavigateTo(Page page)
        {
            CurrentPage = page;
        }
    }
}
