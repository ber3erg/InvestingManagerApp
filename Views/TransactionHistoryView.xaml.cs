using InvestingManagerApp.Models;
using InvestingManagerApp.ViewModels;
using System.Collections.Generic;
using System.Windows;

namespace InvestingManagerApp.Views
{
    public partial class TransactionHistoryView : Window
    {   

        public TransactionHistoryView()
        {
            InitializeComponent();
            DataContext = new TransactionHistoryViewModel();
        }

        // Переход на окно портфелей
        private void NavigateToPortfolios_Click(object sender, RoutedEventArgs e)
        {
            var portfolioView = new PortfolioListView(); // Убедись, что это окно создано
            portfolioView.Show();
            this.Close();
        }

        // Кнопка "Назад"
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var userDashboard = new PortfolioListView();
            userDashboard.Show();
            this.Close();
        }
    }
}