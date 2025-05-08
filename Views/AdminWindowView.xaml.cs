using InvestingManagerApp.Models;
using InvestingManagerApp.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace InvestingManagerApp.Views
{
    public partial class AdminWindowView : Window
    {
        private Admin _admin;

        public AdminWindowView(Person preAdmin)
        {
            InitializeComponent();
            Admin admin = new(preAdmin.Name, preAdmin.Login, preAdmin.Password);
            _admin = admin;
            DataContext = new AdminWindowViewModel(admin);
        }

        // Добавление новой ценной бумаги
        private void AddSecurityButton_Click(object sender, RoutedEventArgs e)
        {
            var ticker = TickerTextBox.Text;
            var name = NameTextBox.Text;
            var type = ((ComboBoxItem)TypeComboBox.SelectedItem).Content.ToString();
            var price = decimal.TryParse(PriceTextBox.Text, out decimal parsedPrice) ? parsedPrice : 0m;

            if (!string.IsNullOrEmpty(ticker) && !string.IsNullOrEmpty(name) && price > 0)
            {
                var newStock = new Stock(ticker, name, type, price);
                _admin.AddNewSecurity(newStock); // Добавляем в хранилище
            }
            else
            {
                MessageBox.Show("Заполните все поля корректно.");
            }
        }

        // Редактирование стоимости ценной бумаги
        private void ChangeSecurityPriceButton_Click(object sender, RoutedEventArgs e)
        {
            var newPrice = decimal.TryParse(EditPriceTextBox.Text, out decimal parsedPrice) ? parsedPrice : 0m;

            if (newPrice > 0)
            {
                var selectedSecurity = (Security)DataGrid.SelectedItem;
                if (selectedSecurity != null)
                {
                    _admin.ChangeSecurityCurrentPrice(newPrice, selectedSecurity.Ticker); // Изменяем стоимость
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите ценную бумагу для редактирования.");
                }
            }
            else
            {
                MessageBox.Show("Введите корректную цену.");
            }
        }

        // Удаление ценной бумаги
        private void DeleteSecurityButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedSecurity = (Security)DataGrid.SelectedItem;
            if (selectedSecurity != null)
            {
                _admin.DeleteSecurity(selectedSecurity); // Удаляем из хранилища
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите ценную бумагу для удаления.");
            }
        }

        // Редактирование ценной бумаги (открытие в новом окне)
        private void EditSecurityButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedSecurity = (Security)DataGrid.SelectedItem;
            if (selectedSecurity != null)
            {
                var editWindow = new SecurityEditorView(selectedSecurity)
                {
                    Owner = this
                };

                if (editWindow.ShowDialog() == true)
                {
                    // Обновление привязки
                    DataGrid.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Выберите ценную бумагу для редактирования.");
            }
        }
    }
}
