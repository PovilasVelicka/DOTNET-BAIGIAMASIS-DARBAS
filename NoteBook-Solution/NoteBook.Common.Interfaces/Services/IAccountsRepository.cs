using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;

namespace NoteBook.Common.Interfaces.Services
{
    public interface IAccountsRepository
    {
        void Add (Account account);
        Task<Account?> GetAsync (string userLogin);
        Task SaveChangesAsync ( );
        Task<bool> Exists (string userLogin, string userEmail);
        Task<List<Account>> GetByRoleAsync (Role role);
    }
}
