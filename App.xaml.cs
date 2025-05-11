using System.Windows;

namespace InvestingManagerApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Создаем и показываем главное окно (MainWindow)
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}
