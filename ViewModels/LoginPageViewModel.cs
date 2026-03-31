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
            
            LoginCommand = new RelayCommand(ToLogin);
            RegisterCommand = new RelayCommand(NavigateToRegister);
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public void ToLogin()
        {
            var person = _mainViewModel.AuthService.AuthenticatePerson(Login, Password);
            if (person != null)
            {
                if (person.IsAdmin)
                {
                    _mainViewModel.PersonSession.SignIn(person);
                    var adminPage = new AdminPageViewModel(_mainViewModel);
                    _mainViewModel.NavigateTo(new AdminPage { DataContext = adminPage });
                }
                else
                {
                    _mainViewModel.PersonSession.SignIn(person);
                    var mainPage = new MainPageViewModel(_mainViewModel);
                    _mainViewModel.NavigateTo(new MainPage { DataContext = mainPage });
                }
            }
            else
            {
                ErrorMessage = "Пользователь не найден";
            }
        }

        public void NavigateToRegister()
        {
            var registerPage = new RegisterViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new RegisterPage { DataContext = registerPage });
        }
    }
}
