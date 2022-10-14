using Microsoft.AspNetCore.Mvc;
using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Controllers.Attributes;
using NoteBook.Controllers.PeopleAdmin.DTOs;
using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;

namespace NoteBook.Controllers.PeopleAdmin
{
    [Route("notebook")]
    [ApiController]
    [AuthorizeRoles(Role.PeopleAdmin)]
    public class PeopleAdminController : ControllerBase
    {
        private readonly IPeopleAdminService _adminService;

        public PeopleAdminController (IPeopleAdminService peopleAdminService)
        {
            _adminService = peopleAdminService;
        }

        [HttpGet("users/{userRole}")]
        public async Task<ActionResult<UserDto>> GetUsersByRole (Role userRole)
        {
            var serviceResponse = await _adminService.FindUsersAsync(userRole);
            return ConertToActionResult(serviceResponse);
        }

        private ObjectResult ConertToActionResult (IResponse<List<Account>> response)
        {
            if (response.IsSuccess)
            {
                return StatusCode(response.StatuCode, response.Object!.Select(u => new UserDto
                {
                    Email = u.Email.Value,
                    LoginName = u.LoginName,
                    UserRole = u.Role,
                }));
            }
            else
            {
                return StatusCode(response.StatuCode, response.Message);
            }
        }
    }
}
