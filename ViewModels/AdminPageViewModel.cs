using InvestingManagerApp.Models;
using System.Collections.Generic;
using InvestingManagerApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InvestingManagerApp.ViewModels
{
    public class AdminPageViewModel : ViewModelBase
    {
        private ObservableCollection<Security> _securities;
        public ObservableCollection<Security> Securities 
        { 
            get => _securities;
            set
            {
                _securities = value;
                OnPropertyChanged(nameof(Securities));
            } 
        }
        public ICommand SaveCommand { get; }

        Security newSecurity = new Security();
        public AdminPageViewModel()
        {
            Securities = new ObservableCollection<Security>(SecurityStorage.GetAllSecurities());
            SaveCommand = new RelayCommand(SaveData);
        }

        private void SaveData()
        {
            SecurityStorage.AddSecurity(newSecurity);
        }
        
    }
}
