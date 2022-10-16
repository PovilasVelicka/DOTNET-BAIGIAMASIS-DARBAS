using NoteBook.Entity.Models;

namespace NoteBook.Controllers.NotesController.DTOs
{
    public class ReminderDto : NoteDto
    {
        public DateTimeOffset? Reminder { get; set; }
        public bool UseReminder { get; set; }

        public ReminderDto ( ) { }
        public ReminderDto (Note note) : base(note)
        {
            Reminder = note.Reminder;
            UseReminder = note.UseReminder;
        }
    }
}
