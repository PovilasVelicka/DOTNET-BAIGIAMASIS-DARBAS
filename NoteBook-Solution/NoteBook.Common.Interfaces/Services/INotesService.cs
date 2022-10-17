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


        Task<ServiceResponseDto<Note>> CreateNoteAsync (Guid userId, string title, string noteText, int? categoryId, DateTime? setReminder);
        Task<ServiceResponseDto<Note>> UpdateNoteAsync (Guid userId, int noteId, string title, string noteText, int? categoryId, DateTime? setReminder );
        Task<ServiceResponseDto<Note>> DeleteNoteAsync (Guid userId, int noteId);


        Task<ServiceResponseDto<List<Category>>> GetCategoriesAsync (Guid userId);

        Task<ServiceResponseDto<Category>> CreateCategoryAsync (Guid userId, string categoryName);
        Task<ServiceResponseDto<Category>> UpdateCategoryAsync (Guid userId, int categoryId, string categoryName);
        Task<ServiceResponseDto<Category>> DeleteCategoryAsync (Guid userId, int categoryId);
    }
}
