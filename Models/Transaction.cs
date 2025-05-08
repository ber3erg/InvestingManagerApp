namespace InvestingManagerApp.Models
{
    public class Transaction
    {
        private static int counter = 0; // Сделай static, иначе каждый экземпляр будет считать заново
        public int Id { get; }          // readonly свойство
        public TransactionType Type { get; private set; }
        public int PortfolioId { get; private set; }
        public int SecurityId { get; private set; } // Связь с ценной бумагой
        public DateTime Date { get; private set; }
        public int Amount { get; private set; } // Кол-во ценных бумаг
        public decimal PricePerUnit { get; private set; } // плата за единицу ценной бумаги

        public Transaction()
        {
            Id = ++counter;
        }

        private Transaction(int securityId, int portfolioId, TransactionType type, int amount, decimal pricePerUnit, DateTime dateTime)
            : this()
        {
            SecurityId = securityId;
            Type = type;
            Amount = amount;
            Type = type;
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