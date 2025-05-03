namespace InvestingManagerApp.Models
{
    public abstract class Security
    {
        public string Ticker {  get; private set; }
        public string Name {  get; private set; }
        public string Company { get; private set; }
        public SecurityType Type { get; private set; }
        public decimal CurrentPrice { get; private set; }


        public Security()
        {
            Ticker = "aaaa";
            Name = string.Empty;
            Company = string.Empty;
            Type = SecurityType.Bond;
            CurrentPrice = 0m;
        }

        // Основной конструктор
        public Security(string ticker, string name, string company, SecurityType type, decimal currentPrice)
        {
            Ticker = ticker;
            Name = name;
            Company = company;
            Type = type;
            CurrentPrice = currentPrice;

            SecurityStorage.AddSecurity(this);
        }

        // Упрощённый конструктор
        public Security(string ticker, string name)
        {
            Ticker = ticker;
            Name = name;
            Company = "Не указано";
            Type = SecurityType.Stock; // По умолчанию
            CurrentPrice = 0;
        }
        
        public void ChangeCurrentPrice(decimal currentPrice)
        {
            CurrentPrice = currentPrice;
        }

        public abstract decimal GetEstimatedYield();
    }
}
