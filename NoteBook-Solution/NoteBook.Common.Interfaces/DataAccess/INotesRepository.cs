using NoteBook.Entity.Models;

namespace NoteBook.Common.Interfaces.DataAccess
{
    public interface INotesRepository
    {
        Task<Note> GetByIdAsync (Guid userId, int id);
        Task<List<Note>> GetAllAsync (Guid userId, bool complete);
        Task<List<Note>> GetByCategoryAsync (Guid userId, bool complete, string categoryName);
        Task<List<Note>> GetNotesAsync (Guid userId, bool complete);
        Task<List<Note>> GetNotesAsync (Guid userId, bool complete, string categoryName);
        Task<List<Note>> GetRemindersAsync (Guid userId, bool complete);
        Task<List<Note>> GetRemindersAsync (Guid userId, bool complete, string categoryName);
        Task<List<Note>> FindNotesAsync (Guid userId, bool complete, string substirng);

        void Add (Note note);
        void Delete (Guid userId, int Id);
        void Update (Note note);
        Task SaveChangesAsync ( );
    }
}
