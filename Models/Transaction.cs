namespace InvestingManagerApp.Models
{
    public class Transaction
    {
        private static int counter = 0; // Сделай static, иначе каждый экземпляр будет считать заново
        public int Id { get; }          // readonly свойство
        public TransactionType Type { get; set; }
        public string SecurityTicker { get; set; } // Связь с ценной бумагой
        public DateTime Date { get; set; }
        public decimal? PricePerUnit { get; set; }
        public int? Quantity { get; set; } // Кол-во, если применимо
        public decimal? Amount { get; set; } // Цена за единицу
        public decimal? PaymentPerUnit { get; set; } // Для дивидендов и купонов

        public Transaction()
        {
            Id = ++counter;
            Date = DateTime.Now;
        }

        // Удобный конструктор для Buy/Sell
        public Transaction(string securityTicker, TransactionType type, int quantity, decimal pricePerUnit)
            : this()
        {
            SecurityTicker = securityTicker;
            Type = type;
            Quantity = quantity;
            PricePerUnit = pricePerUnit;
        }

        // Конструктор для выплат
        public Transaction(string securityTicker, TransactionType type, decimal paymentPerUnit)
            : this()
        {
            SecurityTicker = securityTicker;
            Type = type;
            PaymentPerUnit = paymentPerUnit;
        }

        public void ChangeDate(DateTime date)
        {
            Date = date;
        }

        public void ChangePricePerUnit(decimal newPrice)
        {
            PricePerUnit = newPrice;
        }

        public void ChangeQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }

        public void ChangeAmount(decimal newAmount)
        {
            Amount = newAmount;
        }

        public void ChangePaymentPerUnit(decimal newPayment)
        {
            PaymentPerUnit = newPayment;
        }

        // метод возвращает суммарную цену сделки
        public decimal CalculateTotal()
        {
            if (Type == TransactionType.Buy || Type == TransactionType.Sell)
            {
                if (Quantity.HasValue && PricePerUnit.HasValue)
                {
                    return Quantity.Value * PricePerUnit.Value;
                }
            }
            else if (Type == TransactionType.Dividend || Type == TransactionType.Coupon)
            {
                if (Quantity.HasValue && PaymentPerUnit.HasValue)
                {
                    return Quantity.Value * PaymentPerUnit.Value;
                }
            }

            return 0m;
        }
    }
}