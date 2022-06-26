using System;
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
            List<string> categories = new List<string>(); 
            using (SqlConnection connection =SQL.GetSqlConnection())
            {
            string queryString = "SELECT * FROM Category";
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        //Console.WriteLine(String.Format("{0}, {1}",
                        //reader["tPatCulIntPatIDPk"], reader["tPatSFirstname"]));// etc
                        categories.Add(reader["CategoryName"].ToString());
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            return categories;
        }
    }
}
