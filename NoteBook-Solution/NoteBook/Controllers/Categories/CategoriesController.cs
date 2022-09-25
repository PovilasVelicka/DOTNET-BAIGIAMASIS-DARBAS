using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NoteBook.Controllers.Categories
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok( );
        }
    }
}
