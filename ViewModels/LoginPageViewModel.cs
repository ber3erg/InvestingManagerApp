using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using InvestingManagerApp.Views;

namespace InvestingManagerApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {   
        private readonly MainViewModel _mainViewModel;
        // Поля данного класса олицитворяют связку с xaml страничкой
        private string _username;
        private string _password;
        private string _errorMassage;


        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Password
        {   
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMassage
        {
            get => _errorMassage;
            set
            {
                _errorMassage = value;
                OnPropertyChanged($"{nameof(ErrorMassage)}");
            }
        }
        public LoginPageViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            LoginCommand = new RelayCommand(ToLogin);
        }

        public ICommand LoginCommand { get; }

        public void ToLogin()
        {
            var adminViewModel = new AdminPageViewModel();
            var adminPage = new AdminPage { DataContext = adminViewModel };
            _mainViewModel.NavigateTo(adminPage);
        }
    }
}
