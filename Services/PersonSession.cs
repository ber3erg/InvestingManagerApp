using InvestingManagerApp.Models;

namespace InvestingManagerApp.Services
{
    public class PersonSession
    {
        // В этом классе хранится информация о настоящем пользователе, который авторизовался в приложении

        public Person? CurrentPerson { get; private set; }
        public bool IsAuthenticated => CurrentPerson != null;

        public void SignIn(Person person)
        {
            CurrentPerson = person;
        }

        public void SignOut()
        {
            CurrentPerson = null;
        }
    }
}
