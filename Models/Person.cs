using System;

namespace InvestingManagerApp.Models
{
    public abstract class Person
    {
        private static int counter = 0;
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string Login { get; private set; } = string.Empty;
        public bool IsAdmin { get; protected set; } = false;
        public string Password { get; private set; } = string.Empty;

        public Person(string name, string login, string password)
        {
            Id = ++counter;
            Name = name;
            Login = login;
            Password = password;
        }

        // Пустой конструктор, если нужно для десериализации или WPF привязки
        public Person()
        {
            Id = 0;
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
