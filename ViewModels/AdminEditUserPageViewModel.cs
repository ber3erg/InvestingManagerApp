using InvestingManagerApp.Models;
using InvestingManagerApp.Services;
using InvestingManagerApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InvestingManagerApp.ViewModels
{
    
    class AdminEditUserPageViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;
        private readonly int _personId;
        private readonly Person _person;

        private string _login;
        private string _password;
        private string _name;
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

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            } 
        }

        public ICommand SaveChangesCommand { get; }
        public ICommand CanсelChangesCommand { get; }

        public AdminEditUserPageViewModel(MainViewModel mainViewModel, int personId)
        {
            _personId = personId;
            _mainViewModel = mainViewModel;

            SaveChangesCommand = new RelayCommand(SaveChanges);
            CanсelChangesCommand = new RelayCommand(CanсelChanges);

            _person = _mainViewModel.PersonService.GetPersonById(personId);
            Login = _person.Login;
            Password = _person.Password;
            Name = _person.Name;
        }

        public void SaveChanges()
        {
            ErrorMessage = "";
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Name)) 
            {
                ErrorMessage = "Заполните все необходимые поля";
                return;
            }            
            var newPerson = new Person(Name, Login, Password);
            newPerson.Id = _personId;
            _mainViewModel.PersonService.EditPerson(newPerson);

            var adminUserPageViewModel = new AdminUserPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo( new AdminUserPage { DataContext= adminUserPageViewModel });
        }

        public void CanсelChanges() 
        {
            var adminUserPageViewModel = new AdminUserPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new AdminUserPage { DataContext = adminUserPageViewModel });
        }
    }
}
