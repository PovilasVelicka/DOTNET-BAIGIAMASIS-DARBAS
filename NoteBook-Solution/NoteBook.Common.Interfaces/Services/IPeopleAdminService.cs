using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;

namespace NoteBook.Common.Interfaces.Services
{
    public interface IPeopleAdminService
    {
        Task<ServiceResponseDto<Account>> ChangeUserRoleAsync (string loginName, Role role);
        Task<ServiceResponseDto<List<Account>>> FindUsersAsync (Role roles);
        Task<ServiceResponseDto<List<Account>>> FindUsersAsync (string nameSubstring);
        ServiceResponseDto<Account> GetById (Guid Id);
    }
}
