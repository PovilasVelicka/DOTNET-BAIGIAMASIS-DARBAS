using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Entity.Models;

namespace NoteBook.Controllers.Authentification.DTOs
{
    internal class ResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; } = string.Empty;
        public string? Token { get; set; }

    }
}
