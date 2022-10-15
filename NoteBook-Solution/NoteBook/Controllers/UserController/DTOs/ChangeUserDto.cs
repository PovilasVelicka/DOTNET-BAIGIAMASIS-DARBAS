using Microsoft.AspNetCore.Authorization;
using NoteBook.Entity.Enums;

namespace NoteBook.Controllers.UserController.DTOs
{
    public class ChangeUserDto: AboutUserDto
    {
        public Guid UserId { get; set; }

        public Gender Gender { get; set; } 
    }
}
