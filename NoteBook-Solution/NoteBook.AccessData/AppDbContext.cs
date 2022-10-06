using Microsoft.EntityFrameworkCore;
using NoteBook.Common.Interfaces.AccessData;
using NoteBook.Entity.Enums;

namespace NoteBook.Entity.Models
{
    public partial class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext ( ) { }

        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<AboutUser> AboutUsers { get; set; } = null!;
        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Email> Emails { get; set; } = null!;
        public virtual DbSet<FirstName> FirstNames { get; set; } = null!;
        public virtual DbSet<LastName> LastNames { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;

        public override Task<int> SaveChangesAsync (CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever( );
                // convert enum to string and back to enum (upload, download)
                entity.Property(p => p.Role)
                .HasConversion(
                    u => u.ToString( ),
                    d => (Role)Enum.Parse(typeof(Role), d));
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Id });

                entity.Property(e => e.Id).ValueGeneratedOnAdd( );
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.Color).HasDefaultValueSql("('#000000FF')");

                entity.Property(e => e.Fill).HasDefaultValueSql("('#FFFFFFFF')");

                entity.Property(e => e.NoteText).HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => new { d.AccountId, d.CategoryId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notes_Categories");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial (ModelBuilder modelBuilder);
    }
}
