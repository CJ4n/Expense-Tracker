using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    public class User
    {
        string name;
        string surname;
        int id;
        public User(int i, string n, string sn)
        {
            name = n;
            surname = sn;
            id = i;
        }
    }
     public class UserManager
    {
      static public List<User> users;
        static public List<User> GetUsers()
        {
            List<User> result =new List<User>();
            var usersString = SQL.GetUsers();
            foreach (var u in usersString)
            {
                var tmp = u.Split(';');
                if (!int.TryParse(tmp[0], out int id))
                {
                    throw new Exception("Invalid data from database");

                }
                User NewUser = new User(id, tmp[1], tmp[2]);
                result.Add(NewUser);
            }
            users = result;
            return result;
        }
    }
}
