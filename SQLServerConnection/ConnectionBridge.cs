using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerConnection
{
    public static class ConnectionBridge
    {
        public async static void ConnectToDB()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "HAQUE",
                UserID = "sa",
                Password = "12345678",
                IntegratedSecurity = false,
                Encrypt = true,
                TrustServerCertificate = true,
                InitialCatalog = "WorldPopulation"
            };

            var connectionString = builder.ConnectionString;

            try
            {
                await using var connection = new SqlConnection(connectionString);
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                await connection.OpenAsync();

                var sql = "SELECT name, collation_name FROM sys.databases";
                await using var command = new SqlCommand(sql, connection);
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                }
            }
            catch (SqlException e) //--when (e.Number == /* specific error number */)
            {
                Console.WriteLine($"SQL Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                connectionString = null;
            }


            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }
    }
}


