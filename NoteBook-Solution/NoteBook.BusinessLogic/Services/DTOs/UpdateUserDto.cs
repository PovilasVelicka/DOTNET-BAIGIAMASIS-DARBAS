using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Entity.Models;
using System.Net;

namespace NoteBook.BusinessLogic.Services.DTOs
{
    internal class UpdateUserDto : IResponse<Account>
    {
        public bool IsSuccess { get; }

        public string Message { get; }

        public Account? Object { get; }

        public int StatuCode { get; }

        public UpdateUserDto (Account? account)
        {
            IsSuccess = account != null;
            Message = account != null ? "" : "Not found";
            Object = account;
            StatuCode = account != null ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound;
        }
    }
}
