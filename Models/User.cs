namespace InvestingManagerApp.Models
{
    public class User : Person
    {
        private List<Portfolio> portfolios = new List<Portfolio>();
        public List<Portfolio> Portfolios{
            get => portfolios;
            set => portfolios = value;
        }

        public void AddPortfolio(Portfolio portfolio)
        {
            if (!portfolios.Any(p => p.Id == portfolio.Id))
            {
                portfolios.Add(portfolio);
            }
        }

        public void DeletePortfolio(int portfolioId)
        {
            var portfolio = portfolios.FirstOrDefault(p => p.Id == portfolioId);
            if (portfolio != null)
            {
                portfolios.Remove(portfolio);
            }
        }

        public decimal GetTotalInvestment(){
            return portfolios.Sum(p => p.CalculateTotal());
        }

        public Portfolio GetPortfolioById(int portfolioId){
            return portfolios.FirstOrDefault(p => p.Id == portfolioId);
        }
    }
}
