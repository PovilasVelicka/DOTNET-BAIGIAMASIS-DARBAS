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
        public LastName ( )
        {
            Users = new HashSet<User>( );
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Value { get; set; } = null!;

        [InverseProperty("LastName")]
        public virtual ICollection<User> Users { get; set; }

        public LastName (string lastname)
        {
            Users = new HashSet<User>( );
            Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lastname.ToLower( ));
        }
    }
}
