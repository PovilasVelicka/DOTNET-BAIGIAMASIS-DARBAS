using NoteBook.Entity.Models;

namespace NoteBook.Controllers.NotesController.DTOs
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string NoteText { get; set; } = null!;
        public string Fill { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Priority { get; set; } = null!;
        public bool Complete { get; set; }
        public NoteDto ( ) { }
        public NoteDto (Note note)
        {
            Id = note.Id;
            Title = note.Title;
            CategoryName = note.Category?.CategoryName ?? "";
            NoteText = note.NoteText;
            Fill = note.Fill;
            Color = note.Color;
            Priority = note.Priority.ToString( );
            Complete = note.Complete;
        }
    }
}
