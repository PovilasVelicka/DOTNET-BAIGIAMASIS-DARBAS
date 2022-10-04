using NoteBook.Entity.Models;

namespace NoteBook.Common.Interfaces.Services
{
    public interface IAuthService
    {
        Task<Account?> SignupNewAccountAsync (string username, string password, string email);
        Task<bool> LoginAsync (string username, string password);
    }
}
