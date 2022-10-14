using Microsoft.AspNetCore.Mvc;
using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Controllers.Attributes;
using NoteBook.Controllers.PeopleAdmin.DTOs;
using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;

namespace NoteBook.Controllers.PeopleAdmin
{
    [Route("notebook/admin")]
    [ApiController]
    [AuthorizeRoles(Role.PeopleAdmin)]
    public class PeopleAdminController : ControllerBase
    {
        private readonly IPeopleAdminService _adminService;

        public PeopleAdminController (IPeopleAdminService peopleAdminService)
        {
            _adminService = peopleAdminService;
        }

        [HttpGet("users/by-role/{userRole}")]
        public async Task<ActionResult> GetUsersByRole (Role userRole)
        {
            var serviceResponse = await _adminService.FindUsersAsync(userRole);
            return ConvertToActionResult(serviceResponse);
        }

        [HttpGet("users/by-name/{userName}")]
        public async Task<ActionResult> GetUsersByName (string userName)
        {
            var serviceResponse = await _adminService.FindUsersAsync(userName);
            return ConvertToActionResult(serviceResponse);
        }

        [HttpPatch("users/change-role")]
        public async Task<ActionResult> UpdateUserRole ([FromBody] ChangeRoleDto userRoleDto)
        {
            var serviceResponse = await _adminService.ChangeUserRoleAsync(userRoleDto.UserLogin, userRoleDto.Role);
            return ConvertToActionResult(serviceResponse);
        }

        private ObjectResult ConvertToActionResult (IResponse<List<Account>> response)
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

        private ObjectResult ConvertToActionResult (IResponse<Account> response)
        {
            if (response.IsSuccess)
            {
                return StatusCode(response.StatuCode, new UserDto
                {
                    Email = response.Object!.Email.Value,
                    LoginName = response.Object!.LoginName,
                    UserRole = response.Object!.Role,
                });
            }
            else
            {
                return StatusCode(response.StatuCode, response.Message);
            }
        }
    }
}
