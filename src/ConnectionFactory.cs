using Npgsql;
using Dapper.FastCrud;

namespace Api
{
    public static class ConnectionFactory
    {
        public static NpgsqlConnection CreateDatabaseConnection(string DatabaseConnectionString)
        {
            OrmConfiguration.DefaultDialect = SqlDialect.PostgreSql;

            var connection = new NpgsqlConnection(DatabaseConnectionString);
            connection.Open();

            return connection;
        }
    }

}