using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace NoteBook.Entity.Models
{
    [Table("FirstNames", Schema = "general")]
    [Index("Value", Name = "UI_FirstName", IsUnique = true)]
    public partial class FirstName
    {
        public FirstName ( )
        {
            AboutUsers = new HashSet<AboutUser>( );
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Value { get; set; } = null!;

        [InverseProperty("FirstName")]
        public virtual ICollection<AboutUser> AboutUsers { get; set; }

        public FirstName (string firstname)
        {
            AboutUsers = new HashSet<AboutUser>( );
            Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(firstname.ToLower( ));
        }
    }

}
