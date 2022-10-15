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

        [Key]
        public Guid Id { get; set; }
        [StringLength(150)]
        public string LoginName { get; set; } = null!;
        public byte[ ] PasswordHash { get; set; } = null!;
        public byte[ ] PasswordSalt { get; set; } = null!;
        [StringLength(50)]
        public Role Role { get; set; }
        public bool Disabled { get; set; }



        public int EmailId { get; set; }
        public Guid? UserId { get; set; }

        [ForeignKey("EmailId")]
        [InverseProperty("Accounts")]
        public virtual Email Email { get; set; } = null!;

        [ForeignKey("UserId")]
        [InverseProperty("Account")]
        public virtual User User { get; set; } = null!;
    }
}
