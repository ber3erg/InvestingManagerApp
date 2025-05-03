namespace InvestingManagerApp.Models
{
    public class Portfolio
    {
        private static int counter = 0; // Сделай static, иначе каждый экземпляр будет считать заново
        public int Id { get; }          // readonly свойство

        public string Name { get; private set; }
        private List<Transaction> transactions = new List<Transaction>();
        private List<Security> securities = new List<Security>();
        public List<Security> Securities
        {
            get => securities;
            set => securities = value;
        }
        public Portfolio(string name)
        {
            Id = ++counter;
            Name = name;
        }

        public void ChangeName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name;
        }

        public void AddTransaction(Transaction transaction)
        {
            if (transaction != null)
                transactions.Add(transaction);
        }

        public void DeleteTransaction(int transactionId)
        {
            var transaction = transactions.FirstOrDefault(t => t.Id == transactionId);
            if (transaction != null)
                transactions.Remove(transaction);
        }

        public void AddSecurity(Security security)
        {
            if (!Securities.Any(s => s.Ticker == security.Ticker))
                Securities.Add(security);
        }

        public void DeleteSecurity(string ticker)
        {
            var security = Securities.FirstOrDefault(s => s.Ticker == ticker);
            if (security != null)
                Securities.Remove(security);
        }

        // метод реализует подсчитывание настоящей стоимости портфеля без учёта купонов и девидендов
        public decimal CalculateTotalValue()
        {
            decimal total = 0m;

            foreach (var transaction in transactions)
            {
                if (transaction.Type == TransactionType.Buy)
                {
                    total += transaction.Quantity.Value * transaction.PricePerUnit.Value;
                }
                else if (transaction.Type == TransactionType.Sell)
                {
                    total -= transaction.Quantity.Value * transaction.PricePerUnit.Value;
                }
            }

            return total;
        }

        public List<Transaction> GetTransactionsBySecurity(Security security)
        {
            return transactions
                .Where(t => t.SecurityTicker == security.Ticker)
                .ToList();
        }
    }
}
