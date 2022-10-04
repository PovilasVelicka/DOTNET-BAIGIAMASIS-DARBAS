using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NoteBook.Entity.Models
{
    [Table("AboutUsers", Schema = "notebook")]
    [Index("AccountId", Name = "IX_AboutUsers_AccountId")]
    [Index("FirstNameId", Name = "IX_AboutUsers_FirstNameId")]
    [Index("LastNameId", Name = "IX_AboutUsers_LastNameId")]
    public partial class AboutUser
    {
        public AboutUser ( )
        {
            Notes = new HashSet<Note>( );
        }

        [Key]
        public Guid Id { get; set; }
        public int FirstNameId { get; set; }
        public int LastNameId { get; set; }
        public int Gender { get; set; }
        public Guid AccountId { get; set; }

        [ForeignKey("AccountId")]
        [InverseProperty("AboutUsers")]
        public virtual Account Account { get; set; } = null!;
        [ForeignKey("FirstNameId")]
        [InverseProperty("AboutUsers")]
        public virtual FirstName FirstName { get; set; } = null!;
        [ForeignKey("LastNameId")]
        [InverseProperty("AboutUsers")]
        public virtual LastName LastName { get; set; } = null!;
        [InverseProperty("User")]
        public virtual ICollection<Note> Notes { get; set; }
    }
}
