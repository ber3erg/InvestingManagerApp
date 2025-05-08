namespace InvestingManagerApp.Models
{
    public class User : Person
    {

        public decimal GetTotalInvestment(){

            
        }
        public Portfolio GetPortfolios(int portfolioId){
            return portfolios.FirstOrDefault(p => p.Id == portfolioId)!;
        }

    }
}
