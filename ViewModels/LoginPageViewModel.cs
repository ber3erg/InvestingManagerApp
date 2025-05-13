using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using InvestingManagerApp.Views;
using InvestingManagerApp.Services;
using InvestingManagerApp.Models;

namespace InvestingManagerApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {   
        private readonly MainViewModel _mainViewModel;
        // Поля данного класса олицитворяют связку с xaml страничкой
        private string _login;
        private string _password;
        private string _errorMessage;
        private List<User> otherUsers;


        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
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
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged($"{nameof(ErrorMessage)}");
            }
        }
        public LoginPageViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            otherUsers = JsonDataStorage.GetUsersFromJsonFile();
            
            LoginCommand = new RelayCommand(ToLogin);
            RegisterCommand = new RelayCommand(NavigateToRegister);
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        Admin admin = new Admin("Пётр", "terb", "1234");
        public void ToLogin()
        {
            if (Login == admin.Login && Password == admin.Password)
            {

                var adminPage = new AdminPageViewModel(_mainViewModel);
                _mainViewModel.NavigateTo(new AdminPage { DataContext = adminPage });
            } else
            {
                foreach (User user in otherUsers)
                {
                    if (user.Login == Login && Password == user.Password)
                    {
                        _mainViewModel.CurrentUser.Login(user);
                        var userPage = new UserPageViewModel(_mainViewModel);
                        _mainViewModel.NavigateTo(new UserPage { DataContext = userPage });
                        
                    }
                }
            }
            ErrorMessage = "Пользователь не найден";
        }

        public void NavigateToRegister()
        {
            var registerPage = new RegisterViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new RegisterPage { DataContext = registerPage });
        }
    }
}
