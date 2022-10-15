using NoteBook.Common.Interfaces.DataAccess;
using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Entity.Models;

namespace NoteBook.BusinessLogic.Services.NotesService
{
    internal class NotesService : INotesService
    {
        private readonly INotesRepository _repository;
        public NotesService (INotesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponseDto<Note>> CreateAsync (Note note)
        {
            await _repository.AddAsync(note);
            await _repository.SaveChangesAsync( );
            return new ServiceResponseDto<Note>(note);
        }

        public async Task<ServiceResponseDto<Note>> DeleteAsync (Guid userId, int noteId)
        {
            var note = await _repository.GetByIdAsync(userId, noteId);
            if (note != null)
            {
                note.Deleted = true;
                await _repository.UpdateAsync(note);
                await _repository.SaveChangesAsync( );
            }
            return new ServiceResponseDto<Note>(true, "Note deleted");
        }

        public Task<ServiceResponseDto<List<Note>>> GetAllAsync (Guid userId)
        {
            // var notesQuery = await _repository.GetByCategoryAsync(userId, 1);
            throw new NotImplementedException( );
        }

        public Task<ServiceResponseDto<List<Note>>> GetRemindersAsync (Guid userId)
        {
            throw new NotImplementedException( );
        }

        public Task<ServiceResponseDto<Note>> UpdateAsync (Note note)
        {
            throw new NotImplementedException( );
        }
    }
}
