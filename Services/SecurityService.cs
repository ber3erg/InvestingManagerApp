using InvestingManagerApp.Data;
using InvestingManagerApp.Models;

namespace InvestingManagerApp.Services
{
    public class SecurityService
    {
        // сервис для работы с ценными бумагами:
        // 1. получение по тикеру
        // 2. получение по названию компанию
        // 3. получение по названию бумаги
        // 4. редактирование настоящей стоимости

        public List<Security> SearchSecurities(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return new List<Security>();

            using var db = new AppDBContext();
            string search = searchString.Trim();

            return db.Securities
                .Where(s =>
                    s.Ticker.Contains(search) ||        // сверка по тикеру
                    s.Company.Contains(search) ||       // сверка по компании
                    s.Name.Contains(search))            // сверка по названию ценной бумагие
                .ToList();                              // по итогу если хоть где-то совпадение, то будет добавлен в список
        }

        public Security GetSecurityById(int securityId)
        {
            using var db = new AppDBContext();
            return db.Securities.First(s => securityId == s.Id);
        }

        public List<Security> GetSecurities()
        {
            using var db = new AppDBContext();
            return db.Securities.ToList();
        }

        public void RemoveSecurity(int securityId)
        {
            using var db = new AppDBContext();
            var security = db.Securities.First(s => securityId == s.Id);
            var transactions = db.Transactions.Where(t => t.SecurityId == securityId).ToList();
            foreach (var transaction in transactions)
            {
                db.Transactions.Remove(transaction);
            }
            db.Securities.Remove(security);
            db.SaveChanges();
        }

        public void AddSecurity(Security security)
        {
            using var db = new AppDBContext();
            db.Securities.Add(security);
            db.SaveChanges();
        }

        public void EditSecurity(Security newSecurity)
        {
            using var db = new AppDBContext();
            var oldSecurity = db.Securities.First(s => s.Id == newSecurity.Id);

            oldSecurity.Ticker = newSecurity.Ticker;
            oldSecurity.Company = newSecurity.Company;
            oldSecurity.CurrentPrice = newSecurity.CurrentPrice;
            oldSecurity.Type = newSecurity.Type;

            db.SaveChanges();
        }

        public void EditCurrentPrice(int securityId, decimal newPrice)
        {
            using var db = new AppDBContext();
            var theSecurity = db.Securities.FirstOrDefault(p => p.Id == securityId);
            if (theSecurity != null)
            {
                theSecurity.CurrentPrice = newPrice;
                db.SaveChanges();
            }

        }
    }
}
