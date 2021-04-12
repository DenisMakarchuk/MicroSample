using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProductManagement.Data
{
    public class ProductManagementDbContextFactory : IDesignTimeDbContextFactory<ProductManagementContext>
    {
        public ProductManagementContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductManagementContext>();
            optionsBuilder.UseSqlServer("Server=localhost;database=ProductManagement;user=test;password=test");
            return new ProductManagementContext(optionsBuilder.Options);
        }
    }
}
