using System.Windows;
using InvestingManagerApp.Services;

namespace InvestingManagerApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Создаем и показываем главное окно (MainWindow)
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
