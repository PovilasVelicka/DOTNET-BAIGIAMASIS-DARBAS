using Microsoft.AspNetCore.Mvc;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Exstentions;

namespace NoteBook.Controllers.NotesController
{
    [Route("notebook/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;
        public NotesController (INotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllAsync ()
        {
            var userGuid = this.User.GetUserGuid();
            var result = await _notesService.GetAllAsync(userGuid);
            return this.GetActionResult(result, result.Object);
        }
    }
}
