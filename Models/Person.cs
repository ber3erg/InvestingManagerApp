using System;
using System.Text.Json.Serialization;

namespace InvestingManagerApp.Models
{
    public abstract class Person
    {
        private static int counter = 0;
        [JsonInclude]
        public int Id { get; protected set; }
        [JsonInclude]
        public string? Name { get; protected set; }
        [JsonInclude]
        public string Login { get; private set; } = string.Empty;
        [JsonInclude]
        public bool IsAdmin { get; protected set; } = false;
        [JsonInclude]
        public string Password { get; protected set; } = string.Empty;

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
            Login = string.Empty;
            Password = string.Empty;
        }
        public virtual void ChangeName(string name){
            if (string.IsNullOrWhiteSpace(name)){
                Console.WriteLine("Имя не может быть пустым");
            } else {
                Name = name;
            }
        }
        public static void SetCounter(int value)
        {
            if (value > counter)
                counter = value;
        }
    }
}
