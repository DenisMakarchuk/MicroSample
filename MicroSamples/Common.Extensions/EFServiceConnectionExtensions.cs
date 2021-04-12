using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EFServiceConnectionExtensions
    {
		public static IServiceCollection AddMicroserviceDbContext<TContextInterface, TContextImplementation>(
			this IServiceCollection service,
			string databaseConnection)
			where TContextInterface : class
			where TContextImplementation : DbContext, TContextInterface
		{
			service.AddDbContext<TContextImplementation>(options =>
				options.UseSqlServer(databaseConnection,
					b => b.MigrationsAssembly(typeof(TContextImplementation).Assembly.FullName)));

			service.AddScoped<TContextInterface, TContextImplementation>();

			return service;
		}
	}
}
