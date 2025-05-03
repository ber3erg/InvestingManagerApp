using System.Collections.Generic;
using System.Linq;

namespace InvestingManagerApp.Models
{
    public static class SecurityStorage
    {
        private static List<Security> securities = new List<Security>();

        public static void AddSecurity(Security security)
        {
            if (!securities.Any(s => s.Ticker == security.Ticker))
            {
                securities.Add(security);
            }
        }

        public static void RemoveSecurity(Security security)
        {
            securities.RemoveAll(s => s.Ticker == security.Ticker);
        }

        public static List<Security> GetAllSecurities()
        {
            return new List<Security>(securities); // Возвращаем копию
        }

        public static Security? GetSecurityByTicker(string ticker)
        {
            return securities.FirstOrDefault(s => s.Ticker == ticker);
        }
    }
}

