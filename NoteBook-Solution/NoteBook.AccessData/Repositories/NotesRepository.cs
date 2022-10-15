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

        public void AddAsync (Note note)
        {
            _context.Notes.Add(note);
        }
        public void Update (Note note)
        {
            _context.Notes.Update(note);
        }

        public void Delete (Guid userId, int id)
        {
            var note = GetNotesIncluded(userId)
                .Single(n => n.Id.Equals(id));
            note.Deleted = true;
            Update(note);
        }

        public Task<List<Note>> FindNotesAsync (Guid userId, string substirng, bool complete)
        {
            return GetNotesIncluded(userId)
                .Where(n =>
                    n.Complete == complete
                    && n.NoteText.Contains(substirng, StringComparison.InvariantCultureIgnoreCase))
                .ToListAsync( );
        }

        public Task<List<Note>> GetByCategoryAsync (Guid userId, string categoryName, bool complete)
        {
            return GetNotesIncluded(userId)
                .Where(n =>
                    n.Category.Equals(categoryName)
                    && n.Complete == complete)
                .ToListAsync( );
        }

        public Task<Note> GetByIdAsync (Guid userId, int id)
        {
            return GetNotesIncluded(userId).SingleAsync(n => n.Id == id);
        }

        public Task<List<Note>> GetByPriorityAsync (Guid userId, string priority, bool complete)
        {
            return GetNotesIncluded(userId)
                .Where(n =>
                    n.Priority.Equals(priority)
                    && n.Complete == complete)
                .ToListAsync( );
        }

        public Task<List<Note>> GetRemindersAsync (Guid userId, bool complete)
        {
            return GetNotesIncluded(userId)
                .Where(n =>
                    n.UseReminder
                    && n.Complete == complete)
                .ToListAsync( );
        }

        public async Task SaveChangesAsync ( )
        {
            await _context.SaveChangesAsync( );
        }



        private IQueryable<Note> GetNotesIncluded (Guid userId)
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
