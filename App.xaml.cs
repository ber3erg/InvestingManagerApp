using InvestingManagerApp.Services;
using System;
using System.Windows;
using InvestingManagerApp.Data;
using Microsoft.EntityFrameworkCore;
using InvestingManagerApp.Models;

namespace InvestingManagerApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            using var dbContext = new AppDBContext();
            dbContext.Database.Migrate();
            DataBaseSeeder.Seed(dbContext);

            // Создаем и показываем главное окно (MainWindow)
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            var _securityService = new SecurityService();
            _ = _securityService.TryUpdatePricesAsync();

            base.OnStartup(e);
        }
    }
}
