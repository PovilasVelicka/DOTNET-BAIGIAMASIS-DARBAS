namespace NoteBook.Common.Interfaces.DTOs
{
    public interface IServiceResponseDto
    {
        bool IsSuccess { get; }
        int StatuCode { get; }
        string Message { get; }
    }
}
