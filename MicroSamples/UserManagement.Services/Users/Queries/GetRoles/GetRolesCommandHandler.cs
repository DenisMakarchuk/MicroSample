using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.Data;
using UserManagement.Models;

namespace UserManagement.Services.Users.Queries.GetRoles
{
    public class GetRolesCommandHandler : IRequestHandler<GetRolesCommand, RoleDto[]>
    {
        private readonly IdentityContext _context;

        public GetRolesCommandHandler(IdentityContext context)
        {
            _context = context;
        }

        public async Task<RoleDto[]> Handle(GetRolesCommand request, CancellationToken cancellationToken)
        {
            return await _context.Roles.Select(_ => new RoleDto { Name = _.Name }).ToArrayAsync(cancellationToken);
        }
    }
}
