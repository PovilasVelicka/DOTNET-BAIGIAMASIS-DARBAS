using Microsoft.EntityFrameworkCore;
using NoteBook.Common.Interfaces.AccessData;
using NoteBook.Common.Interfaces.DataAccess;
using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;

namespace NoteBook.AccessData
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly AppDbContext _appDbContext;

        public AccountsRepository (AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add (Account account)
        {

            _appDbContext.Accounts.Add(account);
        }

        public async Task<Account?> GetByNameAsync (string userLogin)
        {
            return await
                _appDbContext
                .Accounts
                .Include(e => e.Email)
                .SingleOrDefaultAsync(a => a.LoginName == userLogin);
        }

        public async Task<Account?> GetByEmailAsync ( string userEmail)
        {
            return await
                _appDbContext
                .Accounts
                .Include(e => e.Email)
                .SingleOrDefaultAsync(a => a.Email.Value == userEmail);
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

        public  Task<int> CountRoleAsync (Role role)
        {
            return  _appDbContext.Accounts.Where(a=> a.Role == role).CountAsync();
        }
    }
}
