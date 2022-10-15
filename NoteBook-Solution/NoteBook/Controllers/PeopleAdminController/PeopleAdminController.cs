using Microsoft.AspNetCore.Mvc;
using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Controllers.Attributes;
using NoteBook.Controllers.PeopleAdminController.DTOs;
using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;
using NoteBook.Exstentions;

namespace NoteBook.Controllers.PeopleAdminController
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

        [HttpGet("accounts/role/{userRole}")]
        public async Task<ActionResult> GetUsersByRole (Role userRole)
        {
            var serviceResponse = await _adminService.FindUsersAsync(userRole);
            return this.GetActionResult(
                serviceResponse,
                serviceResponse
                .Object!
                .Select(u => new UserDto(u))
                .ToList( )) ;
        }

        [HttpGet("accounts/substring/{substring}")]
        public async Task<ActionResult> GetUsersByName (string substring)
        {
            var serviceResponse = await _adminService.FindUsersAsync(substring);
            return this.GetActionResult(
                serviceResponse,
                serviceResponse
                .Object?
                .Select(u => new UserDto(u))
                .ToList( ));
        }

        [HttpPatch("account/change-role")]
        public async Task<ActionResult> UpdateUserRole ([FromBody] ChangeRoleDto userRoleDto)
        {
            var serviceResponse = await _adminService.ChangeUserRoleAsync(userRoleDto.UserLogin, userRoleDto.Role);
            return this.GetActionResult(serviceResponse, new UserDto( serviceResponse.Object));
        }      
    }
}
