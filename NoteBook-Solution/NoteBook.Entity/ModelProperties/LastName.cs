using System.ComponentModel.DataAnnotations;

namespace NoteBook.Entity.ModelProperties
{
    public class LastName
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Value { get; set; } = null!;
    }
}
