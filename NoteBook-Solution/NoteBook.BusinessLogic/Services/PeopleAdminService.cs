using Microsoft.EntityFrameworkCore.ChangeTracking;
using NoteBook.BusinessLogic.DTOs;
using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;
using System.Net;

namespace NoteBook.BusinessLogic.Services
{
    public class PeopleAdminService : IPeopleAdminService
    {
        private readonly IAccountsRepository _accountsRepository;
        public PeopleAdminService (IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public async Task<IResponseDto<Account>> ChangeUserRoleAsync (string loginName, Role role)
        {
            var account  = await _accountsRepository.GetAsync(loginName);
            if (account == null) return new AuthResponseDto(null, "User not found", (int)HttpStatusCode.NotFound);
            account.Role = role;
            await _accountsRepository.SaveChangesAsync( );
            return new AuthResponseDto(account, (int)HttpStatusCode.OK);
        }
    }
}
