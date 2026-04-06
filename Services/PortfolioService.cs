using InvestingManagerApp.Data;
using InvestingManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestingManagerApp.Services
{
    public class PortfolioService
    {
        // сервис для работы с портфелями:
        // 1. Получения портфелей по пользователюID
        // 2. удаление портфеля

        public List<Portfolio> GetPortfoliosByPersonId(int personId)
        {
            using var db = new AppDBContext();                                          // создание контекста
            var resultList = db.Portfolios.Where(p => p.PersonId == personId).ToList(); // все портфели, где совпадает personId добавляются в итоговый список
            return resultList;
        }

        public void AddPortfolio(Portfolio portfolio)
        {
            using var db = new AppDBContext();
            db.Portfolios.Add(portfolio);
            db.SaveChanges();
        }

        public void RemovePortfolio(int portfolioId)
        {
            using var db = new AppDBContext();
            var portfolio = db.Portfolios.FirstOrDefault(p => p.Id == portfolioId);
            var transactions = db.Transactions.Where(t => t.Id == portfolioId).ToList();
            if (portfolio != null) {
                foreach (var transaction in transactions) 
                { 
                    db.Transactions.Remove(transaction);
                }
                db.Portfolios.Remove(portfolio);
                db.SaveChanges();
            }
        }

        public void UpdatePortfolioName(int portfolioId, string newName)
        {
            using var context = new AppDBContext();
            var portfolio = context.Portfolios.FirstOrDefault(p => p.Id == portfolioId);
            if (portfolio == null)
                return;

            portfolio.Name = newName;
            context.SaveChanges();
        }
        public Portfolio? GetPortfolioById(int portfolioId)
        {
            using var db = new AppDBContext();
            return db.Portfolios.FirstOrDefault(p => p.Id == portfolioId);
        }
    }
}
