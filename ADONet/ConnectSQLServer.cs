using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONet
{
    public static class SQLServerConnector
    {
        public static void ConnectSQLServer()
        {
            const string connectionString =
            "Data Source=HAQUE;Initial Catalog=WorldPopulation;"
            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            const string queryString =
                "SELECT CountryID, CountryName, CountryCode from [dbo].[WorldCountry]"
                    + "WHERE CountryID > @countryId "
                    + "ORDER BY CountryName DESC;";


            // Specify the parameter value.
            const int paramValue = 0;

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = new(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new(queryString, connection);
                command.Parameters.AddWithValue("@countryId", paramValue);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"\t{reader[0]}\t{reader[1]}\t{reader[2]}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }

        }

    }
}
