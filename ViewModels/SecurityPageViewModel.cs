using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestingManagerApp.ViewModels
{
    class SecurityPageViewModel
    {
        private readonly MainViewModel _mainViewModel;
        private readonly int _securityId;

        public SecurityPageViewModel(MainViewModel mainViewModel, int securityId)
        {
            _mainViewModel = mainViewModel;
            _securityId = securityId;
        }
    }
}
