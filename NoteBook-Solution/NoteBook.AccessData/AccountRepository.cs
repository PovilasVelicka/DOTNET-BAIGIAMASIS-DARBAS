using Microsoft.EntityFrameworkCore;
using NoteBook.Common.Interfaces.AccessData;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;

namespace NoteBook.AccessData
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly IDbContext _appDbContext;

        public AccountsRepository (IDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add (Account account)
        {

            _appDbContext.Accounts.Add(account);
        }

        public async Task<Account?> GetAsync (string userLogin)
        {
            return await
                _appDbContext
                .Accounts
                .Include(e => e.Email)
                .FirstOrDefaultAsync(a => a.LoginName == userLogin);
        }

        public async Task<bool> Exists (string userLogin, string userEmail)
        {
            return await
                _appDbContext
                .Accounts
                .Include(e => e.Email)
                .AnyAsync(a => a.LoginName == userLogin || a.Email.Value == userEmail);
        }

        public async Task SaveChangesAsync ( )
        {
            await _appDbContext.SaveChangesAsync( );
        }

        public async Task<List<Account>> GetByRoleAsync (Role role)
        {
            return await
                _appDbContext
                .Accounts
                .Include(e => e.Email)
                .Where(a => a.Role == role)
                .ToListAsync( );
        }
    }
}
