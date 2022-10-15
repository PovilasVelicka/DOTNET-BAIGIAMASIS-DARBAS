using NoteBook.Entity.Models;

namespace NoteBook.Common.Interfaces.DataAccess
{
    public interface INotesRepository
    {
        Task<Note> GetByIdAsync (Guid userId, int id);
        Task<List<Note>> GetByCategoryAsync (Guid userId, string categoryName, bool complete);
        Task<List<Note>> GetByPriorityAsync (Guid userId, string priority, bool complete);
        Task<List<Note>> GetRemindersAsync (Guid userId, bool complete);
        Task<List<Note>> FindNotesAsync (Guid userId, string substirng, bool complete);
        void AddAsync (Note note);
        void Delete (Guid userId, int Id);
        void Update (Note note);
        Task SaveChangesAsync ( );
    }
}
