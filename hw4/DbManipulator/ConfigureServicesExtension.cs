﻿using Microsoft.Extensions.Configuration;

namespace DbManipulator
{
    public static class ConfigureServicesExtension
    {
        private const string ConnectionStringPattern =
            "Server={0}; Port={1};User Id={2};Password={3};Database={4}";

        public static string GetConnectionStringFromEnvironment(this IConfiguration config)
        {
            var port = config.GetValue("DB_PORT", "3306");
            var server = config.GetValue("DB_SERVER", "mariadb");
            var user = config.GetValue("DB_USER", "root");
            var pass = config.GetValue("DB_PASS", "admin");
            var dbName = config.GetValue("DB_NAME", "mariadbtest");

            return string.Format(ConnectionStringPattern, server, port, user, pass, dbName);
        }
    }
}