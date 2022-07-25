using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
                                    tmp += reader[i].ToString() + ";";

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
        static public List<string> GetAccounts()
        {
            return ExecuteQuery("SELECT * FROM Account");
        }
        static public List<string> GetUsers()
        {
            return ExecuteQuery("SELECT * FROM Person");
        }
        static public List<string> GetTransactions()
        {
            return ExecuteQuery("SELECT * FROM [Transaction]");
        }

        static public void AddTransaction(string accountID, DateTime transactionDate, int amount, Category category,
            string description, int buyerID, string transactionType)
        {
            using (SqlConnection connection = GetSqlConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO [Transaction] (AccountId, TransactionDate, Amount, CategoryName, [Description] ," +
                    " BuyerID,Transaction_Type) VALUES (@AccountId, @TransactionDate, @Amount, @CategoryId,@Description, @BuyerID, @Transaction_Type)", connection))
                {
                    command.Parameters.AddWithValue("@AccountId", accountID);
                    command.Parameters.AddWithValue("@TransactionDate", transactionDate.Date);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@CategoryId", category.Name);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@BuyerID", 1);
                    command.Parameters.AddWithValue("@Transaction_Type", transactionType);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}

