using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Entity.Models;

namespace NoteBook.Common.Interfaces.Services
{
    public interface IAuthService
    {
        Task<IResponseDto<Account>> SignupNewAccountAsync (string username, string password, string email);
        Task<IResponseDto<Account>> LoginAsync (string username, string password);
    }
}
