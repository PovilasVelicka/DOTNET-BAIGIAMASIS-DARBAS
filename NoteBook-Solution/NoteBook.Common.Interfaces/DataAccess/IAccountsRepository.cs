using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;

namespace NoteBook.Common.Interfaces.DataAccess
{
    public interface IAccountsRepository
    {
        Task AddAsync(Account account);
        void Update(Account account);
        Task<Account?> GetByNameAsync(string userLogin);
        Task SaveChangesAsync();
        Task<Account?> GetByEmailAsync(string userEmail);
        Task<List<Account>?> GetByRoleAsync(Role role);
        Task<int> CountRoleAsync(Role role);
        Task<List<Account>?> GetByNameSubstringAsync(string name);   
    }
}
