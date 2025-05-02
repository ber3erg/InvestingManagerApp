using System;

namespace InvestingManagerApp.Models
{
    public abstract class Person
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }

        public virtual void ChangeName(string name){
            if (string.IsNullOrWhiteSpace(name)){
                Console.WriteLine("Имя не может быть пустым");
            } else {
                Name = name;
            }
        }
    }
}
