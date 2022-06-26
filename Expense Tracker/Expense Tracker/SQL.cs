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
        static private string connectionString = "Server=CYANPC;Database=EXEPNSES;User Id=sa;Password=123;";
        static public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
