namespace InvestingManagerApp.Models
{
    public class Transaction
    {
        public int Id { get; set; }          
        public TransactionType Type { get; set; }
        public int PortfolioId { get; set; }
        public int SecurityId { get; set; } // Связь с ценной бумагой
        public DateTime Date { get; set; }
        public int Amount { get; set; } // Кол-во ценных бумаг
        public decimal PricePerUnit { get; set; } // плата за единицу ценной бумаги

        public Transaction()
        {
        }

        public Transaction(int portfolioId, int securityId, TransactionType type, int amount, decimal pricePerUnit, DateTime dateTime)
            : this()
        {
            PortfolioId = portfolioId;
            SecurityId = securityId;
            Type = type;
            Amount = amount;
            Date = dateTime;
            PricePerUnit = pricePerUnit;
        }

        public void ChangeDate(DateTime date)
        {
            Date = date;
        }

        public void ChangePricePerUnit(decimal newPrice)
        {
            PricePerUnit = newPrice;
        }

        public void ChangeAmount(int newAmount)
        {
            Amount = newAmount;
        }
    }
}