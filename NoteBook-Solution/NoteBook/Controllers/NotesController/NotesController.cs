using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Controllers.NotesController.DTOs;
using NoteBook.Exstentions;

namespace NoteBook.Controllers.NotesController
{
    [Route("notebook/notes")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;
        public NotesController (INotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpGet("active-notes")]
        public async Task<IActionResult> GetActiveNotesAsync ( )
        {
            var userGuid = this.GetUserGuid( );
            var result = await _notesService.GetNotesAsync(userGuid, false);
            return this.GetActionResult(result, result.Object?.Select(n => new NoteDto(n)));
        }

        [HttpGet("active-reminders")]
        public async Task<IActionResult> GetActiveRemindersAsync ( )
        {
            var userGuid = this.GetUserGuid( );
            var result = await _notesService.GetRemindersAsync(userGuid, false);
            return this.GetActionResult(result, result.Object?.Select(n => new ReminderDto(n)));
        }

        [HttpGet("active-notes/{category}")]
        public async Task<IActionResult> GetActiveNotesAsync (string category)
        {
            var userGuid = this.GetUserGuid( );
            var result = await _notesService.GetNotesAsync(userGuid, false, category);
            return this.GetActionResult(result, result.Object?.Select(n => new NoteDto(n)));
        }

        [HttpGet("active-reminders/{category}")]
        public async Task<IActionResult> GetActiveRemindersAsync (string category)
        {
            var userGuid = this.GetUserGuid( );
            var result = await _notesService.GetRemindersAsync(userGuid, false, category);
            return this.GetActionResult(result, result.Object?.Select(n => new ReminderDto(n)));
        }

    
    }
}
