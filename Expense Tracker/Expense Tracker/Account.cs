using System;
using System.Collections.ObjectModel;

namespace Expense_Tracker
{
    public class Account
    {
        public string AccountId { get; set; }
        public float Balance { get; set; }
        public Account(string accountId, float balance)
        {
            this.AccountId = accountId;
            this.Balance = balance;
        }
        //public List<string> GetAccount()
        //{
        //    List<string> result = new List<string>();
        //    var list = SQL.GetAccount();
        //    foreach (var s in list)
        //    {
        //        var splited = s.Split(';');
        //        result.Add(splited[0] + " (" + splited[1] + " zł)");
        //    }

        //    return result;
        //}
    }

    public class AccountManager
    {
        static public ObservableCollection<Account> accounts;
        public static ObservableCollection<Account> GetAccounts()
        {
            ObservableCollection<Account> result = new ObservableCollection<Account>();
            var accountsString = SQL.GetAccounts();
            foreach (var a in accountsString)
            {
                var tmp = a.Split(';');

                if (!float.TryParse(tmp[1], out float balance))
                {
                    throw new Exception("Invalid data from database");

                }
                Account NewAccount = new Account(tmp[0], balance);
                result.Add(NewAccount);
            }
            accounts = result;
            return result;
        }
    }
}
