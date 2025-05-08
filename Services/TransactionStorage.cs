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
        private static List<Transaction> transactions = new List<Transaction>();

        public static void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }

        public static void RemoveTransaction(int transactionId)
        {
            foreach (Transaction transaction in transactions)
            {
                if (transaction.Id == transactionId)
                    transactions.Remove(transaction);
            }
        }

        public static List<Transaction> GetTransactionsByPortfolioId(int portfolioId)
        {
            List<Transaction> result = new List<Transaction>();
            foreach (Transaction transaction in transactions)
            {
                if (transaction.portfolioId == portfolioId)
                {
                    result.Add(transaction);
                }
            }
            return result;
        }

    }
}
