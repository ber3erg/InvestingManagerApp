using System.Text.Json.Serialization;
using InvestingManagerApp.Services;

namespace InvestingManagerApp.Models
{
    public class Security
    {
        private static int counter = 0;
        [JsonInclude]
        public int Id { get; private set; }
        [JsonInclude]
        public string Ticker { get; private set; }
        [JsonInclude]
        public string Name { get; private set; }
        [JsonInclude]
        public string Company { get; private set; }
        [JsonInclude]
        public SecurityType Type { get; private set; }
        [JsonInclude]
        public decimal CurrentPrice { get; private set; }


        public Security()
        {   
            Id = 0;
            Ticker = "aaaa";
            Name = string.Empty;
            Company = string.Empty;
            Type = SecurityType.Bond;
            CurrentPrice = 0m;
        }

        // Основной конструктор
        public Security(string ticker, string name, string company, SecurityType type, decimal currentPrice)
        {   
            Id = ++counter;
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

        public static void SetCounter(int value)
        {
            if (value > counter)
                counter = value;
        }

    }
}
