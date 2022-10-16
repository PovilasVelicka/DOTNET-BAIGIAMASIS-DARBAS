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


        Task<ServiceResponseDto<Note>> CreateNoteAsync (Guid userId, Note note);
        Task<ServiceResponseDto<Note>> UpdateNoteAsync (Guid userId, Note note);
        Task<ServiceResponseDto<Note>> DeleteNoteAsync (Guid userId, int noteId);


        Task<ServiceResponseDto<List<Category>>> GetCategoriesAsync (Guid userId);
   
        Task<ServiceResponseDto<Category>> CreateCategoryAsync (Guid userId, Category category);
        Task<ServiceResponseDto<Category>> UpdateCategoryAsync (Guid userId, Category category);
        Task<ServiceResponseDto<Category>> DeleteCategoryAsync (Guid userId, int categoryId);
    }
}
