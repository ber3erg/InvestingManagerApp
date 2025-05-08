using InvestingManagerApp.Models;

namespace InvestingManagerApp.Services
{
    public static class PortfolioStorage
    {
        public static List<Portfolio> Portfolios { get; private set; } = JsonDataStorage.GetPortfoliosFromJsonFile();

        public static void AddPortfolio(Portfolio portfolio)
        {
            Portfolios.Add(portfolio);
            JsonDataStorage.AddPortfolioToJsonFile(portfolio);
        }

        public static void RemovePortfolio(int portfolioId) 
        { 
            foreach (Portfolio portfolio in Portfolios)
            {
                if (portfolio.Id == portfolioId)
                {
                    Portfolios.Remove(portfolio);
                    JsonDataStorage.DeletePortfolioFromJsonFile(portfolio);
                }
            }
        }

        public static List<Portfolio> GetPortfoliosByUserId(int userId)
        {
            List<Portfolio> result = new List<Portfolio>();
            foreach (Portfolio portfolio in Portfolios)
            {
                if (portfolio.UserId == userId)
                {
                    result.Add(portfolio);
                }
            }
            return result;
        }
    }
}
