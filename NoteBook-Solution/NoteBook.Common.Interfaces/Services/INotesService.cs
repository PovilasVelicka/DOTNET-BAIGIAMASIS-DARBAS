using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Entity.Models;

namespace NoteBook.Common.Interfaces.Services
{
    public interface INotesService
    {
        Task<ServiceResponseDto<List<Note>>> GetAllAsync (Guid userId);
        Task<ServiceResponseDto<List<Note>>> GetNotesAsync (Guid userId, bool complete);   
        Task<ServiceResponseDto<List<Note>>> GetNotesAsync (Guid userId, bool complete, string category);
        Task<ServiceResponseDto<List<Note>>> GetRemindersAsync (Guid userId, bool complete);
        Task<ServiceResponseDto<List<Note>>> GetRemindersAsync (Guid userId, bool complete, string category);

        Task<ServiceResponseDto<Note>> CreateAsync (Guid userId, Note note);
        Task<ServiceResponseDto<Note>> UpdateAsync (Guid userId, Note note);
        Task<ServiceResponseDto<Note>> DeleteAsync (Guid userId, int noteId);
    }
}
