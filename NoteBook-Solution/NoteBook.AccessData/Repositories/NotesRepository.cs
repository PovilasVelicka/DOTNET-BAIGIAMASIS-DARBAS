using Microsoft.EntityFrameworkCore;
using NoteBook.Common.Interfaces.DataAccess;
using NoteBook.Entity.Models;

namespace NoteBook.AccessData.Repositories
{
    internal class NotesRepository : INotesRepository
    {
        private readonly AppDbContext _context;
        public NotesRepository (AppDbContext context)
        {
            _context = context;
        }

        public void AddNote (Note note)
        {
            _context.Notes.Add(note);
        }

        public void UpdateNote (Note note)
        {
            _context.Notes.Update(note);
        }

        public void DeleteNote (Guid userId, int id)
        {
            var note = GetAllNotesIncludet(userId)
                .Single(n => n.Id.Equals(id));

            note.Deleted = true;
            UpdateNote(note);
        }
        public Task<Note> GetNoteByNoteIdAsync (Guid userId, int noteId)
        {
            return GetAllNotesIncludet(userId)
                .SingleAsync(n => n.Id == noteId);
        }

        public Task<List<Note>> FindNotesAsync (Guid userId, bool complete, string substirng)
        {
            return GetAllNotesIncludet(userId, false, complete)
                .Where(n => n.NoteText.Contains(substirng, StringComparison.OrdinalIgnoreCase)).ToListAsync( );
        }

        public Task<List<Note>> GetByCategoryAsync (Guid userId, bool complete, string categoryName)
        {
            return GetAllNotesIncludet(userId)
                .Where(n => n.Complete == complete && n.Category != null && n.Category.CategoryName == categoryName)
                .ToListAsync( );
        }
        public Task<List<Note>> GetAllAsync (Guid userId, bool complete)
        {
            return GetAllNotesIncludet(userId).Where(n => n.Complete == complete).ToListAsync( );
        }

        public Task<Note> GetByIdAsync (Guid userId, int id)
        {
            return GetAllNotesIncludet(userId).SingleAsync(n => n.Id == id);
        }

        public Task<List<Note>> GetRemindersAsync (Guid userId, bool complete, string category)
        {
            return GetAllNotesIncludet(userId, true, complete)
                .Where(r => r.Category != null && r.Category.CategoryName == category)
                .ToListAsync( );
        }

        public Task<List<Note>> GetRemindersAsync (Guid userId, bool complete)
        {
            return GetAllNotesIncludet(userId, true, complete).ToListAsync( );
        }

        public Task<List<Note>> GetNotesAsync (Guid userId, bool complete)
        {
            return GetAllNotesIncludet(userId, false, complete).ToListAsync( );
        }

        public Task<List<Note>> GetNotesAsync (Guid userId, bool complete, string categoryName)
        {
            return GetAllNotesIncludet(userId, false, complete)
                .Where(n => n.Category != null && n.Category.CategoryName == categoryName)
                .ToListAsync( );
        }

        public Task<List<Category>> GetCategoriesAsync (Guid userId)
        {
            return GetAllCategories(userId).ToListAsync( );
        }

        public Task<Category?> GetCategoryAsync (Guid userId, string categoryName)
        {
            return GetAllCategories(userId).SingleOrDefaultAsync(c => c.CategoryName == categoryName);
        }

        public Task<Category> GetCategoryAsync (Guid userId, int categoryId)
        {
            return GetAllCategories(userId).SingleAsync(c => c.Id == categoryId);
        }

        public async Task CreateCategoryAsync (Guid userGuid, Category category)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userGuid);
            if (user == null) return;
            _context.Categories.Add(category);
            user.Categories.Add(category);


            await _context.SaveChangesAsync( );
        }

        public void DeleteCategory (Guid userId, int id)
        {
            var category = GetAllCategories(userId)
               .Single(n => n.Id == id);

            category.Deleted = true;
            UpdateCategory(category);
        }

        public void UpdateCategory (Category category)
        {
            _context.Categories.Update(category);

        }

        public async Task SaveChangesAsync ( )
        {
            await _context.SaveChangesAsync( );
        }

        private IQueryable<Note> GetAllNotesIncludet (Guid userId, bool isReminder, bool isComplete)
        {
            return GetAllNotesIncludet(userId)
                .Where(n =>
                    n.Complete == isComplete
                    && n.UseReminder == isReminder
                   );
        }

        private IQueryable<Note> GetAllNotesIncludet (Guid userId)
        {
            return _context
                .Notes
                .Include(c => c.Category)
                .Include(u => u.User)
                .Where(n =>
                    !n.Deleted
                    && n.UserId == userId);
        }

        private IQueryable<Category> GetAllCategories (Guid userId)
        {
            return _context
                .Categories
                .Include(u => u.Users)
                .Where(n =>
                    !n.Deleted
                    && n.Users.Any(u => u.Id == userId));
        }


    }
}
