
namespace InvestingManagerApp.Models
{
    public class Bond : Security
    {
        public decimal CouponRate { get; set; }
        public DateTime MaturityDate { get; set; }

        public Bond(string ticker, string name, string company, decimal currentPrice, decimal couponRate, DateTime maturityDate)
            : base(ticker, name, company, SecurityType.Bond, currentPrice)
        {
            CouponRate = couponRate;
            MaturityDate = maturityDate;
        }

        public void ChangeCouponData(decimal newRate, DateTime newDate)
        {
            CouponRate = newRate;
            MaturityDate = newDate;
        }

        public override decimal GetEstimatedYield()
        {
            // Простейшая модель: просто вернуть купонный доход в процентах
            return CouponRate;
        }
    }
}
