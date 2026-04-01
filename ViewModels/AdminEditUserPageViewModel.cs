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

        public AdminEditUserPageViewModel(MainViewModel mainViewModel, int personId)
        {

        }
    }
}
