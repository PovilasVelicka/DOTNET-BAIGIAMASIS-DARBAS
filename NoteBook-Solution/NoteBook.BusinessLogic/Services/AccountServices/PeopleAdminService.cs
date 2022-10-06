using NoteBook.BusinessLogic.Services.AccountServices.DTOs;
using NoteBook.Common.Interfaces.DataAccess;
using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;
using System.Net;

namespace NoteBook.BusinessLogic.Services.AccountServices
{
    public class PeopleAdminService : IPeopleAdminService
    {
        private readonly IAccountsRepository _repository;
        public PeopleAdminService (IAccountsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponse<string>> ChangeUserRoleAsync (string loginName, Role role)
        {
            var user = await _repository.GetByNameAsync(loginName);
            if (user == null) return new UpdateAccountDto(false, "User not find", (int)HttpStatusCode.NotFound);
            user.Role = role;
            await _repository.SaveChangesAsync( );
            return new UpdateAccountDto(true, "", (int)HttpStatusCode.OK);
        }

        public async Task<IResponse<List<Account>>> FindUsersAsync (Role role)
        {
            var users = await _repository.GetByRoleAsync(role);
            return new GetUsersDto(users);
        }

        public async Task<IResponse<List<Account>>> FindUsersAsync (string nameSubstring)
        {
            var users = await _repository.GetByNameSubstringAsync(nameSubstring);
            return new GetUsersDto(users);
        }
    }
}
