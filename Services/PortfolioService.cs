using InvestingManagerApp.Models;

namespace InvestingManagerApp.Services
{
    public class PortfolioService
    {
        // сервис для работы с портфелями:
        // 1. Получения портфелей по пользователюID
        // 2. удаление портфеля

        public static Portfolio[] GetPortfoliosByPerson()
        {
            return new Portfolio[0];
        }

        public static Portfolio AddPortfolio()
        {
            return new Portfolio();
        }

        public static Portfolio RemovePortfolio()
        {
            return new Portfolio();
        }

        public static Portfolio GetPortfolioById() 
        {
            return new Portfolio();
        }

        // GetPortfolioByPerson
    }
}
