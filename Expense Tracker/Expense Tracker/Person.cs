using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    public class Person
    {
        string name;
        string surname;
        int id;
        public Person(string n,string sn,int i)
        {
            name = n;
            surname = sn;
            id = i;
        }
       
        
    }
    public static class PeopleManager
    {
        public static List<Person> people = new List<Person>();
        static public void CreatePeopleList()
        {
            List<string> list = SQL.GetPerson();
            foreach (var s in list)
            {
                var splited = s.Split(';');
                people.Add(new Person(splited[0], splited[1], Convert.ToInt32(splited[2])));
            }
           
        }
        static List<Person> GetPeople()
        {
            return people;
        }
    }
}
