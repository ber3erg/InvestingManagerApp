

namespace InvestingManagerApp.Models
{
    public class Admin : Person
    {
        public void AddNewSecurity(Security security) {
            SecurityStorage.AddSecurity(security);
        }

        public void DeleteSecurity(Security security) {
            SecurityStorage.RemoveSecurity(security);
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
