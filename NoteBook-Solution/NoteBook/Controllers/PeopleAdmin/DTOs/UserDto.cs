using NoteBook.Entity.Enums;

namespace NoteBook.Controllers.PeopleAdmin.DTOs
{
    public class UserDto
    {
        public string LoginName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Role UserRole { get; set; }
    }
}
