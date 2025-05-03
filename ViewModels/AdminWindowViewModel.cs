using InvestingManagerApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InvestingManagerApp.ViewModels
{
    public class AdminWindowViewModel
    {
        public ObservableCollection<Security> Securities { get; set; }

        public AdminWindowViewModel(Admin admin)
        {
            Securities = new ObservableCollection<Security>(admin.GetSecurities());
        }
    }
}
