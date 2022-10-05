using Microsoft.EntityFrameworkCore;
using NoteBook.Entity.Models;

namespace NoteBook.Common.Interfaces.AccessData
{
    public interface IDbContext
    {
        DbSet<AboutUser> AboutUsers { get; set; }
        DbSet<Account> Accounts { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Email> Emails { get; set; }
        DbSet<FirstName> FirstNames { get; set; }
        DbSet<LastName> LastNames { get; set; }
        DbSet<Note> Notes { get; set; }
        Task<int> SaveChangesAsync (CancellationToken cancellationToken = default);
    }
}
