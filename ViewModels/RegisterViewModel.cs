using System.Windows.Input;
using InvestingManagerApp.Services;
using InvestingManagerApp.Models;
using InvestingManagerApp.Views;

namespace InvestingManagerApp.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;
        private readonly AuthService _authService;
        private readonly PersonSession _personSession;
        private string _userName;
        private string _login;
        private string _password;
        private string _confirmingPassword;
        private string? _errorMessage = null;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public string Login
        {
            get { return _login; }
            set 
            { 
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ConfirmingPassword
        {
            get { return _confirmingPassword; }
            set
            {
                _confirmingPassword = value;
                OnPropertyChanged(nameof(ConfirmingPassword));
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

        public ICommand RegisterCommand { get; set; }
        public ICommand NavigateToLoginCommand { get; set; }

        public RegisterViewModel(MainViewModel mainViewModel, AuthService authService, PersonSession personSession)
        {
            _mainViewModel = mainViewModel;
            _authService = authService;
            _personSession = personSession;
            RegisterCommand = new RelayCommand(RegisterUser);
            NavigateToLoginCommand = new RelayCommand(NavigateToLoginPage);
        }

        public void RegisterUser()
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmingPassword) || string.IsNullOrEmpty(UserName)) 
            {
                ErrorMessage = "Остались незаполненные поля";
            } 
            else if (Password != ConfirmingPassword)
            {
                ErrorMessage = "Пароли должные совпадать";
            }
            else    // если error massage ничего не содержит, то проводим регистрацию пользователя
            {
                bool flag = _authService.RegisterPerson(UserName, Login, Password);     // регистрация пользователя возвращает bool значение, при успехе - true
                if (flag)
                {
                    NavigateToLoginPage();
                }
                else
                {
                    ErrorMessage = "Что-то пошло не так";
                }
            }
        }

        public void NavigateToLoginPage()
        {
            var loginPage = new LoginPageViewModel(_mainViewModel, _authService, _personSession);
            _mainViewModel.NavigateTo(new LoginPage { DataContext=loginPage });
        }
    }
}
