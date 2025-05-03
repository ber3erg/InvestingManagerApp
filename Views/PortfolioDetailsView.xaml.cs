using InvestingManagerApp.Models;
using InvestingManagerApp.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace InvestingManagerApp.Views
{
    public partial class PortfolioDetailsView : Window
    {
        public PortfolioDetailsView(Portfolio portfolio)
        {
            InitializeComponent();
            DataContext = new PortfolioDetailsViewModel(portfolio);
        }

        // Переход на экран истории транзакций
        private void NavigateToTransactionHistory_Click(object sender, RoutedEventArgs e)
        {
            var transactionHistoryView = new TransactionHistoryView(); // Переход на экран истории транзакций
            transactionHistoryView.Show();
            this.Close();
        }

        // Переход на список портфелей
        private void NavigateToPortfolioList_Click(object sender, RoutedEventArgs e)
        {
            var portfolioListOverview = new PortfolioListView(); // Переход на экран списка портфелей
            portfolioListOverview.Show();
            this.Close();
        }

        // Редактирование выбранной ценной бумаги
        private void EditSecurityButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedSecurity = (Security)DataGrid.SelectedItem; // Получаем выбранную ценную бумагу
            if (selectedSecurity != null)
            {
                var securityEditorView = new SecurityEditorView(selectedSecurity); // Создаем экран для редактирования
                securityEditorView.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите ценную бумагу для редактирования.");
            }
        }

        // Кнопка "Назад"
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var portfolioListOverview = new PortfolioListView(); // Заменить на актуальный стартовый экран
            portfolioListOverview.Show();
            this.Close();
        }
    }
}