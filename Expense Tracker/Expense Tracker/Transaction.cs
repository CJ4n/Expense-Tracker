using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public double Amount { get; set; }
        public Category Category { get; set; }
        public string Details { get; set; }
        public int UserId { get; set; }
        public Transaction(int transactionId, string accountId, DateTime transactionDate, double amount, Category category, string details, int userId)
        {
            TransactionId = transactionId;
            AccountId = accountId;
            TransactionDate = transactionDate;
            Amount = amount;
            Category = category;
            Details = details;
            UserId = userId;
        }
    }
    public  class TransactionManager
    {
        static public List<Transaction> transactions;
        public static List<Transaction> GetTransactions()
        {
            List<Transaction> result = new List<Transaction>();
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

                Transaction NewTransaction = new Transaction(id, tmp[1], date, amount, new Category(tmp[4]), tmp[5],userId);
                result.Add(NewTransaction);
            }
            transactions = result;
            return result;
        }
    }
}
