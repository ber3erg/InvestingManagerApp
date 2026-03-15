using InvestingManagerApp.Data;
using InvestingManagerApp.Models;
using System.Windows.Navigation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InvestingManagerApp.Services
{
    public class AuthService
    {
        // Данный класс проверяет процесс идентификации:
        // 1. Проверять наличие в базе данных
        // 2. Регистрировать пользователя
        // 3. Проверять корректность данных авторизации
        // 4. устанавливать значение PersonSession

        public Person? AuthenticatePerson(string login, string password)
        {

            return new Person();
        }

        public bool RegisterPerson(string login, string password)
        {
            return true;
        }

        public Person? GetPersonByLogin(string login) { 
            
            if (string.IsNullOrWhiteSpace(login))
            {
                return null;
            }
            
            // создаём связь с базой данных через appDBContext
            // using позволяет в конце закрыть эту связь, чтобы всё хорошо работало
            using var db = new AppDBContext(); 
            // EF core использует LINQ запросы к dbset, а dbcontext управляет жизненным циклом работы с базой
            return db.Persons.FirstOrDefault(p => p.Login == login); 
        }

//        FirstOrDefault
//взять первый объект или null

//var person = db.Persons.FirstOrDefault(p => p.Login == login);

//        Where
//        отфильтровать данные

//        var portfolios = db.Portfolios.Where(p => p.PersonId == personId);

//ToList
//материализовать результат в список

//var list = db.Portfolios.Where(p => p.PersonId == personId).ToList();

//        Any
//        проверить, есть ли хотя бы один объект

//bool exists = db.Persons.Any(p => p.Login == login);

//        Add
//        добавить объект в контекст

//        db.Persons.Add(new Person("Пётр", "peter", "12345"));

//SaveChanges
//сохранить изменения в БД

//db.SaveChanges();
    }
}
