
using NoteBook.BusinessLogic.Services.DTOs;
using NoteBook.Common.Interfaces.DataAccess;
using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Entity.Enums;
using NoteBook.Entity.Models;

namespace NoteBook.BusinessLogic.Services.PeopleAdmin
{
    internal class PeopleAdminService : IPeopleAdminService
    {
        private readonly IAccountsRepository _repository;
        public PeopleAdminService (IAccountsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponse<Account>> ChangeUserRoleAsync (string loginName, Role role)
        {
            var user = await _repository.GetByNameAsync(loginName);
            if (user != null)
            {
                user.Role = role;
                await _repository.SaveChangesAsync();
            }
            return new UpdateUserDto(user);
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
