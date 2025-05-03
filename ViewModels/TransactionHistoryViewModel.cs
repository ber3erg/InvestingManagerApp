using InvestingManagerApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InvestingManagerApp.ViewModels
{
    public class TransactionHistoryViewModel
    {
        public ObservableCollection<Transaction> Transactions { get; set; }

        public TransactionHistoryViewModel() { 
            Transactions = new ObservableCollection<Transaction>
            {
                new Transaction()
            }
                ;
        }
        public TransactionHistoryViewModel(List<Transaction> transactions)
        {
            Transactions = new ObservableCollection<Transaction>(transactions);
        }
    }
}
