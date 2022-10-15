using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteBook.Controllers.Attributes;
using NoteBook.Entity.Enums;

namespace NoteBook.Controllers.CategoriesController
{
    [Authorize]
    [Route("notebook/categories")]
    [ApiController]
    [AuthorizeRoles(Role.StandartUser, Role.PeopleAdmin)]
    public class CategoriesController : ControllerBase
    {
        [HttpGet("category/{id}")]
        public IActionResult Get (int id)
        {
            return Ok( );
        }
    }
}
