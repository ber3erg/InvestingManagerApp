
namespace InvestingManagerApp.Models
{
    public class Fund : Security
    {
        public decimal ManagementFee { get; set; }
        public Fund(string ticker, string name, string company, decimal currentPrice, decimal managementFee)
                    : base(ticker, name, company, SecurityType.Fund, currentPrice)
        {
            ManagementFee = managementFee;
        }

        public override decimal GetEstimatedYield()
        {
            // Здесь можно использовать базовую логику — пока что просто возвращаем 0
            // Позже можно внедрить формулу, если будет аналитика по фонду
            return 0;
        }
    }
}
