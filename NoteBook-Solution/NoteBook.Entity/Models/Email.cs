using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utils.Extensions;
namespace NoteBook.Entity.Models
{
    [Table("Emails", Schema = "general")]
    [Index("Value", Name = "UI_Emails", IsUnique = true)]
    public class Email
    {
        public Email ( )
        {
            Accounts = new HashSet<Account>( );
        }

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

        [InverseProperty("Email")]
        public virtual ICollection<Account> Accounts { get; set; }



        public Email (string email)
        {
            Accounts = new HashSet<Account>( );
            if (email.IsValidEmail(localPart: out string lp, domain: out string dm))
            {
                LocalPart = lp;
                Domain = dm;
                Value = email.ToLower( );
            }
        }
    }
}
