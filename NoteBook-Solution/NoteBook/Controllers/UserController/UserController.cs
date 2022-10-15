using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NoteBook.Controllers.UserController
{
    [Route("notebook/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
    }
}
