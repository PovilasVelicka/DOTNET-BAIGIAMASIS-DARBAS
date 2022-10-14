
using Microsoft.Extensions.Logging;
using NoteBook.BusinessLogic.AuthServices.DTOs;
using NoteBook.Common.Interfaces.DataAccess;
using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;
using System.Net;
using Utils.Extensions;

namespace NoteBook.BusinessLogic.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IAccountsRepository _accountsRepository;
        private readonly ILogger<AuthService> _logger;
        public AuthService (IAccountsRepository accountsRepository, ILogger<AuthService> logger)
        {
            _accountsRepository = accountsRepository;
            _logger = logger;
        }

        public async Task<IResponse<Account>> LoginAsync (string username, string password)
        {
            var account = await _accountsRepository.GetByNameAsync(username);
            if (account == null) return new AuthResponseDto(null, "User name not exists", (int)HttpStatusCode.NotFound);
            if (!password.VerifyPassword(account.PasswordHash, account.PasswordSalt))
            {
                return new AuthResponseDto(null, "Incorrect password", (int)HttpStatusCode.Unauthorized);
            }
            return new AuthResponseDto(account, (int)HttpStatusCode.OK);
        }

        public async Task<IResponse<Account>> SignupNewAccountAsync (string loginName, string password, string email)
        {
            if (await _accountsRepository.GetByNameAsync(loginName) != null)
            {
                return new AuthResponseDto(null, "User name already exists", (int)HttpStatusCode.BadRequest);
            }

            if (await _accountsRepository.GetByEmailAsync(email) != null)
            {
                return new AuthResponseDto(null, "User email already exists", (int)HttpStatusCode.BadRequest);
            }
            var adminCount = await _accountsRepository.CountRoleAsync(Role.PeopleAdmin);

            var account = CreateAccount(loginName, password, email, adminCount == 0 ? Role.PeopleAdmin : Role.Guest);

            _accountsRepository.Add(account);
            try
            {
                await _accountsRepository.SaveChangesAsync( );
            }
            catch (Exception e)
            {
                string errMessage = $"Can't create user with: " +
                    $"\n\tlogin-name: {loginName}" +
                    $"\n\temail: {email}" +
                    $"\n\terror: {e.Message} {e.InnerException}";
                _logger.LogError(message: errMessage);

                return new AuthResponseDto(null, "Account creation error", 500);
            }

            return new AuthResponseDto(account, (int)HttpStatusCode.OK);
        }

        private static Account CreateAccount (string loginName, string password, string email, Role role)
        {
            var (passwordHash, passwordSalt) = password.CreatePasswordHash( );

            return new Account
            {
                Id = Guid.NewGuid( ),
                LoginName = loginName,
                Email = new Email(email),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = role,
                Disabled = false,
                EmailVerified = false,
            };
        }
    }
}
