using NoteBook.Entity.Models;

namespace NoteBook.Controllers.NotesController.DTOs
{
    public class NoteDto
    {
        public int Id { get; }
        public string? Title { get; set; } = null!;
        public string? CategoryName { get; set; } = null!;
        public string? NoteText { get; set; } = null!;
        public string? Fill { get; set; } = null!;
        public string? Color { get; set; } = null!;
        public string? Priority { get; set; } = null!;
        public DateTimeOffset? Reminder { get; set; }
        public bool? UseReminder { get; set; }
        public bool? Complete { get; set; }
        public int? ImageId { get; set; }
        public BgImageDto? BackGround { get; }
        public NoteDto ( ) { }
        public NoteDto (Note? note)
        {
            if (note == null) return;
            Id = note.Id;
            Title = note.Title;
            CategoryName = note.Category?.CategoryName ?? "";
            NoteText = note.NoteText;
            Fill = note.Fill;
            Color = note.Color;
            Priority = note.Priority.ToString( );
            Complete = note.Complete;
            Reminder = note.Reminder;
            UseReminder = note.UseReminder;
            ImageId = note.FileId;
            BackGround = note.File != null ? new BgImageDto(note.File.FileContent.Bites, note.File.ContentType) : null;
        }
    }
}
