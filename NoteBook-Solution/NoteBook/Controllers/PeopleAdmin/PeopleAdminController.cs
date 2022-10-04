using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NoteBook.Controllers.PeopleAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("PeopleAdmin")]
    public class PeopleAdminController : ControllerBase
    {

    }
}
