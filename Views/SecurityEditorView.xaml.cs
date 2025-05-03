using System;
using System.Windows;
using System.Windows.Controls;
using InvestingManagerApp.Models;

namespace InvestingManagerApp.Views
{
    public partial class SecurityEditorView : Window
    {
        private Security _security;

        public SecurityEditorView(Security security)
        {
            InitializeComponent();
            _security = security;

            NameTextBlock.Text = _security.Name;
            TickerTextBlock.Text = _security.Ticker;
            PriceTextBox.Text = _security.CurrentPrice.ToString("F2");
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(PriceTextBox.Text, out decimal newPrice))
            {
                _security.ChangeCurrentPrice(newPrice);
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Введите корректную числовую цену.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
