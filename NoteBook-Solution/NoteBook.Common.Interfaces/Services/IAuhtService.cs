using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Entity.Models;

namespace NoteBook.Common.Interfaces.Services
{
    public interface IAuthService
    {
        Task<IResponse<Account>> SignupNewAccountAsync (string username, string password, string email);
        Task<IResponse<Account>> LoginAsync (string username, string password);
    }
}
