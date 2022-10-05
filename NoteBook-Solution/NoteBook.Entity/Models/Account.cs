using Microsoft.EntityFrameworkCore;
using NoteBook.Entity.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteBook.Entity.Models
{
    [Table("Accounts", Schema = "sequrity")]
    [Index("EmailId", Name = "IX_Accounts_EmailId")]
    [Index("LoginName", Name = "UI_LoginName", IsUnique = true)]
    public partial class Account
    {
        public Account ( )
        {
            Notes = new HashSet<Note>( );
            AboutUsers = new HashSet<AboutUser>( );
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(150)]
        public string LoginName { get; set; } = null!;
        public int EmailId { get; set; }
        public bool EmailVerified { get; set; }
        public byte[ ] PasswordHash { get; set; } = null!;
        public byte[ ] PasswordSalt { get; set; } = null!;
        public Role Role { get; set; }
        public bool Disabled { get; set; }

        [ForeignKey("EmailId")]
        [InverseProperty("Accounts")]
        public virtual Email Email { get; set; } = null!;
        [InverseProperty("Account")]
        public virtual ICollection<AboutUser> AboutUsers { get; set; }

        [InverseProperty("Account")]
        public virtual ICollection<Note> Notes { get; set; }
    }
}
