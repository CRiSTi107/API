using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Repository
{
    public abstract class BaseRepository : IDisposable
    {
        private Lazy<NpgsqlConnection> _conn;

        public BaseRepository(Lazy<NpgsqlConnection> conn)
        {
            _conn = conn;
        }

        public NpgsqlConnection DatabaseConnection => _conn.Value;

        public void Dispose()
        {
            if (_conn.IsValueCreated == true)
                _conn.Value.Dispose();
        }
    }
}