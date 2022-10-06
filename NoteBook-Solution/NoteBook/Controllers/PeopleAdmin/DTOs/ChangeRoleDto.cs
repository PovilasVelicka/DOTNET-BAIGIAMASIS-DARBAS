using NoteBook.Entity.Enums;

namespace NoteBook.Controllers.PeopleAdmin.DTOs
{
    public class ChangeRoleDto
    {
        public Guid UserId { get; set; }
        public Role Role { get; set; }
    }
}
