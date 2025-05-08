using InvestingManagerApp.Services;

namespace InvestingManagerApp.Models
{
    public class Admin : Person
    {
        public Admin(string name, string login, string password)
            : base(name, login, password)
        {
            IsAdmin = true;
        }
    }
}
