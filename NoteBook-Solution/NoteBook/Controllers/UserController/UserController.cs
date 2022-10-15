using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteBook.Common.Interfaces.DataAccess;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Exstentions;

namespace NoteBook.Controllers.UserController
{
    [Route("notebook/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IPeopleAdminService _peopleService;
        public UserController (IPeopleAdminService peopleService)
        {
            _peopleService = peopleService;
        }

        //[HttpGet("about/{userId}")]
        //public  ActionResult GetAbout(Guid userId)
        //{
        //    var userResponse = _peopleService.GetById(userId);
        //   // return this.GetActionResult(userResponse, new  userResponse.Object);
        //}
    }
}
