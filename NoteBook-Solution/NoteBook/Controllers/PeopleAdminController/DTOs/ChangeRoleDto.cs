using NoteBook.Entity.Enums;

namespace NoteBook.Controllers.PeopleAdminController.DTOs
{
    public class ChangeRoleDto
    {
        public String UserLogin { get; set; } = null!;
        public Role Role { get; set; }
    }
}
