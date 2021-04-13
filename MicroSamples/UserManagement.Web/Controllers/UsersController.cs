using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.Services.Users.Queries.GetRoles;

namespace UserManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get Roles.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <response code="200">Returns all roles.</response>
        [HttpGet("roles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RoleDto[]>> GetRoles(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetRolesCommand(), cancellationToken));
        }
    }
}
