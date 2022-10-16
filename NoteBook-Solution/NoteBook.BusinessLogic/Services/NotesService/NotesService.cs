using NoteBook.Common.Interfaces.DataAccess;
using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Entity.Models;

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

        public async Task<ServiceResponseDto<Note>> CreateAsync (Guid userId, Note note)
        {
            try
            {
                _repository.Add(note);
                await _repository.SaveChangesAsync( );
                return new ServiceResponseDto<Note>(note);
            }
            catch (Exception e)
            {

                return new ServiceResponseDto<Note>(default, e.InnerException?.Message ?? ERROR, 503);
            }
        }

        public async Task<ServiceResponseDto<Note>> UpdateAsync (Guid userId, Note note)
        {
            try
            {
                _repository.Update(note);
                await _repository.SaveChangesAsync( );
                return new ServiceResponseDto<Note>(note);
            }
            catch (Exception e)
            {

                return new ServiceResponseDto<Note>(default, e.InnerException?.Message ?? ERROR, 503);
            }
        }

        public async Task<ServiceResponseDto<Note>> DeleteAsync (Guid userId, int noteId)
        {
            try
            {
                _repository.Delete(userId, noteId);
                await _repository.SaveChangesAsync( );
                return new ServiceResponseDto<Note>(true, "Note deleted");
            }
            catch (Exception e)
            {

                return new ServiceResponseDto<Note>(default, e.InnerException?.Message ?? ERROR, 503);
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
            var notes = await _repository.GetByCategoryAsync(userId, complete,category);
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
    }
}
