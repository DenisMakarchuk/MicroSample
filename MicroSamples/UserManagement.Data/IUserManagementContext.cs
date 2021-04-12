using System.Threading;
using System.Threading.Tasks;

namespace UserManagement.Data
{
    public interface IUserManagementContext
    {
        Task<int> SaveChanges(CancellationToken cancellationToken);
    }
}
