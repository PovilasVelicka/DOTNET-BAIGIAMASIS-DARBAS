using NoteBook.Entity.Enums;

namespace NoteBook.Controllers.PeopleAdmin.DTOs
{
    public class ChangeRoleDto
    {
        public String UserLogin { get; set; } = null!;
        public Role Role { get; set; }
    }
}
