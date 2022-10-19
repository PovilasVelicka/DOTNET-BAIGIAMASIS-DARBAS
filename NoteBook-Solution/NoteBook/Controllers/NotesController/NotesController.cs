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
            return this.GetActionResult(result, result.Object?.Select(n => new NoteDto(n)));
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
            return this.GetActionResult(result, result.Object?.Select(n => new NoteDto(n)));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNoteAsync (CreateNoteDto createNoteDto)
        {
            var userGuid = this.GetUserGuid( );
            var result = await _notesService.CreateNoteAsync(
                userGuid,
                title: createNoteDto.Title,
                noteText: createNoteDto.NoteText,
                categoryName: createNoteDto.CategoryName,
                setReminder: createNoteDto.ReminderDate
                );

            return this.GetActionResult(result, new NoteDto(result.Object!));
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateNoteAsync (int id, NoteDto noteDto)
        {
            var userGuid = this.GetUserGuid( );
            var result = await _notesService.UpdateNoteAsync(
                userGuid,
                noteId: id,
                title: noteDto.Title,
                noteText: noteDto.NoteText,
                categoryName: noteDto.CategoryName,
                priority: noteDto.Priority,
                reminderDate: noteDto.Reminder,
                useReminder: noteDto.UseReminder,
                complete: noteDto.Complete,
                fill: noteDto.Fill,
                color: noteDto.Color
                );

            return this.GetActionResult(result, new NoteDto(result.Object!));
        }

        [HttpPatch("delete/{id}")]
        public async Task<IActionResult> DeleteNoteAsync (int id)
        {
            var userGuid = this.GetUserGuid( );
            var result = await _notesService.DeleteNoteAsync(userGuid, id);
            return this.GetActionResult(result, new NoteDto(result.Object));
        }

        [HttpPatch("update-bg-image/{id}")]
        public async Task<IActionResult> UpdateBgImageAsync (int noteId, [FromForm] ImageUploadDto request)
        {
            using var memoryStream = new MemoryStream( );
            request.Image.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray( );

            var userGuid = this.GetUserGuid( );
            var result = await _notesService.UpdateBgImageAsync(userGuid, noteId, imageBytes, request.Image.ContentType, request.Image.FileName);

            return this.GetActionResult(result, new NoteDto(result.Object));
        }

        [HttpPatch("remove-bg-image/{id}")]
        public async Task<IActionResult> RemoveBgImageAsync (int id)
        {
            var userGuid = this.GetUserGuid( );
            var result = await _notesService.RemoveBgImageAsync(userGuid, id);
            return this.GetActionResult(result, new NoteDto(result.Object));
        }
    }
}
