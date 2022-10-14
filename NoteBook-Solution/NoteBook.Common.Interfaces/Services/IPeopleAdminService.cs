using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;

namespace NoteBook.Common.Interfaces.Services
{
    public interface IPeopleAdminService
    {
        Task<IResponse<string>> ChangeUserRoleAsync (string loginName, Role role);
        Task<IResponse<List<Account>>> FindUsersAsync (Role roles);
        Task<IResponse<List<Account>>> FindUsersAsync (string nameSubstring);
    }
}
