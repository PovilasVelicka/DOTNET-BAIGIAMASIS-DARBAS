using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Entity.Models;

namespace NoteBook.Common.Interfaces.Services
{
    public interface IAuthService
    {
        /// <returns>If SignUp sucessfule return token else null </returns>
        Task<ServiceResponseDto<string>> SignupNewAccountAsync (string username, string password, string email);

        /// <returns>If Login sucessfule return token else null </returns>
        Task<ServiceResponseDto<string>> LoginAsync (string username, string password);
    }
}
