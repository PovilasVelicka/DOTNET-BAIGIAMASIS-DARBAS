namespace NoteBook.Controllers.Authentification.DTOs
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; } = string.Empty;
        public string? Token { get; set; }
    }
}
