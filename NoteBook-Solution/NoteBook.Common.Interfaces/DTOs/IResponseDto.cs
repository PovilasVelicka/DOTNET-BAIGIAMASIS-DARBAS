using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.Common.Interfaces.DTOs
{
    public interface IResponseDto<T>
    {
        bool IsSuccess { get; }
        string  Message { get; }
        T? Object { get; }
        int StatuCode { get; }
    }
}
