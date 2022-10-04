using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NoteBook.Entity.Enums;
using NoteBook.Entity.ModelProperties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

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
    
        public FirstName FirstName { get; set; } = null!;

        public LastName LastName { get; set; } = null!;
        public Gender Gender { get; set; }


        [InverseProperty("AboutUser")]
        public virtual ICollection<Note> Notes { get; set; }
    }
}
