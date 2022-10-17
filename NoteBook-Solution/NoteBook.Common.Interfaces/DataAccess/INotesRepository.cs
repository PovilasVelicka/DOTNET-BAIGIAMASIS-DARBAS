using NoteBook.Entity.Models;

namespace NoteBook.Common.Interfaces.DataAccess
{
    public interface INotesRepository
    {
        Task<Note> GetByIdAsync (Guid userId, int id);
        Task<List<Note>> GetAllAsync (Guid userId, bool complete);
        Task<List<Note>> GetByCategoryAsync (Guid userId, bool complete, string categoryName);
        Task<Note> GetNoteByNoteIdAsync (Guid userId, int noteId);
        Task<List<Note>> GetNotesAsync (Guid userId, bool complete);
        Task<List<Note>> GetNotesAsync (Guid userId, bool complete, string categoryName);
        Task<List<Note>> GetRemindersAsync (Guid userId, bool complete);
        Task<List<Note>> GetRemindersAsync (Guid userId, bool complete, string categoryName);
        Task<List<Note>> FindNotesAsync (Guid userId, bool complete, string substirng);

        Task<List<Category>> GetCategoriesAsync (Guid userId);
        Task<Category?> GetCategoryAsync (Guid userId, string categoryName);
        Task<Category> GetCategoryAsync (Guid userId, int categoryId);

        void AddNote (Note note);
        void DeleteNote (Guid userId, int Id);
        void UpdateNote (Note note);

        Task CreateCategoryAsync (Guid userId, Category category);
        void DeleteCategory (Guid userId, int Id);
        void UpdateCategory (Category category);
        Task SaveChangesAsync ( );

        
    }
}
