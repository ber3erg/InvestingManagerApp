using InvestingManagerApp.Data;
using InvestingManagerApp.Models;
using InvestingManagerApp.Services;
using InvestingManagerApp.Views;
using System.Windows.Input;

namespace InvestingManagerApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {   
        private readonly MainViewModel _mainViewModel;
        // Поля данного класса олицитворяют связку с xaml страничкой
        private string _login;
        private string _password;
        private string _errorMessage;
        private readonly AuthService _authService;
        private readonly PersonSession _personSession;


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
        public LoginPageViewModel(MainViewModel mainViewModel, AuthService authService, PersonSession personSession)
        {
            _mainViewModel = mainViewModel;
            _authService = authService;
            _personSession = personSession;
            
            LoginCommand = new RelayCommand(ToLogin);
            RegisterCommand = new RelayCommand(NavigateToRegister);
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public void ToLogin()
        {
            var person = _authService.AuthenticatePerson(Login, Password);
            if (person != null)
            {
                _personSession.SignIn(person);
                var mainPage = new MainPageViewModel(_mainViewModel, _personSession);
                _mainViewModel.NavigateTo(new MainPage { DataContext = mainPage });
            }
            else
            {
                ErrorMessage = "Пользователь не найден";
            }
        }

        public void NavigateToRegister()
        {
            var registerPage = new RegisterViewModel(_mainViewModel, _authService, _personSession);
            _mainViewModel.NavigateTo(new RegisterPage { DataContext = registerPage });
        }
    }
}
