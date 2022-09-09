using System;
using System.Data;
using System.Data.SqlClient;

namespace SpecFlowAutomation.Specs.Drivers
{
    public static class DbConnection
    {
        private static string? GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "kurtulusakkaya.database.windows.net";
            builder.UserID = "*********";
            builder.Password = "*********";
            builder.InitialCatalog = "*********";

            return builder.ConnectionString;
        }


        public static DataTable RunQuery(string sql, string? connStr = null)
        {
            if (connStr == null)
            {
                connStr = DefaultSettings.DB_TEST;
            }

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    sqlDataAdapter.Fill(dataTable);
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return dataTable;
        }


        public static string GetUserIdFromDatabase(string userMail)
        {
            try
            {
                DataTable dt = RunQuery("SELECT TOP 1 [Id] FROM [dbo].[UserAccounts] WHERE Email='" + userMail + "'");
                var s = dt.Rows[0]["Id"].ToString();
                return s!;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}