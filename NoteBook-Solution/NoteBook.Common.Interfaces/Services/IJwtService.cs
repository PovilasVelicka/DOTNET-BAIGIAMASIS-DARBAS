using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.Common.Interfaces.Services
{
    public interface IJwtService
    {
        string GetJwtToken (string username,string role);
    }
}
