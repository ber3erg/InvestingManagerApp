using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using InvestingManagerApp.Services;
using InvestingManagerApp.Models;
using InvestingManagerApp.Views;

namespace InvestingManagerApp.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        public MainViewModel _mainViewModel;
        private string _userName;
        private string _login;
        private string _password;
        private string _confirmingPassword;
        private string? _errorMessage;
        private List<User> _otherUsers;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
                if (string.IsNullOrEmpty(value))
                {
                    ErrorMessage = "Остались незаполненные поля";
                } else
                {
                    ErrorMessage = null;
                }
            }
        }
        public string Login
        {
            get { return _login; }
            set 
            { 
                _login = value;
                OnPropertyChanged(nameof(Login));

                if (string.IsNullOrEmpty(value))
                {
                    ErrorMessage = "Остались незаполненные поля";
                }
                else
                {
                    ErrorMessage = null;
                    foreach (User user in OtherUsers)
                    {
                        if (user.Login == value)
                        {
                            ErrorMessage = "Пользователь с таким логином уже существует";
                        }
                    }
                }
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                if (string.IsNullOrEmpty(value))
                {
                    ErrorMessage = "Остались незаполненные поля";
                }
                else
                {
                    ErrorMessage = null;
                }
            }
        }
        public string ConfirmingPassword
        {
            get { return _confirmingPassword; }
            set
            {
                _confirmingPassword = value;
                OnPropertyChanged(nameof(ConfirmingPassword));
                if (Password != value || string.IsNullOrEmpty(value))
                {
                    ErrorMessage = "Пароли должны совпадать";
                } else
                {
                    ErrorMessage = null;
                }
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public List<User> OtherUsers
        {
            get => _otherUsers;
            set
            {
                _otherUsers = value;
            }
        }

        public ICommand RegisterCommand { get; set; }
        public ICommand NavigateToLoginCommand { get; set; }

        public RegisterViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            OtherUsers = JsonDataStorage.GetUsersFromJsonFile();
            RegisterCommand = new RelayCommand(RegisterUser);
            NavigateToLoginCommand = new RelayCommand(NavigateToLoginPage);
        }

        public void RegisterUser()
        {
            foreach (User user in OtherUsers)
            {
                if (user.Login == Login)
                {
                    ErrorMessage = "Пользователь с таким логином уже существует";
                }
            }
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password) && ErrorMessage == null)
            {
                JsonDataStorage.AddUserToJsonFile(new User(UserName, Login, Password));
                NavigateToLoginPage();
            }
        }

        public void NavigateToLoginPage()
        {
            var loginPage = new LoginPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new LoginPage { DataContext=loginPage });
        }
    }
}
