using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Dapper.FastCrud;

namespace Repository.Repositories
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