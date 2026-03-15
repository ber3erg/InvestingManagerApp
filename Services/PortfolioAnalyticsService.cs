using InvestingManagerApp.Models;

namespace InvestingManagerApp.Services
{
    public static class PortfolioAnalyticsService
    {
        // Сервис аналитики содержимого портфеля и заталкивания данных в portfolioassets
        // 1. Подсчёт суммарной покупки -
        // 2. Подсчёт суммарной продажи -
        // 3. Подсчёт суммарного дохода с купонов/девидендов -
        // 4. Подсчёт оставшегося кол-ва определённой бумаги в портфеле -
        // 5. подсчёт суммарной стоимости портфеля -
        // 6. Подсчёт суммарной прибыли -
        // 7. Создание portfolioAssets
        // 8. Подсчёт общей стоимости бумаги в портфеле -
        // 9. Подсчёт общей прибыли бумаги в портфеле -
        // 

        public static decimal BuildPortfolioAssets()
        {
            return 0m;
        }
        public static decimal CalculatePortfolioSummary(int portfolioId)
        {
            // сначала посчитаем вложенное каждой ценной бумагой, а потом суммируем
            decimal result = 0;
            List<int> securitiesIds = TransactionStorage.GetSecuritiesByPortfelId(portfolioId);
            foreach (int id in securitiesIds)
            {
                result += CalcSecurityValueInPortfolio(portfolioId, id);
            }

            return result;
        }
        public static decimal CalculateSecurityMetrics()
        {
            return 0m;
        }
        public static decimal CalculatePortfelTotalProfit(int portfolioId)
        {
            // сначала посчитаем вложенное каждой ценной бумагой, а потом суммируем
            decimal result = 0;
            List<int> securitiesIds = TransactionStorage.GetSecuritiesByPortfelId(portfolioId);
            foreach (int id in securitiesIds)
            {
                result += CalcSecurityProfitInPortfolio(portfolioId, id);
            }

            return result;
        }

        public static int CalcTotalSecurityQuantityInPortf(int portfId, int secId)
        {
            int result = 0;
            foreach (Transaction transaction in TransactionStorage.GetTransactionsByPortfolioId(portfId))
            {
                if (transaction.SecurityId == secId)
                {
                    if (transaction.Type == TransactionType.Buy)
                    {
                        result += transaction.Amount;
                    }
                    else if (transaction.Type == TransactionType.Sell)
                    {
                        result -= transaction.Amount;
                    }
                }
            }
            return result;
        }

        public static decimal CalcTotalSecurityPrice(int portfolioId, int secId) 
        {
            int amount = CalcSecurityAmount(portfolioId, secId);
            Security sec = (Security)SecurityStorage.GetSecurityById(secId)!;
            decimal result = amount * sec.CurrentPrice;

            return result;
        }

        public static decimal CalcTotalSecurityProfit(int portfolioId, int secId)
        {
            // подсчёт прибыли происходит следующим образом
            // 1. высчитывается потенциальная прибыль (кол-во купленного за всё время * настояющую цену)
            // 2. высчитывается потерянная прибыль (из настоящей цены вычитается цена продажи и прибавляется к общему значению)
            // 3. потенциальная прибыль - потерянная прибыль

            Security _security = SecurityStorage.GetSecurityById(secId)!;

            decimal potencialProfit = CalcSecurityAmount(portfolioId, secId) 
                * _security.CurrentPrice;

            decimal lostProfit = 0;

            // в получаемом списке есть транзакции только связанные с портфелем и ценной бумагой
            List<Transaction> _transactions = TransactionStorage.Transactions
                .Where(t => t.PortfolioId == portfolioId && t.SecurityId == secId)
                .ToList();
            
            foreach (Transaction transaction in _transactions)
            {
                if (transaction.Type == TransactionType.Sell)
                {
                    lostProfit += (_security.CurrentPrice - transaction.PricePerUnit) * transaction.Amount;
                } else if (transaction.Type == TransactionType.Dividend || transaction.Type == TransactionType.Coupon)
                {
                    potencialProfit += transaction.PricePerUnit * transaction.Amount;
                }
            }

            return potencialProfit - lostProfit;
        }

        public static decimal CalcTotalBuyPrice()
        {
            decimal result = 0;
            return result;
        }

        public static decimal CalcTotalSellPrice()
        {
            decimal result = 0;
            return result;
        }

        public static decimal CalcTotalIncomeProfit()
        {
            decimal result = 0;
            return result;
        }
    }
}
