using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    public class Account
    {
        private string AccountId;
        private float Balance;
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
    
    public  class AccountManager
    {
        static public List<Account> accounts;
        public static List<Account> GetAccounts()
        {
            List<Account> result = new List<Account>();
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
