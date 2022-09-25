﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteBook.Entity.Models
{
    [Table("Notes", Schema = "notebook")]
    [Index("Id", Name = "IX_Notes")]
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
        public bool Complete { get; set; }
        public bool Deleted { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId,CategoryId")]
        [InverseProperty("Notes")]
        public virtual Category Category { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("Notes")]
        public virtual AboutUser AboutUser { get; set; } = null!;
    }
}
