using System;

using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace MMABooksDBClasses
{
    public static class MMABooksDB
    {
        public static MySqlConnection GetConnection()
        {
            string connectionString = GetMySqlConnectionString();
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;

        }

        private static string GetMySqlConnectionString()
        {
            string folder = System.AppContext.BaseDirectory;
            var builder = new ConfigurationBuilder()
                    .SetBasePath(folder)
                    .AddJsonFile("mySqlSettings.json", optional: true, reloadOnChange: true);

            string connectionString = builder.Build().GetConnectionString("mySql");

            return connectionString;
        }
    }
}
