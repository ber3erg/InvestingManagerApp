using InvestingManagerApp.Models;
using InvestingManagerApp.Services;
using InvestingManagerApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InvestingManagerApp.ViewModels
{
    class AdminUserPageViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;
        private ObservableCollection<Person> _people;
        
        public ObservableCollection<Person> People
        {
            get => _people;
            set
            {
                _people = value;
                OnPropertyChanged(nameof(People));
            }
        }


        public ICommand NavigateToSecuritiesCommand { get; }
        public ICommand NavigateToUsersCommand { get; }
        public ICommand LogoutCommand { get; }

        public ICommand EditUserCommand { get; }
        public ICommand RemovePersonCommand { get; }

        public AdminUserPageViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            NavigateToSecuritiesCommand = new RelayCommand(NavigateToSecurities);
            NavigateToUsersCommand = new RelayCommand(NavigateToUsers);
            LogoutCommand = new RelayCommand(Logout);

            RemovePersonCommand = new RelayCommand<Person>(RemovePerson);
            EditUserCommand = new RelayCommand<Person>(OpenUserEditor);

            People = BuildPeopleForTable();
        }

        public ObservableCollection<Person> BuildPeopleForTable()
        {
            var people = new ObservableCollection<Person>();
            var peopleList = _mainViewModel.PersonService.GetPeople();
            foreach (var person in peopleList) 
            { 
                people.Add(person);
            }
            return people;
        }

        public void RemovePerson(Person person)
        {
            _mainViewModel.PersonService.RemovePerson(person.Id);
            People = BuildPeopleForTable();
        }

        public void OpenUserEditor(Person person)
        {
            var adminEditUserPageViewModel = new AdminEditUserPageViewModel(_mainViewModel, person.Id);
            _mainViewModel.NavigateTo( new AdminEditUserPage { DataContext = adminEditUserPageViewModel });
        }

        public void NavigateToSecurities()
        {
            var adminSecurityPageViewModel = new AdminSecurityPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new AdminSecurityPage { DataContext = adminSecurityPageViewModel });
        }

        public void NavigateToUsers()
        {
            var adminUserPageViewModel = new AdminUserPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new AdminUserPage { DataContext = adminUserPageViewModel });
        }
        private void Logout()
        {
            _mainViewModel.PersonSession.SignOut();
            var loginPageViewModel = new LoginPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo(new LoginPage { DataContext = loginPageViewModel });
        }
    }
}
