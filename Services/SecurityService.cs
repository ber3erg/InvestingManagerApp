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

        public static Security[] SearchSecurities()
        {
            return new Security[0];
        }


        public static Security[] GetSecuritiesByTicker()
        {
            return new Security[0];
        }

        public static Security[] GetSecuritiesByCompany()
        {
            return new Security[0];
        }
        public static Security[] GetSecuritiesByName()
        {
            return new Security[0];
        }

        public static Security EditCurrentPrice()
        {
            return new Security();
        }
    }
}
