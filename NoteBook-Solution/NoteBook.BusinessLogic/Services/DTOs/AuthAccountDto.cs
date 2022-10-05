using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.BusinessLogic.Services.DTOs
{
    internal class AuthAccountDto
    {
        public Guid Id { get; set; }
        public string LoginName { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string  Email { get; set; } = null!;
    }
}
