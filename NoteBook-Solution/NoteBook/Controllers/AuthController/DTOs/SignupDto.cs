﻿namespace NoteBook.Controllers.AuthController.DTOs
{
    public class SignupDto
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; }=null!;
        public string LastName { get; set; } = null!;

    }
}
