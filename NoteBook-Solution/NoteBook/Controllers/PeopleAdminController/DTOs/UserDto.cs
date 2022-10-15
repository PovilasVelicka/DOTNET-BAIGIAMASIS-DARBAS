using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;

namespace NoteBook.Controllers.PeopleAdminController.DTOs
{
    public class UserDto
    {
        public string LoginName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Role UserRole { get; set; }
        public UserDto ( ) { }
        public UserDto ( Account? account)
        {
            if (account == null) return;
            LoginName = account.LoginName;
            Email = account.Email.Value;
            UserRole = account.Role;
        }
    }
}
