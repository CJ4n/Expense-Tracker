using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    static class SQL
    {
        static private string connectionString = "Server=CYANPC;Database=EXEPENSES;User Id=sa;Password=123;";
        static public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        static private List<string> ExecuteQuery(string query)
        {
            List<string> result = new List<string>();
            using (SqlConnection connection = GetSqlConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                string tmp = "";
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    tmp += reader[i].ToString()+";";
                             
                                }
                              
                                result.Add(tmp);
                            }
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                }
            }
            return result;
        }

        static public List<string> GetCategories()
        {
            return ExecuteQuery("SELECT * FROM Category");
        }
        static public List<string> GetAccount()
        {
            return ExecuteQuery("SELECT * FROM Account");
        }
        static public List<string> GetPerson()
        {
            return ExecuteQuery("SELECT Name,Surname FROM Person");
        }
        
      
    }
}

