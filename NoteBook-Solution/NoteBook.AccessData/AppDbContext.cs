using Microsoft.EntityFrameworkCore;
using NoteBook.Entity.Enums;

namespace NoteBook.Entity.Models
{
    internal partial class AppDbContext : DbContext
    {
        public AppDbContext ( ) { }

        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Email> Emails { get; set; } = null!;
        public virtual DbSet<FirstName> FirstNames { get; set; } = null!;
        public virtual DbSet<LastName> LastNames { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;
        public virtual DbSet<FileHead> Files { get; set; } = null!;
        public virtual DbSet<FileContent> FilesContents { get; set; } = null!;

        public override Task<int> SaveChangesAsync (CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever( );

                entity.Property(p => p.Role)
                    .HasConversion(
                        u => u.ToString( ),
                        d => (Role)Enum.Parse(typeof(Role), d));

                entity.Property(p => p.UserId).IsRequired(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Gender)
                    .HasConversion(
                        u => u.ToString( ),
                        d => (Gender)Enum.Parse(typeof(Gender), d));
            });


            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd( );


            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.Color).HasDefaultValueSql("('#000000FF')");

                entity.Property(e => e.Fill).HasDefaultValueSql("('#FFFFFFFF')");

                entity.Property(e => e.NoteText).HasDefaultValueSql("(N'')");

                entity.Property(e => e.CategoryId).IsRequired(false);



                entity.Property(p => p.Priority)
               .HasConversion(
                   u => u.ToString( ),
                   d => (Priority)Enum.Parse(typeof(Priority), d));
            });

            //modelBuilder.Entity<File>(entity =>          
            //        entity.Property(e => e.FileContentId).IsRequired(false)              
            //);

            //modelBuilder.Entity<FileContent>( )
            //    .HasMany(e => e.Files)
            //    .WithOne(e => e.FileContent)
            //    .OnDelete(DeleteBehavior.SetNull);


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial (ModelBuilder modelBuilder);
    }
}
