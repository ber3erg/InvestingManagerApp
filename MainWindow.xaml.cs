using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InvestingManagerApp.Services;
using InvestingManagerApp.Models;
using InvestingManagerApp.ViewModels;
using InvestingManagerApp.Views;

namespace InvestingManagerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {      
            // когда срабатывает кнопка входа мы получаем сразу два поля данных Login и Password
            // далее мы загружаем себе данные из файлов json и создаём два списка с пользователями и админами
            // цикл проходится по каждому пользователю отдельно, если среди них нет с нужным логином и паролем, то идёт проходка по админам
            // Далее в зависимости от того, кто нам попался отображается нужный экран
            string enteredLogin = EnteredLogin.Text;
            string enteredPassword = EnteredPassword.Text;

            List<User> users = JsonDataStorage.GetUsersFromJsonFile();
            List<Admin> admins = JsonDataStorage.GetAdminsFromJsonFile();
            foreach (User user in users)
            {
                if (user.Login == enteredLogin && user.Password == enteredPassword)
                {
                    var userWindow = new PortfolioListView();
                    userWindow.Show();
                }
            }
            foreach (Admin admin in admins)
            {
                if (admin.Login == enteredLogin && admin.Password == enteredPassword)
                {
                    var adminWindow = new AdminWindowView(admin);
                    adminWindow.Show();
                }
            }

        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}