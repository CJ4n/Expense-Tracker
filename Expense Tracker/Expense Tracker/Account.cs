using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    static class Account
    {
        static public List<string> GetAccount()
        {
            List<string> result = new List<string>();
            var list = SQL.GetAccount();
            foreach (var s in list)
            {
                var splited = s.Split(';');
                result.Add(splited[0]+" (" + splited[1] + " zł)");
            }

            return result;
        } 
    }
}
