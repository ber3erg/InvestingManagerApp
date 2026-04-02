using InvestingManagerApp.Models;
using InvestingManagerApp.Services;
using InvestingManagerApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InvestingManagerApp.ViewModels
{
    class AdminSecurityPageViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;

        private ObservableCollection<SecurityForTable> _securities;

        public ObservableCollection<SecurityForTable> Securities
        {
            get => _securities;
            set
            {
                _securities = value;
                OnPropertyChanged(nameof(Securities));
            }
        }

        public ICommand NavigateToSecuritiesCommand { get; }
        public ICommand NavigateToUsersCommand { get; }
        public ICommand RemoveSecurityCommand { get; }
        public ICommand EditSecurityCommand { get; }
        public ICommand AddNewSecurityCommand { get; }

        public AdminSecurityPageViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            NavigateToSecuritiesCommand = new RelayCommand(NavigateToSecurities);
            NavigateToUsersCommand = new RelayCommand(NavigateToUsers);
            RemoveSecurityCommand = new RelayCommand<SecurityForTable>(RemoveSecurity);
            AddNewSecurityCommand = new RelayCommand(NavigateToAddNewSecurity);
            EditSecurityCommand = new RelayCommand<SecurityForTable>(OpenSecurityEditor);

            Securities = BuildSecurityForTables();
            
        }
        
        public ObservableCollection<SecurityForTable> BuildSecurityForTables()
        {
            var result = new ObservableCollection<SecurityForTable>();

            var securityList = _mainViewModel.SecurityService.GetSecurities();
            foreach (Security security in securityList)
            {
                var currentSecForTable = new SecurityForTable();
                currentSecForTable.TheSecurity = security;
                result.Add(currentSecForTable);
            }

            return result;
        }

        public void OpenSecurityEditor(SecurityForTable securityForTable)
        {
            var createSecurityPageViewModel = new CreateSecurityPageViewModel(_mainViewModel, securityForTable.TheSecurity.Id);
            _mainViewModel.NavigateTo(new CreateSecurityPage { DataContext = createSecurityPageViewModel });
        }

        public void NavigateToAddNewSecurity()
        {
            var createSecurityPageViewModel = new CreateSecurityPageViewModel(_mainViewModel);
            _mainViewModel.NavigateTo( new CreateSecurityPage { DataContext = createSecurityPageViewModel });
        }

        public void RemoveSecurity(SecurityForTable security)
        {
            _mainViewModel.SecurityService.RemoveSecurity(security.TheSecurity.Id);
            Securities = BuildSecurityForTables();
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

    }
    public class SecurityForTable
    {
        public Security TheSecurity { get; set; }
        public string SecurityTypeText =>
        TheSecurity.Type switch
        {
            SecurityType.Stock => "Акция",
            SecurityType.Bond => "Облигация",
            SecurityType.Fund => "Фонд",
        };
    }
}
