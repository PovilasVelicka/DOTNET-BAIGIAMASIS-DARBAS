using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteBook.Entity.Models
{
    [Table("Files", Schema = "general")]
    public class FileHead
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string ContentType { get; set; } = null!;

        [StringLength(256)]
        public string FileName { get; set; } = null!;

        [ForeignKey("FileContent")]
        public string FileContentId { get; set; } = null!;


        [InverseProperty("Files")]
        public virtual FileContent FileContent { get; set; } = null!;
    }
}
