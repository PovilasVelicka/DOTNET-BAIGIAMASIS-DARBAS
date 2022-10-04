
using NoteBook.BusinessLogic.DTOs;
using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;
using System.Net;
using Utils.Extensions;

namespace NoteBook.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAccountsRepository _accountsRepository;

        public AuthService (IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public async Task<IResponseDto<Account>> LoginAsync (string username, string password)
        {
            var account = await _accountsRepository.GetAsync(username);
            if (account == null) return new AuthResponseDto(null, "User name not exists", (int)HttpStatusCode.NotFound);
            if (!password.VerifyPassword(account.PasswordHash, account.PasswordSalt))
            {
                return new AuthResponseDto(null, "Incorrect password", (int)HttpStatusCode.Unauthorized);
            }
            return new AuthResponseDto(account, (int)HttpStatusCode.OK);
        }

        public async Task<IResponseDto<Account>> SignupNewAccountAsync (string loginName, string password, string email)
        {
            if (await _accountsRepository.Exists(loginName, email))
            {
                return new AuthResponseDto(null, "User name or email already exists", (int)HttpStatusCode.BadRequest);
            }

            var account = CreateAccount(loginName, password, email);
            _accountsRepository.Add(account);
            await _accountsRepository.SaveChangesAsync( );

            return new AuthResponseDto(account, (int)HttpStatusCode.OK);

        }

        private static Account CreateAccount (string loginName, string password, string email)
        {

            var (passwordHash, passwordSalt) = password.CreatePasswordHash( );
            return new Account
            {
                Id = Guid.NewGuid( ),
                LoginName = loginName,
                Email = new Email(email),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = Role.Guest,
                Disabled = false,
                EmailVerified = false,
            };
        }
    }
}
