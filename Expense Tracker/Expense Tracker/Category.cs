﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    static class Category
    {
        static public List<string> GetCategories()
        {
            List<string> result = new List<string>();
            var list = SQL.GetCategories();
            foreach(var s in list)
            {
                var splited = s.Split(';');
                result.Add(splited[0]);
            }
            return result;
        }
    }
}
