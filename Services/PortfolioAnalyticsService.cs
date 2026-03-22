using InvestingManagerApp.Models;
using InvestingManagerApp.Data;

namespace InvestingManagerApp.Services
{
    public class PortfolioAnalyticsService
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


        public decimal CalculatePortfolioTotalValue(int portfolioId)
        {
            // сначала посчитаем вложенное каждой ценной бумагой, а потом суммируем
            decimal result = 0m;
            List<PortfolioAsset> assets = BuildPortfolioAssets(portfolioId);

            foreach (var asset in assets)
            {
                result += CalcTotalSecurityPrice(asset);
            }

            return result;
        }

        public decimal CalculatePortfolioTotalProfit(int portfolioId)
        {
            // для посчёта суммарной прибыли по портфелю, будем вызывать buildPortfolioAssets
            // и по assets будем считать итоги

            decimal result = 0m;
            List<PortfolioAsset> assets = BuildPortfolioAssets(portfolioId);

            foreach (var asset in assets) 
            {
                result += CalcTotalSecurityProfit(asset);
            }

            return result;
        }


        public List<PortfolioAsset> BuildPortfolioAssets(int portfolioId)
        {
            using var db = new AppDBContext();              // создаём контект

            // создадим выборку transactions по портфелю
            List<Transaction> transactions = db.Transactions.Where(tr => tr.PortfolioId == portfolioId).ToList();

            // создадим выборку всех secId внутри портфеля
            List<int> securityIds = transactions.Select(tr => tr.SecurityId).       // select выбирает только поля selectId
                                                            Distinct().ToList();    // distinct убирает дубликаты

            // создадим выборку securities нужных нам
            var securities = db.Securities.Where(s => securityIds.Contains(s.Id)).ToDictionary(s => s.Id);

            List<PortfolioAsset> assets = new List<PortfolioAsset>();

            // далее мы строим portfolioAsset по каждой ценной бумаге
            foreach (var securityId in securityIds)
            {
                var secTransactions = transactions.Where(t => t.SecurityId == securityId).ToList();
                assets.Add(CalculateSecurityMetrics(portfolioId, secTransactions, securities[securityId].CurrentPrice, securityId));
            }

            return assets;
        }

        // Считает прибыль с ценной бумаги по портфелю
        public decimal CalcTotalSecurityProfit(PortfolioAsset asset)
        {
            // По логике расчётов:
            // cуммарнаяПродажа + Кол-во * настоящаяЦена + ПолученнаяСторонняяПрибыль - Суммарная цена покупки = общая прибыль в портфеле
            decimal result = asset.TotalSellPrice + asset.Quantity * asset.CurrentPrice + asset.IncomeRecieved - asset.TotalBuyPrice;

            return result;
        }

        // считает стоимость акций, которые сейчас в портфеле (непроданные)
        public decimal CalcTotalSecurityPrice(PortfolioAsset asset)
        {
            decimal result = asset.CurrentPrice * asset.Quantity;

            return result;
        }

        public PortfolioAsset CalculateSecurityMetrics(int portfolioId, List<Transaction> transactions, decimal currentSecurityPrice, int securityId)
        {
            // это единственный сервис, который работает с portfolioasset
            // поэтому мы можем загонять данные в ассет из-вне
            PortfolioAsset asset = new PortfolioAsset(portfolioId, securityId);

            asset.Quantity = CalcSecurityQuantityInPortf(transactions);
            asset.TotalBuyPrice = CalcTotalBuyPrice(transactions);
            asset.CurrentPrice = currentSecurityPrice;
            asset.TotalSellPrice = CalcTotalSellPrice(transactions);
            asset.IncomeRecieved = CalcTotalIncomeProfit(transactions);
            
            return asset;
        }


        // считается кол-во определённой ценной бумаги в портфеле
        public int CalcSecurityQuantityInPortf(List<Transaction> transactions)
        {
            int result = 0;
            foreach (Transaction transaction in transactions)
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
            return result;
        }


        // считается суммарная стоимость покупок
        public decimal CalcTotalBuyPrice(List<Transaction> transactions)
        {
            var buyTransactions = transactions.Where(p => p.Type == TransactionType.Buy).ToList();

            decimal totalBuyPrice = 0m;
            foreach (Transaction transaction in buyTransactions) 
            {
                totalBuyPrice += transaction.PricePerUnit * transaction.Amount;
            }

            return totalBuyPrice;
        }


        // считается суммарная стоимость продаж
        public decimal CalcTotalSellPrice(List<Transaction> transactions)
        {
            var sellTransactions = transactions.Where(p => p.Type == TransactionType.Sell).ToList();

            decimal totalSellPrice = 0m;
            foreach (Transaction transaction in sellTransactions)
            {
                totalSellPrice += transaction.PricePerUnit * transaction.Amount;
            }

            return totalSellPrice;
        }


        // считается суммарный доход полученный с девидендов и купонов
        public decimal CalcTotalIncomeProfit(List<Transaction> transactions)
        {
            var incomeTransactions = transactions.Where(p => p.Type == TransactionType.Dividend ||
                                                            p.Type == TransactionType.Coupon).ToList();

            decimal totalIncomeProfit = 0m;
            foreach (Transaction transaction in incomeTransactions)
            {
                totalIncomeProfit += transaction.PricePerUnit * transaction.Amount;
            }

            return totalIncomeProfit;
        }
    }
}
