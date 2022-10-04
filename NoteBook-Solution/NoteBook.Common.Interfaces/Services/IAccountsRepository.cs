using NoteBook.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.Common.Interfaces.Services
{
    public interface IAccountsRepository
    {
        void Add (Account account);
        Task<Account?> GetAsync (string userLogin);
        Task SaveChangesAsync ( );
    }
}
