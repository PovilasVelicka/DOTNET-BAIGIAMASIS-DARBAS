using NoteBook.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.Common.Interfaces.DataAccess
{
    public interface INotesRepository
    {
        Task<Note> GetByIdAsync (Guid userId, int id);
        Task<IQueryable<Note>> GetByCategoryAsync (Guid userId, int categoryId);
        Task<IQueryable<Note>> GetByPriorityAsync (Guid userId, int categoryId);
        Task<IQueryable<Note>> GetRemindersAsync (Guid userId);
        Task<IQueryable<Note>> FindNotesAsync (Guid userId, string substirng);
        Task AddAsync(Note note);
        Task DeleteAsync (Note note);
        Task UpdateAsync(Note note);
        Task SaveChangesAsync ( );
    }
}
