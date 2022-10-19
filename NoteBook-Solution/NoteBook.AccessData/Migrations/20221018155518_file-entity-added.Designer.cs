﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoteBook.Entity.Models;

#nullable disable

namespace NoteBook.AccessData.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221018155518_file-entity-added")]
    partial class fileentityadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CategoryUser", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("CategoryUser", "notebook");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<int>("EmailId")
                        .HasColumnType("int");

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

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmailId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.HasIndex(new[] { "EmailId" }, "IX_Accounts_EmailId")
                        .HasDatabaseName("IX_Accounts_EmailId1");

                    b.HasIndex(new[] { "LoginName" }, "UI_LoginName")
                        .IsUnique();

                    b.ToTable("Accounts", "sequrity");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.Category", b =>
                {
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

                    b.HasKey("Id");

                    b.ToTable("Categories", "notebook");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(120)
                        .IsUnicode(false)
                        .HasColumnType("varchar(120)");

                    b.Property<bool>("EmailVerified")
                        .HasColumnType("bit");

                    b.Property<string>("LocalPart")
                        .IsRequired()
                        .HasMaxLength(120)
                        .IsUnicode(false)
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Value" }, "UI_Emails")
                        .IsUnique();

                    b.ToTable("Emails", "general");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.FirstName", b =>
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

                    b.HasIndex(new[] { "Value" }, "UI_FirstName")
                        .IsUnique();

                    b.ToTable("FirstNames", "general");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.LastName", b =>
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

                    b.HasIndex(new[] { "Value" }, "UI_LastName")
                        .IsUnique();

                    b.ToTable("LastNames", "general");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
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

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTimeOffset?>("Reminder")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("UseReminder")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Notes", "notebook");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FirstNameId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("LastNameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "FirstNameId" }, "IX_Users_FirstNameId");

                    b.HasIndex(new[] { "LastNameId" }, "IX_Users_LastNameId");

                    b.ToTable("Users", "notebook");
                });

            modelBuilder.Entity("CategoryUser", b =>
                {
                    b.HasOne("NoteBook.Entity.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NoteBook.Entity.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NoteBook.Entity.Models.Account", b =>
                {
                    b.HasOne("NoteBook.Entity.Models.Email", "Email")
                        .WithOne("Accounts")
                        .HasForeignKey("NoteBook.Entity.Models.Account", "EmailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NoteBook.Entity.Models.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("NoteBook.Entity.Models.Account", "UserId");

                    b.Navigation("Email");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.Note", b =>
                {
                    b.HasOne("NoteBook.Entity.Models.Category", "Category")
                        .WithMany("Notes")
                        .HasForeignKey("CategoryId");

                    b.HasOne("NoteBook.Entity.Models.User", "User")
                        .WithMany("Notes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.User", b =>
                {
                    b.HasOne("NoteBook.Entity.Models.FirstName", "FirstName")
                        .WithMany("Users")
                        .HasForeignKey("FirstNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NoteBook.Entity.Models.LastName", "LastName")
                        .WithMany("Users")
                        .HasForeignKey("LastNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FirstName");

                    b.Navigation("LastName");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.Category", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.Email", b =>
                {
                    b.Navigation("Accounts")
                        .IsRequired();
                });

            modelBuilder.Entity("NoteBook.Entity.Models.FirstName", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.LastName", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("NoteBook.Entity.Models.User", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();

                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
