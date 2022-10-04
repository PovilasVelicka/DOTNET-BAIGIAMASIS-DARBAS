using System.ComponentModel.DataAnnotations;
using Utils.Extensions;
namespace NoteBook.Entity.ModelProperties
{
    public class Email
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        public string LocalPart { get; set; } = null!;

        [StringLength(150)]
        public string Domain { get; set; } = null!;

        public Email ( ) { }
        public Email (string email)
        {
            if (email.IsValidEmail(localPart: out string lp, domain: out string dm))
            {
                LocalPart = lp;
                Domain = dm;
            }
        }
    }

}
