using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace NoteBook.Entity.Models
{
    [Table("LastNames", Schema = "general")]
    [Index("Value", Name = "UI_LastName", IsUnique = true)]
    public partial class LastName
    {
        public LastName()
        {
            AboutUsers = new HashSet<AboutUser>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Value { get; set; } = null!;

        [InverseProperty("LastName")]
        public virtual ICollection<AboutUser> AboutUsers { get; set; }

        public LastName(string lastname)
        {
            AboutUsers = new HashSet<AboutUser>();
            Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lastname.ToLower());
        }
    }
}
