﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoteBook.Entity.Models;

#nullable disable

namespace NoteBook.AccessData.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NoteBook.Entity.ModelProperties.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LocalPart")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("NoteBook.Entity.ModelProperties.FirstName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("FirstName");
                });

            modelBuilder.Entity("NoteBook.Entity.ModelProperties.LastName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("LastName");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.AboutUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FirstNameId")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("LastNameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirstNameId");

                    b.HasIndex("LastNameId");

                    b.ToTable("AboutUsers", "notebook");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EmailId")
                        .HasColumnType("int");

                    b.Property<bool>("EmailVerified")
                        .HasColumnType("bit");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmailId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.Category", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "Id");

                    b.ToTable("Categories", "notebook");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("varchar(9)")
                        .HasDefaultValueSql("('#000000FF')");

                    b.Property<bool>("Complete")
                        .HasColumnType("bit");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("DoPriority")
                        .HasColumnType("int");

                    b.Property<string>("Fill")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("varchar(9)")
                        .HasDefaultValueSql("('#FFFFFFFF')");

                    b.Property<string>("NoteText")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<DateTimeOffset?>("Reminder")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("UseReminder")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "CategoryId");

                    b.HasIndex(new[] { "Id" }, "IX_Notes");

                    b.ToTable("Notes", "notebook");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.AboutUser", b =>
                {
                    b.HasOne("NoteBook.Entity.ModelProperties.FirstName", "FirstName")
                        .WithMany()
                        .HasForeignKey("FirstNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NoteBook.Entity.ModelProperties.LastName", "LastName")
                        .WithMany()
                        .HasForeignKey("LastNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FirstName");

                    b.Navigation("LastName");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.Account", b =>
                {
                    b.HasOne("NoteBook.Entity.ModelProperties.Email", "Email")
                        .WithMany()
                        .HasForeignKey("EmailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Email");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.Note", b =>
                {
                    b.HasOne("NoteBook.Entity.Models.AboutUser", "AboutUser")
                        .WithMany("Notes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NoteBook.Entity.Models.Category", "Category")
                        .WithMany("Notes")
                        .HasForeignKey("UserId", "CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_Notes_Categories");

                    b.Navigation("AboutUser");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.AboutUser", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.Category", b =>
                {
                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
