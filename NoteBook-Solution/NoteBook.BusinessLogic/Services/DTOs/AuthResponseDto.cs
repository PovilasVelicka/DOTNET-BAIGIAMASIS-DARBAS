using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Entity.Models;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("AuthentificationTests")]

namespace NoteBook.BusinessLogic.DTOs
{
    internal class AuthResponseDto : IResponse<Account>
    {
        public bool IsSuccess { get; }

        public string Message { get; }

        public Account? Object { get; }
        public int StatuCode { get;  }

        public AuthResponseDto (Account? account,  string message, int statuCode)
        {
            Message = message;
            IsSuccess = account != null;
            Object = account;
            StatuCode = statuCode;
        }

        public AuthResponseDto (Account account, int statuCode)
        {
            Message = "";
            IsSuccess = true;
            Object = account;
            StatuCode = statuCode;
        }
    }
}
