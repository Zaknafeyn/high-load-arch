using Microsoft.Extensions.Configuration;

namespace DbManipulator
{
    public static class ConfigureServicesExtension
    {
        private const string ConnectionStringPattern =
            "Server={0}; Port={1};User Id={2};Password={3};Database={4};ConvertZeroDateTime=true";

        private static string _connectionString = "";

        public static string GetConnectionStringFromEnvironment(this IConfiguration config)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {

                var port = config.GetValue("DB_PORT", "3306");
                var server = config.GetValue("DB_SERVER", "mariadb");
                var user = config.GetValue("DB_USER", "root");
                var pass = config.GetValue("DB_PASS", "admin");
                var dbName = config.GetValue("DB_NAME", "mariadbtest");

                _connectionString = string.Format(ConnectionStringPattern, server, port, user, pass, dbName);
            }

            return _connectionString;
        }
    }
}