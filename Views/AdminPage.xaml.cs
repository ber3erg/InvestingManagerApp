using InvestingManagerApp.Models;
using InvestingManagerApp.Services;
using InvestingManagerApp.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace InvestingManagerApp.Views
{
    public partial class AdminPage : Window
    {
        
        public AdminPage()
        {
            InitializeComponent();
            DataContext = new AdminPageViewModel();
        }

    }
}
