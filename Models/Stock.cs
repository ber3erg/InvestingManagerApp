namespace InvestingManagerApp.Models
{
    public class Stock : Security
    {
        public decimal? DividendYield { get; set; } // например, 5.2 = 5.2%

        public Stock(string ticker, string name, string company, decimal currentPrice, decimal? dividendYield = null)
            : base(ticker, name, company, SecurityType.Stock, currentPrice)
        {
            DividendYield = dividendYield;
        }

        public void ChangeDividendYield(decimal newYield)
        {
            DividendYield = newYield;
        }

        public override decimal GetEstimatedYield()
        {
            return DividendYield ?? 0; // Если дивиденды не указаны — считаем 0%
        }
    }
}