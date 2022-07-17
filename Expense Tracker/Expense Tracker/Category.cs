using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    public class Category
    {
        public string Name { get; set; }
        public Category(string name)
        {
            Name = name;
        }
        //static public List<string> GetCategories()
        //{
        //    List<string> result = new List<string>();
        //    var list = SQL.GetCategories();
        //    foreach(var s in list)
        //    {
        //        var splited = s.Split(';');
        //        result.Add(splited[0]);
        //    }
        //    return result;
        //}
    }

    public class CategoryManager
    {
        static public List<Category> categories;

        public static List<Category> GetCategories()
        {
            List<Category> result = new List<Category>();
            var categoriesString = SQL.GetCategories();
            foreach (var c in categoriesString)
            {
                var tmp = c.Split(';');
                Category NewCategory = new Category(tmp[0]);
                result.Add(NewCategory);
            }
            categories = result;
            return result;
        }

    }
}
