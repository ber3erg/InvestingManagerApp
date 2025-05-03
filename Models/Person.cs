using System;

namespace InvestingManagerApp.Models
{
    public abstract class Person
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }

        public Person(string name, string login, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Login = login;
            Password = password;
        }

        // Пустой конструктор, если нужно для десериализации или WPF привязки
        protected Person()
        {
            Id = Guid.NewGuid();
        }
        public virtual void ChangeName(string name){
            if (string.IsNullOrWhiteSpace(name)){
                Console.WriteLine("Имя не может быть пустым");
            } else {
                Name = name;
            }
        }
    }
}
