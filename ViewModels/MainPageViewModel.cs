using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestingManagerApp.Views;
using InvestingManagerApp.Models;
using InvestingManagerApp.Services;

namespace InvestingManagerApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel;
        private readonly PersonSession _personSession;

        public MainPageViewModel(MainViewModel mainViewModel, PersonSession personSession)
        {
            _mainViewModel = mainViewModel;
            _personSession = personSession;
        }
    }
}
}
