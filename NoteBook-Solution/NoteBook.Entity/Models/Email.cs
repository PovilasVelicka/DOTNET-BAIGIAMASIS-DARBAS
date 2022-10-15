using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utilites.Exstensions;

namespace NoteBook.Entity.Models
{
    [Table("Emails", Schema = "general")]
    [Index("Value", Name = "UI_Emails", IsUnique = true)]
    public class Email
    {

        [Key]
        public int Id { get; set; }
        [StringLength(120)]
        [Unicode(false)]
        public string LocalPart { get; set; } = null!;
        [StringLength(120)]
        [Unicode(false)]
        public string Domain { get; set; } = null!;
        [StringLength(256)]
        [Unicode(false)]
        public string Value { get; set; } = null!;
        public bool EmailVerified { get; set; }

        [InverseProperty("Email")]
        public virtual Account Accounts { get; set; } = null!;
        public Email ( ) { }
        public Email (string email)
        {
            if (email.IsValidEmail(localPart: out string lp, domain: out string dm))
            {
                LocalPart = lp;
                Domain = dm;
                Value = email.ToLower( );
                EmailVerified=false;
            }
        }
    }
}
