using NoteBook.Entity.Models;

namespace NoteBook.Common.Interfaces.DataAccess
{
    public interface IFilesRepository
    {
        Task<int> AddFileAsync (FileHead fileProperty);
        Task<(bool,string)> DeleteFileAsync (int Id);
        Task<FileHead> GetFileAsync (int Id);
        Task<List<FileHead>> GetFilesAsync (string fileNameSubstring);     
    }
}
