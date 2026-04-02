//Using System.Transactions;
using InvestingManagerApp.Data;
using InvestingManagerApp.Models;
using System.Security.Cryptography.X509Certificates;

namespace InvestingManagerApp.Services
{
    public class TransactionService
    {
        // сервис для работы с транзакциями
        // 1. получение всех транзакций по портфелю или пользователю 
        // 2. Добавление транзакций
        // 3. Удаление транзакций
        // 4. Редактирование транзакций

        public List<Transaction> GetTransactionsByPerson(int personId) {

            using var db = new AppDBContext();                                          // контекст базы данных
            var portfolios = db.Portfolios.Where(p => p.PersonId == personId).ToList(); // сбор всех портфелей по айди человека
            List<Transaction> transactions = new List<Transaction>();                   // создание результирующего списка

            // каждый портфель из списка просматривается на наличие транзакций
            foreach (var portfolio in portfolios)
            {
                transactions.AddRange(GetTransactionsByPortfolio(portfolio.Id));    // все транзакции из портфеля, добавляются в общий список транзакций по пользователю
            }
            return transactions;

        }

        public Transaction GetTransactionById(int transactionId)
        {
            using var db = new AppDBContext();
            var transaction = db.Transactions.First(t => t.Id == transactionId);
            return transaction;
        }

        public List<Transaction> GetTransactionsByPortfolio(int portfolioId)
        {

            using var db = new AppDBContext();                                                      // контекст базы данных
            var transactions = db.Transactions.Where(p => p.PortfolioId == portfolioId).ToList();   // сбор транзакций по id портфеля
            return transactions;

        }

        public void RemoveTransaction(int transactionId)
        {

            using var db = new AppDBContext();                                              // контекст базы данных
            var transaction = db.Transactions.FirstOrDefault(p => p.Id == transactionId);   // находим старую запись по транзакции

            if (transaction != null)
            {
                db.Transactions.Remove(transaction);        // удаляем запис в контексте
                db.SaveChanges();                           // сохраняем изменения
            }
        }

        public void AddTransaction(Transaction transaction)
        {
            using var db = new AppDBContext();  // контекст базы данных
            
            db.Transactions.Add(transaction);
            db.SaveChanges();

        }

        public void EditTransaction(Transaction newTransaction)
        { 
            // поскольку я буду только редактировать некоторые данные,
            // то старый id я могу просто обнаружить по id нового,
            // так как у них одинаковый id

            using var db = new AppDBContext();                              // создаёт контекст базы данных
            var oldTransaction = db.Transactions.FirstOrDefault(p => p.Id == newTransaction.Id);    // находит старую транзакцию по новому id

            if (oldTransaction == null)
                return;

            // каждое поле старой транзакции перезаписывается на значения новой транзакции внутри контекста
            oldTransaction.Type = newTransaction.Type;                     
            oldTransaction.PortfolioId = newTransaction.PortfolioId;
            oldTransaction.SecurityId = newTransaction.SecurityId;
            oldTransaction.Date = newTransaction.Date;
            oldTransaction.Amount = newTransaction.Amount;
            oldTransaction.PricePerUnit = newTransaction.PricePerUnit;

            db.SaveChanges();                                               // сохраняет изменения из контекста в базе
        }

    }
}
