using NoteBook.Common.Interfaces.DataAccess;
using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Entity.Models;
using System.Drawing;
using System.Net;

namespace NoteBook.BusinessLogic.Services.NotesService
{
    internal class NotesService : INotesService
    {
        const string ERROR = "Undocumented error";
        private readonly INotesRepository _repository;
        public NotesService (INotesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponseDto<Note>> CreateNoteAsync (Guid userId, string title, string noteText, int? categoryId, DateTime? setReminder)
        {
            var note = new Note
            {
                UserId = userId,
                Title = title,
                NoteText = noteText,
                CategoryId = categoryId,
                Reminder = setReminder,
                UseReminder = setReminder != null
            };

            try
            {
                _repository.AddNote(note);
                await _repository.SaveChangesAsync( );
                return new ServiceResponseDto<Note>(note);
            }
            catch (Exception e)
            {

                return new ServiceResponseDto<Note>(default, e.InnerException?.Message ?? ERROR, 503);
            }
        }

        public async Task<ServiceResponseDto<Note>> UpdateNoteAsync (Guid userId, int noteId, string title, string noteText, int? categoryId, DateTime? setReminder)
        {

            try
            {
                var note = await _repository.GetNoteByNoteIdAsync(userId, noteId);
                note.Title = title;
                note.NoteText = noteText;
                note.CategoryId = categoryId;
                note.Reminder = setReminder;
                note.UseReminder = setReminder != null;
                _repository.UpdateNote(note);
                await _repository.SaveChangesAsync( );
                return new ServiceResponseDto<Note>(note);
            }
            catch (Exception e)
            {

                return new ServiceResponseDto<Note>(default, e.Message, 503);
            }
        }

        public async Task<ServiceResponseDto<Note>> DeleteNoteAsync (Guid userId, int noteId)
        {
            try
            {
                _repository.DeleteNote(userId, noteId);
                await _repository.SaveChangesAsync( );
                return new ServiceResponseDto<Note>(true, "Note deleted");
            }
            catch (Exception e)
            {

                return new ServiceResponseDto<Note>(default, e.Message, 503);
            }
        }

        public async Task<ServiceResponseDto<List<Note>>> GetAllAsync (Guid userId)
        {
            var getComplete = await _repository.GetAllAsync(userId, true);
            var getNotComplete = await _repository.GetAllAsync(userId, false);

            var notes = new List<Note>( );
            notes.AddRange(getComplete);
            notes.AddRange(getNotComplete);

            return new ServiceResponseDto<List<Note>>(notes);
        }

        public async Task<ServiceResponseDto<List<Note>>> GetNotesAsync (Guid userId, bool complete)
        {
            var notes = await _repository.GetAllAsync(userId, complete);
            return new ServiceResponseDto<List<Note>>(notes);
        }

        public async Task<ServiceResponseDto<List<Note>>> GetNotesAsync (Guid userId, bool complete, string category)
        {
            var notes = await _repository.GetByCategoryAsync(userId, complete, category);
            return new ServiceResponseDto<List<Note>>(notes);
        }

        public async Task<ServiceResponseDto<List<Note>>> GetRemindersAsync (Guid userId, bool complete)
        {
            var notes = await _repository.GetRemindersAsync(userId, complete);
            return new ServiceResponseDto<List<Note>>(notes);
        }

        public async Task<ServiceResponseDto<List<Note>>> GetRemindersAsync (Guid userId, bool complete, string category)
        {
            var notes = await _repository.GetRemindersAsync(userId, complete, category);
            return new ServiceResponseDto<List<Note>>(notes);
        }
       
        public async Task<ServiceResponseDto<Note>> ChangeNoteStyleAsync (Guid userId, int noteId, string color, string fill)
        {
            var note = await _repository.GetNoteByNoteIdAsync(userId, noteId);
            note.Fill = fill;
            note.Color = color;
            await _repository.SaveChangesAsync( );
            return new ServiceResponseDto<Note>(note);
        }

        public async Task<ServiceResponseDto<Note>> SetCompleteNoteAsync (Guid userId, int noteId)
        {
            var note = await _repository.GetNoteByNoteIdAsync(userId, noteId);
            note.Complete = true;
            await _repository.SaveChangesAsync( );
            return new ServiceResponseDto<Note>(note);
        }

        public async Task<ServiceResponseDto<List<Category>>> GetCategoriesAsync (Guid userId)
        {
            var categories = await _repository.GetCategoriesAsync(userId);
            return new ServiceResponseDto<List<Category>>(categories);
        }

        public async Task<ServiceResponseDto<Category>> CreateCategoryAsync (Guid userId, string categoryName)
        {
            try
            {
                var existsCategory = await _repository.GetCategoryAsync(userId, categoryName);
                if (existsCategory != null) return new ServiceResponseDto<Category>(existsCategory);
                var newCategory = new Category
                {
                    CategoryName = categoryName,
                    Deleted = false
                };

                await _repository.CreateCategoryAsync(userId, newCategory);
                await _repository.SaveChangesAsync( );
                return new ServiceResponseDto<Category>(newCategory);

            }
            catch (Exception e)
            {

                return new ServiceResponseDto<Category>(default, e.Message, 503);
            }
        }

        public async Task<ServiceResponseDto<Category>> UpdateCategoryAsync (Guid userId, int categoryId, string categoryName)
        {
            try
            {
                var existCategory = await _repository.GetCategoryAsync(userId, categoryId);
                if (existCategory == null) return new ServiceResponseDto<Category>(default, "Category not exists", (int)HttpStatusCode.NotFound);
                existCategory.CategoryName = categoryName;

                _repository.UpdateCategory(existCategory);
                await _repository.SaveChangesAsync( );
                return new ServiceResponseDto<Category>(existCategory);
            }
            catch (Exception e)
            {

                return new ServiceResponseDto<Category>(default, e.Message, 503);
            }
        }

        public async Task<ServiceResponseDto<Category>> DeleteCategoryAsync (Guid userId, int categoryId)
        {
            try
            {
                var deleteCategory = await _repository.GetCategoryAsync(userId, categoryId);
                deleteCategory.Deleted = true;
                _repository.UpdateCategory(deleteCategory);
                await _repository.SaveChangesAsync( );
                return new ServiceResponseDto<Category>(true, "Category deleted");
            }
            catch (Exception e)
            {

                return new ServiceResponseDto<Category>(default, e.Message, 503);
            }

        }


    }
}
