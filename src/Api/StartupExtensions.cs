using System;
using Npgsql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Repository;

namespace Api
{
    public static class StartupExtension
    {
        public static IServiceCollection AddNpgsqlConnection(this IServiceCollection services)
        {
            services.AddTransient<Lazy<NpgsqlConnection>>(sp =>
            {
                var appConfig = sp.GetService<IConfiguration>();
                return new Lazy<NpgsqlConnection>(() => ConnectionFactory.CreateDatabaseConnection(
                    appConfig.GetConnectionString("UserConnection")
                    ));
            });

            return services;
        }
    }
}