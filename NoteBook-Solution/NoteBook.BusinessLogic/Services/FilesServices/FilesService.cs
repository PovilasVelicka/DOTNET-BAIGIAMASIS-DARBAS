using NoteBook.Common.Interfaces.DataAccess;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Entity.Models;
using Utilites.Exstensions;

namespace NoteBook.BusinessLogic.Services.FilesServices
{
    internal class FilesService : IFilesService
    {
        private readonly IFilesRepository _repository;
        public FilesService (IFilesRepository repository)
        {
            _repository = repository;
        }

        public Task<int> AddFileAsync (byte[ ] fileBytes, string contentType, string fileName)
        {
            var file = new FileHead
            {
                FileName = fileName,
                ContentType = contentType,
                FileContent = new FileContent
                {
                    Bites = fileBytes,
                    Id = fileBytes.GetCheckSum( ),
                }
            };

            return _repository.AddFileAsync(file);
        }

        public async Task<(bool, string)> DeleteFileAsync (int id)
        {          
            return await _repository.DeleteFileAsync(id);
        }

        public Task<FileHead> GetFileAsync (int id)
        {
            return _repository.GetFileAsync(id);
        }

        public Task<List<FileHead>> GetFilesAsync (string fileNameSubstring)
        {
            return _repository.GetFilesAsync(fileNameSubstring);
        }
    }
}
