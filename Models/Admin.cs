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
        public void AddNewSecurity(Security security) {
            SecurityStorage.AddSecurity(security);
        }

        public void DeleteSecurity(Security security) {
            SecurityStorage.RemoveSecurity(security);
        }

        // Получение всех ценных бумаг из хранилища
        public List<Security> GetSecurities()
        {
            return SecurityStorage.GetAllSecurities();  // Предположим, что SecurityStorage хранит все ценные бумаги
        }

        public void ChangeSecurityCurrentPrice(decimal newPrice, string ticker)
        {
            var security = SecurityStorage.GetSecurityByTicker(ticker);
            if (security != null)
            {
                security.ChangeCurrentPrice(newPrice);
            }
        }
    }
}
