using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestingManagerApp.Models;

namespace InvestingManagerApp.Services
{
    public static class TransactionStorage
    {
        public static List<Transaction> Transactions { get; private set; } = JsonDataStorage.GetTransactionsFromJsonFile();

        public static void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
            JsonDataStorage.AddTransactionToJsonFile(transaction);
        }

        public static void RemoveTransaction(int transactionId)
        {
            foreach (Transaction transaction in Transactions)
            {
                if (transaction.Id == transactionId)
                {
                    Transactions.Remove(transaction);
                    JsonDataStorage.DeleteTransactionFromJsonFile(transaction);
                }
            }
        }

        public static List<Transaction> GetTransactionsByPortfolioId(int portfolioId)
        {
            List<Transaction> result = new List<Transaction>();
            foreach (Transaction transaction in Transactions)
            {
                if (transaction.PortfolioId == portfolioId)
                {
                    result.Add(transaction);
                }
            }
            return result;
        }

        public static List<Transaction> GetTransactionsByUserId(int userId)
        {

            List<Portfolio> userPortfolios = PortfolioStorage.GetPortfoliosByUserId(userId);
            List<Transaction> result = new List<Transaction>();

            foreach (Portfolio portfolio in userPortfolios)
            {
                int portfolioId = portfolio.Id;
                foreach (Transaction transaction in Transactions)
                {
                    if (transaction.PortfolioId == portfolioId)
                    {
                        result.Add(transaction);
                    }
                }
            }
            return result;
        }

        public static List<int> GetSecuritiesByPortfelId(int portfolioId)
        {
            // метод возвращает список идентификаторов ценных бумаг
            // для начала получаем все транзакции по портфелю и проходимся по каждой
            // затем с помощью условия добавляем каждый id ценной бумаги в список
            List<int> result = new List<int>();
            foreach (Transaction transaction in GetTransactionsByPortfolioId(portfolioId))
            {
                if (!result.Contains(transaction.SecurityId)) {
                    result.Add(transaction.SecurityId);
                }
            }
            return result;
        }
    }
}
