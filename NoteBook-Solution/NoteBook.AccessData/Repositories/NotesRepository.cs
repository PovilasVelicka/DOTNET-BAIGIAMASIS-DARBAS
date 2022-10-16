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

        public void Add (Note note)
        {
            _context.Notes.Add(note);
        }

        public void Update (Note note)
        {
            _context.Notes.Update(note);
        }

        public void Delete (Guid userId, int id)
        {
            var note = GetAllIncluded(userId)
                .Single(n => n.Id.Equals(id));

            note.Deleted = true;
            Update(note);
        }

        public Task<List<Note>> FindNotesAsync (Guid userId, bool complete, string substirng)
        {
            return GetAllIncluded(userId,false,complete)
                .Where(n=> n.NoteText.Contains(substirng, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }

        public Task<List<Note>> GetByCategoryAsync (Guid userId, bool complete, string categoryName)
        {
            return GetAllIncluded(userId)
                .Where(n => n.Complete == complete && n.Category.CategoryName == categoryName).ToListAsync( );
        }
        public Task<List<Note>> GetAllAsync (Guid userId, bool complete)
        {
            return GetAllIncluded(userId).Where(n => n.Complete == complete).ToListAsync( );
        }

        public Task<Note> GetByIdAsync (Guid userId, int id)
        {
            return GetAllIncluded(userId).SingleAsync(n => n.Id == id);
        }

        public Task<List<Note>> GetRemindersAsync (Guid userId, bool complete, string category)
        {
            return GetAllIncluded(userId, true, complete)
                .Where(r => r.Category.CategoryName == category).ToListAsync( );
        }

        public Task<List<Note>> GetRemindersAsync (Guid userId, bool complete)
        {
            return GetAllIncluded(userId, true, complete).ToListAsync( );
        }

        public Task<List<Note>> GetNotesAsync (Guid userId, bool complete)
        {
            return GetAllIncluded(userId, false, complete).ToListAsync( );
        }

        public Task<List<Note>> GetNotesAsync (Guid userId, bool complete, string categoryName)
        {
            return GetAllIncluded(userId, false, complete)
                .Where(n => n.Category.CategoryName == categoryName).ToListAsync( );
        }

        public async Task SaveChangesAsync ( )
        {
            await _context.SaveChangesAsync( );
        }


        private IQueryable<Note> GetAllIncluded (Guid userId, bool isReminder, bool isComplete)
        {
            return GetAllIncluded(userId)
                .Where(n =>
                    n.Complete == isComplete
                    && n.UseReminder == isReminder
                   );
        }

        private IQueryable<Note> GetAllIncluded (Guid userId)
        {
            return _context
                .Notes
                .Include(c => c.Category)
                .Include(u => u.User)
                .Where(n =>
                    !n.Deleted
                    && n.UserId == userId);
        }
    }
}
