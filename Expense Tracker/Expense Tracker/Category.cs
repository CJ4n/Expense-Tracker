using System.Collections.ObjectModel;

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
        static public ObservableCollection<Category> categories { get; set; }

        static public ObservableCollection<Category> GetCategories()
        {
            ObservableCollection<Category> result = new ObservableCollection<Category>();
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
