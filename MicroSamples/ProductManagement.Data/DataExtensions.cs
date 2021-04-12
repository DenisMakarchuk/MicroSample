using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProductManagement.Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddMicroserviceDbContext<IProductManagementContext, ProductManagementContext>(config.GetDbConnection());

            return services;
        }
    }
}
