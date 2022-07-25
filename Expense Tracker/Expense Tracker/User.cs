using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Expense_Tracker
{
    public class User
    {
        string name;
        string surname;
        int id;
        public int Id { get { return id; } }
        public string Name { get { return name; } }
        public string Surname { get { return surname; } }
        public User(int i, string n, string sn)
        {
            name = n;
            surname = sn;
            id = i;
        }
    }
    public class UserManager
    {
        static public ObservableCollection<User> users;
        static public ObservableCollection<User> GetUsers()
        {
            ObservableCollection<User> result = new ObservableCollection<User>();
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
        static public User GetUserById(int id)
        {
            var user = users.Where(u => u.Id == id).First();
            return user;
        }
    }
}
