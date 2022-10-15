using NoteBook.Common.Interfaces.DataAccess;
using NoteBook.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.AccessData.Repositories
{
    internal class NotesRepository : INotesRepository
    {
        private readonly AppDbContext _context;
        public NotesRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Note note)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Note note)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Note>> FindNotesAsync(Guid userId, string substirng)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Note>> GetByCategoryAsync(Guid userId, int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Note> GetByIdAsync(Guid userId, int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Note>> GetByPriorityAsync(Guid userId, int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Note>> GetRemindersAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
