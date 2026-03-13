namespace InvestingManagerApp.Models
{
    public class Security
    {
        public int Id { get; set; }
        public string Ticker { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public SecurityType Type { get; set; }
        public decimal CurrentPrice { get; set; } = 0m;


        public Security()
        {
        }

        // Основной конструктор
        public Security(string ticker, string name, string company, SecurityType type, decimal currentPrice)
        {
            Ticker = ticker;
            Name = name;
            Company = company;
            Type = type;
            CurrentPrice = currentPrice;
        }
        
        public void ChangeCurrentPrice(decimal currentPrice)
        {
            CurrentPrice = currentPrice;
        }

    }
}
