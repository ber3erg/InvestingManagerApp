using InvestingManagerApp.Services;
using System;
using System.Windows;
using InvestingManagerApp.Data;
using InvestingManagerApp.Models;

namespace InvestingManagerApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            using var db = new AppDBContext();
            db.Database.EnsureCreated();
            
            
            if (!db.Persons.Any())
            {
                db.Persons.Add(new Person("Пётр", "Peter", "12345"));

                db.SaveChanges();
            }

            // Создаем и показываем главное окно (MainWindow)
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
