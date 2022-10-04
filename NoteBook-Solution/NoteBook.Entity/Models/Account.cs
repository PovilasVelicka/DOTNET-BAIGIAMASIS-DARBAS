using NoteBook.Entity.ModelProperties;
using System.ComponentModel.DataAnnotations;

namespace NoteBook.Entity.Models
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(150)]
        [Required]
        public string LoginName { get; set; } = null!; 
        public Email Email { get; set; } = null!;
        public bool EmailVerified { get; set; }
        public byte[ ] PasswordHash { get; set; } = null!;
        public byte[ ] PasswordSalt { get; set; } = null!;
        
    }
}
