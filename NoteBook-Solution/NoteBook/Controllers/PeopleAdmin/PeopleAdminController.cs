using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteBook.Entity.Enums;

namespace NoteBook.Controllers.PeopleAdmin
{
    [Route("notebook")]
    [ApiController]
    [AuthorizeRoles(Role.PeopleAdmin)]
    public class PeopleAdminController : ControllerBase
    {

    }
}
