﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NoteBook.Entity.Models
{
    public partial class AppDbContext : IdentityDbContext
    {
        public AppDbContext ( ) { }

        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<AboutUser> AboutUsers { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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

                entity.HasOne(d => d.AboutUser)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Notes_Users");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => new { d.UserId, d.CategoryId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notes_Categories");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial (ModelBuilder modelBuilder);
    }
}
