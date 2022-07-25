using System;
using System.Collections.ObjectModel;

namespace Expense_Tracker
{
    public class Transaction
    {
        public int TransactionId { get; private set; }
        public string AccountId { get; private set; }

        //private DateTime _transactionDate;
        public DateTime TransactionDate { get; private set; }

        public double Amount { get; private set; }
        public Category Category { get; private set; }
        public string Details { get; private set; }
        public int BuyerID { get; private set; }
        public Transaction(int transactionId, string accountId, DateTime transactionDate, double amount, Category category, string details, int userId)
        {
            TransactionId = transactionId;
            AccountId = accountId;
            TransactionDate = transactionDate;
            Amount = amount;
            Category = category;
            Details = details;
            BuyerID = userId;
        }
    }
    public class TransactionManager
    {
        static public ObservableCollection<Transaction> transactions;
        public static ObservableCollection<Transaction> GetTransactions()
        {
            ObservableCollection<Transaction> result = new ObservableCollection<Transaction>();
            var transactionsString = SQL.GetTransactions();
            foreach (var t in transactionsString)
            {
                var tmp = t.Split(';');
                if (!int.TryParse(tmp[0], out int id))
                {
                    throw new Exception("Invalid data from database");

                }
                if (!DateTime.TryParse(tmp[2], out DateTime date))
                {
                    throw new Exception("Invalid data from database");

                }
                if (!float.TryParse(tmp[3], out float amount))
                {
                    throw new Exception("Invalid data from database");

                }
                // TODO: how to parse category???
                //if (!int.TryParse(tmp[4], out int categoryname))
                //{
                //    throw new Exception("Invalid data from database");

                //} 
                if (!int.TryParse(tmp[6], out int userId))
                {
                    throw new Exception("Invalid data from database");

                }

                Transaction NewTransaction = new Transaction(id, tmp[1], date, amount, new Category(tmp[4]), tmp[5], userId);
                result.Add(NewTransaction);
            }
            transactions = result;
            return result;
        }
    }
}
