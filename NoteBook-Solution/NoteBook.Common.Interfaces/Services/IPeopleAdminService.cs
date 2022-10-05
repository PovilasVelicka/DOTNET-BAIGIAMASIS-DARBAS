using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.Common.Interfaces.Services
{
    public interface IPeopleAdminService
    {
        Task<IResponseDto<Account>> ChangeUserRoleAsync (string loginName, Role role);
    }
}
