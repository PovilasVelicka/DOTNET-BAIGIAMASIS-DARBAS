namespace NoteBook.Controllers.NotesController.DTOs
{
    public class CreateNoteDto
    {
        public string Title { get; set; } = null!;
        public string CategoryName { get; set; } =string.Empty;
        public string NoteText { get; set; } = null!;
        public DateTime? ReminderDate { get; set; } = null;
    }
}
