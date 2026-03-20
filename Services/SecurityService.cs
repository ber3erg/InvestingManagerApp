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


        //public List<Security> GetSecuritiesByTicker(string ticker)
        //{
        //    using var db = new AppDBContext();
        //    List<Security> returnArray = db.Securities.Where(p => p.Ticker.Contains(ticker.Trim())).ToList();
        //    return returnArray;
        //}

        //public List<Security> GetSecuritiesByCompanyName(string companyName)
        //{
        //    using var db = new AppDBContext();
        //    List<Security> returnArray = db.Companies.Where(p => p..Name(companyName.Trim())).ToList();
        //    return returnArray;
        //}
        //public List<Security> GetSecuritiesByName(string name)
        //{
        //    using var db = new AppDBContext();
        //    List<Security> returnArray = db.Securities.Where(p => p.Name.Contains(name.Trim())).ToList();
        //    return returnArray;
        //}

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
