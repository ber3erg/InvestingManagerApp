using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestingManagerApp.Models
{
    // Класс нужен, чтобы хранить в нём информацию по одной ценной бумаге в портфеле
    public class PortfolioAsset
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public int SecurityId { get; set; }
        public int Quantity { get; set; }
        // По логике расчётов:
        // cуммарнаяПродажа + Кол-во * настоящаяЦена + ПолученнаяСторонняяПрибыль - Суммарная цена покупки = общая прибыль в портфеле
        public decimal TotalBuyPrice { get; set; }
        public decimal TotalSellPrice { get; set; }
        public decimal IncomeRecieved { get; set; }

        public PortfolioAsset()
        {
        }

        public PortfolioAsset(int portfolioId, int securityId)
        {
            PortfolioId = portfolioId;
            SecurityId = securityId;
        }

    }
}
