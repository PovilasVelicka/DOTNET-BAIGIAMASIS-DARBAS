using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteBook.Entity.Models
{
    [Table("Categories", Schema = "notebook")]
    public partial class Category
    {
        public Category ( )
        {
            Notes = new HashSet<Note>( );
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; } = null!;
        public bool Deleted { get; set; }
        [Key]
        public int UserId { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Note> Notes { get; set; }
    }
}
