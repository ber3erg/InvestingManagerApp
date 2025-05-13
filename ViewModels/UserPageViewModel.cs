using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestingManagerApp.Views;
using InvestingManagerApp.Models;

namespace InvestingManagerApp.ViewModels
{
    public class UserPageViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;
        public UserPageViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
    }
}
