using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Repositories;
using System.Linq;

namespace Repository.IoC
{
    public static class RepositoryDI
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, NpgsqlUserRepository>();
        }
    }
}