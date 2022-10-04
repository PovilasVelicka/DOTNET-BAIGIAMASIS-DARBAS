using Microsoft.EntityFrameworkCore;
using NoteBook.Common.Interfaces.Services;
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

        public async Task<Account?> GetAsync (string userLogin)
        {
            return await _appDbContext.Accounts.FirstOrDefaultAsync(a => a.LoginName == userLogin);
        }

        public async Task SaveChangesAsync ( )
        {
            await _appDbContext.SaveChangesAsync( );
        }
    }
}
