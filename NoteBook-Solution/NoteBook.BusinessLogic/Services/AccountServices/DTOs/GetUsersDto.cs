using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Entity.Models;
using System.Net;

namespace NoteBook.BusinessLogic.Services.AccountServices.DTOs
{
    internal class GetUsersDto : IResponse<List<Account>>
    {
        public bool IsSuccess { get; }

        public string Message { get; }

        public List<Account>? Object { get; }

        public int StatuCode { get; }

        public GetUsersDto(List<Account>? accounts)
        {
            IsSuccess = accounts != null;
            Message = accounts != null ? "" : "Not found";
            Object = accounts;
            StatuCode = accounts != null ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound;
        }
    }
}
