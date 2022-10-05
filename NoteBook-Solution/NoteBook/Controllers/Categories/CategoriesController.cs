using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteBook.Entity.Enums;
using System;

namespace NoteBook.Controllers.Categories
{
    [Authorize]
    [Route("notebook")]
    [ApiController]
    [AuthorizeRoles(Role.StandartUser, Role.PeopleAdmin)]
    public class CategoriesController : ControllerBase
    {
        [HttpGet("category/{id}")]
        public IActionResult Get(int id)
        {
            return Ok( );
        }
    }
}
