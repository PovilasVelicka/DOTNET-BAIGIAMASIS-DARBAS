using NoteBook.Entity.Models;

namespace NoteBook.Common.Interfaces.Services
{
    public interface IFilesService
    {
        Task<int> AddFileAsync (byte[ ] fileBytes, string contentType, string fileName);
        Task<FileHead> GetFileAsync (int id);
        Task<List<FileHead>> GetFilesAsync (string fileNameSubstring);
        Task<(bool, string)> DeleteFileAsync (int id);
       
    }
}
