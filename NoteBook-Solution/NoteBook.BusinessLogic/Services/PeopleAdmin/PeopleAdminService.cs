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

        public async Task<ServiceResponseDto<Account>> ChangeUserRoleAsync (string loginName, Role role)
        {
            var user = await _repository.GetByNameAsync(loginName);
            if (user != null)
            {
                user.Role = role;
                _repository.Update(user);
                await _repository.SaveChangesAsync( );
            }
            return new ServiceResponseDto<Account>(user);
        }

        public async Task<ServiceResponseDto<List<Account>>> FindUsersAsync (Role role)
        {
            var users = await _repository.GetByRoleAsync(role);
            return new ServiceResponseDto<List<Account>>(users);
        }

        public async Task<ServiceResponseDto<List<Account>>> FindUsersAsync (string nameSubstring)
        {
            var users = await _repository.GetByNameSubstringAsync(nameSubstring);
            return new ServiceResponseDto<List<Account>>(users);
        }
    }
}
