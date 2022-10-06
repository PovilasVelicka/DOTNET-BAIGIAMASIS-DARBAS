using Microsoft.AspNetCore.Authorization;
using NoteBook.Entity.Enums;

namespace NoteBook.Controllers
{
    public class AuthorizeRoles : AuthorizeAttribute
    {
        public AuthorizeRoles (params Role[ ] roles)
        {
            var allowedRolesAsStrings = roles.Select(x => Enum.GetName(typeof(Role), x));
            Roles = string.Join(",", allowedRolesAsStrings);
        }
    }
}
