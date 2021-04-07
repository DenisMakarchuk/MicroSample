using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Data;

namespace UserManagement.Services
{
    public static class ManagersExtensions
    {
        public static IServiceCollection AddManagersServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDataServices(config);
            services.AddAutoMapper(typeof(MapperLogicModule));

            return services;
        }
    }
}
