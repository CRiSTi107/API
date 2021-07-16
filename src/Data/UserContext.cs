using Api.Entities;
using Microsoft.EntityFrameworkCore;
using Dapper.FastCrud;

namespace Api.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt) : base(opt)
        {
            OrmConfiguration.DefaultDialect = SqlDialect.PostgreSql;
        }

        public DbSet<User> User { get; set; }
    }
}