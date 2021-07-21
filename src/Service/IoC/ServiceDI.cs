using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Services;
using System.Linq;

namespace Service.IoC
{
    public static class ServiceDI
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}