using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Data
{
    public interface IProductManagementContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Account> Accounts { get; set; }
        DbSet<Order> Orders { get; set; }

        Task<int> SaveChanges(CancellationToken cancellationToken);
    }
}
