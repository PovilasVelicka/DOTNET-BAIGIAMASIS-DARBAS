using NoteBook.Common.Interfaces.Services;
using NoteBook.Entity.ModelProperties;
using NoteBook.Entity.Models;
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

        public async Task<bool> LoginAsync (string username, string password)
        {
            var account = await _accountsRepository.GetAsync(username);
            if (account == null) return false;
            return password.VerifyPassword(account.PasswordHash, account.PasswordSalt);
        }

        public async Task<Account?> SignupNewAccountAsync (string loginName, string password, string email)
        {
            var account = await _accountsRepository.GetAsync(loginName);
            if (account != null) return default;
            account = CreateAccount(loginName, password, email);
            _accountsRepository.Add(account);
            await _accountsRepository.SaveChangesAsync( );
            return account;

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
                PasswordSalt = passwordSalt
            };
        }
    }
}
