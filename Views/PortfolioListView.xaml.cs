using InvestingManagerApp.Models;
using InvestingManagerApp.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace InvestingManagerApp.Views
{
    public partial class PortfolioListView : Window
    {
        public PortfolioListView()
        {
            InitializeComponent();
            DataContext = new PortfolioListViewModel();
        }

        // Переход на экран истории транзакций
        private void NavigateToTransactionHistory_Click(object sender, RoutedEventArgs e)
        {
            var transactionHistoryView = new TransactionHistoryView(); // Переход на экран истории транзакций
            transactionHistoryView.Show();
            this.Close();
        }

        // Редактирование портфеля
        private void EditPortfolioButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedPortfolio = (Portfolio)DataGrid.SelectedItem; // Получаем выбранный портфель
            if (selectedPortfolio != null)
            {
                var portfolioEditorView = new PortfolioDetailsView(selectedPortfolio); // Создаем экран для редактирования
                portfolioEditorView.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите портфель для редактирования.");
            }
        }

        // Кнопка "Назад"
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var userDashboard = new PortfolioListView(); // Заменить на актуальный стартовый экран
            userDashboard.Show();
            this.Close();
        }
    }
}
