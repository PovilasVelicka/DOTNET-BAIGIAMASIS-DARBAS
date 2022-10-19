using Microsoft.EntityFrameworkCore;
using NoteBook.Entity.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteBook.Entity.Models
{
    [Table("Notes", Schema = "notebook")]

    public partial class Note
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; } = null!;
        public string NoteText { get; set; } = null!;
        public DateTimeOffset? Reminder { get; set; }
        public bool UseReminder { get; set; }
        [StringLength(9)]
        [Unicode(false)]
        public string Fill { get; set; } = null!;
        [StringLength(9)]
        [Unicode(false)]
        public string Color { get; set; } = null!;
        [StringLength(50)]
        public Priority Priority { get; set; }
        public bool Complete { get; set; }
        public bool Deleted { get; set; }

    
        public int? CategoryId { get; set; }
        public Guid UserId { get; set; }


        [ForeignKey("UserId")]
        [InverseProperty("Notes")]
        public virtual User User { get; set; } = null!;


        [ForeignKey("CategoryId")]
        [InverseProperty("Notes")]
        public virtual Category? Category { get; set; } = null!;

        public virtual int? FileId { get; set; }
        public virtual FileHead? File { get; set; }
    }
}
