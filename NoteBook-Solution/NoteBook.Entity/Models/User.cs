using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NoteBook.Entity.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NoteBook.Entity.Models
{
    [Table("Users", Schema = "notebook")]
    [Index("FirstNameId", Name = "IX_Users_FirstNameId")]
    [Index("LastNameId", Name = "IX_Users_LastNameId")]
    public partial class User
    {
        public User ( )
        {
            Categories = new HashSet<Category>( );
            Notes = new HashSet<Note>( );
        }

        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public Gender Gender { get; set; }
        public int FirstNameId { get; set; }
        public int LastNameId { get; set; }

        [ForeignKey("FirstNameId")]
        [InverseProperty("Users")]
        public virtual FirstName FirstName { get; set; } = null!;

        [ForeignKey("LastNameId")]
        [InverseProperty("Users")]
        public virtual LastName LastName { get; set; } = null!;

        [InverseProperty("Users")]
        public virtual ICollection<Category> Categories { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Note> Notes { get; set; }

        [InverseProperty("User")]
        public virtual Account Account { get; set; } = null!;


     
        public virtual int? FileId { get; set; }       
        public virtual FileHead? File { get; set; }



    }
}
