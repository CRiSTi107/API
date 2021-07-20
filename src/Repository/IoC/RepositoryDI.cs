using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Repository.IoC
{
    public static class RepositoryDI
    {
        public static void AddRepository(this IServiceCollection services)
        {
            var types = from type in typeof(BaseRepository).Assembly.GetTypes()
                        where type.IsClass
                        select type;



        }
    }
}