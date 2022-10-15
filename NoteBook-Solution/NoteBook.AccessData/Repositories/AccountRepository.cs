using Microsoft.EntityFrameworkCore;
using NoteBook.Common.Interfaces.DataAccess;
using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;
using System.Data;

namespace NoteBook.AccessData.Repositories
{
    internal class AccountsRepository : IAccountsRepository
    {
        private readonly AppDbContext _appDbContext;

        public AccountsRepository (AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync (Account account)
        {

            await _appDbContext.Accounts.AddAsync(account);
        }

        public async Task<Account?> GetByNameAsync (string userLogin)
        {
            return await
                GetAccountsIncludeEmails( )
                .SingleOrDefaultAsync(a => a.LoginName == userLogin);
        }

        public async Task<Account?> GetByEmailAsync (string userEmail)
        {
            return await
                GetAccountsIncludeEmails( )
                .SingleOrDefaultAsync(a => a.Email.Value == userEmail);
        }

        public async Task SaveChangesAsync ( )
        {
            await _appDbContext.SaveChangesAsync( );
        }

        public async Task<List<Account>?> GetByRoleAsync (Role role)
        {
            return await
                GetAccountsIncludeEmails( )
                .Where(a => a.Role == role)
                .ToListAsync( );
        }

        public async Task<int> CountRoleAsync (Role role)
        {
            return await _appDbContext.Accounts.Where(a => a.Role == role).CountAsync( );
        }

        public async Task<List<Account>?> GetByNameSubstringAsync (string name)
        {
            return await
             GetAccountsIncludeEmails( )
             .Where(a => a.LoginName.Contains(name) || a.Email.Value.Contains(name))
             .ToListAsync( );
        }

        public void Update (Account account)
        {
            _appDbContext.Accounts.Update(account);
        }

        public Account GetById (Guid Id)
        {
            return GetAccountsIncludeEmails( ).Single(a => a.Id == Id);
        }

        private IQueryable<Account> GetAccountsIncludeEmails ( )
        {
            return _appDbContext.Accounts.Include(e => e.Email);
        }
    }
}
