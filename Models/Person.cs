namespace InvestingManagerApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
        public string Password { get; set; } = string.Empty;

        public Person(string name, string login, string password)
        {
            Name = name;
            Login = login;
            Password = password;
        }

        public Person(string name, string login, string password, bool isAdmin)
        {
            Name = name;
            Login = login;
            Password = password;
            IsAdmin = isAdmin;
        }

        // Пустой конструктор, если нужно для десериализации или WPF привязки
        public Person()
        {
        }
        public void ChangeName(string name){
            if (!string.IsNullOrWhiteSpace(name)){
                Name = name;
            }
        }
    }
}
