using NoteBook.Entity.Models;

namespace NoteBook.Controllers.UserController.DTOs
{
    public class AboutUserDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public AboutUserDto ( ) { }
   
    }
}
