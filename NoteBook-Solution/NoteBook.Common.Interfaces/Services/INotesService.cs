using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Entity.Models;

namespace NoteBook.Common.Interfaces.Services
{
    public interface INotesService
    {
        Task<ServiceResponseDto<List<Note>>> GetAllAsync (Guid userId);
        Task<ServiceResponseDto<List<Note>>> GetRemindersAsync (Guid userId);
        Task<ServiceResponseDto<Note>> CreateAsync (Note note);
        Task<ServiceResponseDto<Note>> UpdateAsync (Note note);
        Task<ServiceResponseDto<Note>> DeleteAsync (Guid userId, int noteId);
    }
}
