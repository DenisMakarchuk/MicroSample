using Microsoft.EntityFrameworkCore;
using ProductManagement.Data.Configurations;
using ProductManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Data
{
    public class ProductManagementContext : DbContext, IProductManagementContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ProductManagementContext(DbContextOptions<ProductManagementContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new AccountConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
        }

        public async Task<int> SaveChanges(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
