using InvestingManagerApp.Services;

namespace InvestingManagerApp.Models
{
    public class User : Person
    {

        public User() : base() { }
        public User(string name, string login, string password) : base(name, login, password)
        {

        }
        public decimal GetTotalInvestment(){
            // Метод просматривает каждый портфель в памяти
            // и сравнивает userId в портфеле с id пользователя
            // Анализатор портфеля подсчитывает стоимость портфеля и добавляет в результирующую стоимость
            decimal result = 0;
            ;
            foreach (Portfolio portfel in PortfolioStorage.Portfolios) {
                if (portfel.UserId == Id) 
                {
                    result += PortfolioAnalyzer.CalculatePortfelValue(portfel.Id);
                }
            }
            return result;
        }

        public decimal GetTotalProfit(){
            // Метод просматривает каждый портфель в памяти
            // и сравнивает userId в портфеле с id пользователя
            // Анализатор портфеля подсчитывает прибыль портфеля и добавляет в результирующую стоимость
            decimal result = 0;
            ;
            foreach (Portfolio portfel in PortfolioStorage.Portfolios)
            {
                if (portfel.UserId == Id)
                {
                    result += PortfolioAnalyzer.CalculatePortfelProfit(portfel.Id);
                }
            }
            return result;
        }

    }
}
