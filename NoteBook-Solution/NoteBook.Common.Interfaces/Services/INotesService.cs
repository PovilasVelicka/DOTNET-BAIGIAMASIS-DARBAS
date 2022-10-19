using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Entity.Enums;
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


        Task<ServiceResponseDto<Note>> CreateNoteAsync (Guid userId, string title, string noteText, string categoryName, DateTimeOffset? setReminder);
        Task<ServiceResponseDto<Note>> UpdateNoteAsync (Guid userId, int noteId,
            string? title = null,
            string? noteText = null,
            string? categoryName = null,
            DateTimeOffset? reminderDate = null,
            string? priority = null,
            bool? useReminder = null,
            bool? complete = null,
            string? fill = null,
            string? color = null);
        Task<ServiceResponseDto<Note>> UpdateBgImageAsync (Guid userId, int noteId, byte[ ] imageBytes, string contentType, string fileName);
        Task<ServiceResponseDto<Note>> RemoveBgImageAsync (Guid userId, int noteId);
        Task<ServiceResponseDto<Note>> DeleteNoteAsync (Guid userId, int noteId);
    
        Task<ServiceResponseDto<List<Category>>> GetCategoriesAsync (Guid userId);

        Task<ServiceResponseDto<Category>> CreateCategoryAsync (Guid userId, string categoryName);
        Task<ServiceResponseDto<Category>> UpdateCategoryAsync (Guid userId, int categoryId, string categoryName);
        Task<ServiceResponseDto<Category>> DeleteCategoryAsync (Guid userId, int categoryId);
    }
}
