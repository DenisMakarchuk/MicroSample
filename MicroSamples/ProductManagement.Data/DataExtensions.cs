using Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProductManagement.Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(typeof(IDesignTimeDbContextFactory<ProductManagementContext>), typeof(DbContextFactory<ProductManagementContext>));

            services.AddMicroserviceDbContext<IProductManagementContext, ProductManagementContext>(
                config.GetDbConnection(typeof(ProductManagementContext).Name.Replace("Context", "")));

            return services;
        }
    }
}
