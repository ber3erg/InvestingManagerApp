using InvestingManagerApp.Services;

namespace InvestingManagerApp.Models
{
    public class Portfolio
    {
        private static int counter = 0; // static счётчик
        public int Id { get; }          // readonly свойство
        public int UserId { get; private set; }

        public string Name { get; private set; }

        public Portfolio(string name, int userId)
        {
            Id = ++counter;
            Name = name;
            UserId = userId;

            PortfolioStorage.AddPortfolio(this);
        }

        public void ChangeName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name;
        }
    }
}
