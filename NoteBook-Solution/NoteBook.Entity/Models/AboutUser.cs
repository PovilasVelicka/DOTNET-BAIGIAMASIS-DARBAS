using NoteBook.Entity.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteBook.Entity.Models
{
    [Table("AboutUsers", Schema = "notebook")]
    public partial class AboutUser
    {
        public AboutUser ( )
        {
            Notes = new HashSet<Note>( );
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        public Gender Gender { get; set; }
        [StringLength(450)]
        public string AspNetUserId { get; set; } = null!;

        [InverseProperty("AboutUser")]
        public virtual ICollection<Note> Notes { get; set; }
    }
}
