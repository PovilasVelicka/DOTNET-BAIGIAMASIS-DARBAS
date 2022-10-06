using NoteBook.Common.Interfaces.DTOs;

namespace NoteBook.BusinessLogic.Services.AccountServices.DTOs
{
    internal class UpdateAccountDto : IResponse<string>
    {
        public bool IsSuccess { get; }

        public string Message { get; } = string.Empty;

        public string? Object { get; }

        public int StatuCode { get; }

        public UpdateAccountDto(bool isSuccess, string message, int statuCode)
        {
            IsSuccess = isSuccess;
            Message = message;
            Object = null;
            StatuCode = statuCode;
        }
    }
}
