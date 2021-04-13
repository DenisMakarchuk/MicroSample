using MediatR;
using UserManagement.Models;

namespace UserManagement.Services.Users.Queries.GetRoles
{
    public class GetRolesCommand : IRequest<RoleDto[]>
    {
    }
}
