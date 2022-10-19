using Microsoft.EntityFrameworkCore;
using NoteBook.Common.Interfaces.DataAccess;
using NoteBook.Entity.Models;

namespace NoteBook.AccessData.Repositories
{
    internal class FilesRepository : IFilesRepository
    {
        private readonly AppDbContext _context;
        public FilesRepository (AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddFileAsync (FileHead fileWithContent)
        {
            var contentExists = _context.FilesContents
                .Any(
                f =>
                f.Id == fileWithContent.FileContent.Id);

            if (!contentExists)
            {
                _context.Files.Add(fileWithContent);
            }
            else
            {
                var file = _context.Files.FirstOrDefault(u =>
                    u.FileName == fileWithContent.FileName
                    && u.FileContentId == fileWithContent.FileContent.Id);
                if (file == null)
                {
                    var fContent = _context.FilesContents.Single(f => f.Id == fileWithContent.FileContent.Id);

                    fileWithContent.FileContent = fContent;
                    _context.Files.Add(fileWithContent);
                }
                else
                {
                    fileWithContent = file;
                }

            }

            await _context.SaveChangesAsync( );
            return fileWithContent.Id;
        }

        public async Task<(bool, string)> DeleteFileAsync (int Id)
        {
            try
            {
                var file = _context.Files.Single(f => f.Id == Id);
                _context.Files.Remove(file);
                await _context.SaveChangesAsync( );
                return (true, "File deleted");
            }
            catch (Exception e)
            {

                return (false, e.Message);
            }
        }

        public Task<FileHead> GetFileAsync (int Id)
        {
            return _context.Files
                .Include(f => f.FileContent)
                .SingleAsync(f => f.Id == Id);
        }

        public Task<List<FileHead>> GetFilesAsync (string fileNameSubstring)
        {
            return _context.Files
                .Include(f => f.FileContent)
                .Where(f => f.FileName.Contains(fileNameSubstring))
                .ToListAsync( );
            
        }
    }
}
