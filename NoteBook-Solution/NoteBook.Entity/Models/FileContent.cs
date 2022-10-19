using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteBook.Entity.Models
{
    [Table("FilesContents", Schema = "general")]
    public class FileContent
    {
        public FileContent ( )
        {
            Files = new HashSet<FileHead>( );
        }

        [Key]
        [StringLength(40)]
        public string Id { get; set; } = null!;

        public byte[ ] Bites { get; set; } = null!;
       
        public virtual ICollection<FileHead> Files { get; set; } 
    }
}
