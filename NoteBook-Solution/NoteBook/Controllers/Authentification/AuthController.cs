using Microsoft.AspNetCore.Mvc;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Controllers.Authentification.DTOs;
using NoteBook.Entity.Models;
using System.Net;

namespace NoteBook.Controllers.Authentification
{
    [Route("notebook")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;

        public AuthController (IAuthService authService, IJwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpPost("signup")]
        public async Task<ActionResult> SignUp ([FromBody] SignupDto signUpModel)
        {
          var account=  await _authService.SignupNewAccountAsync(
                signUpModel.UserName,
                signUpModel.Password,
                signUpModel.Email);
            if (!account.IsSuccess) return StatusCode((int)HttpStatusCode.BadRequest,account.Message);

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login ([FromBody] LoginDto loginModel)
        {
            var response = await _authService.LoginAsync(loginModel.UserName, loginModel.Password);
            if (!response.IsSuccess) return StatusCode(response.StatuCode, response.Message);
            return StatusCode(response.StatuCode, _jwtService.GetJwtToken(loginModel.UserName,response.Object!.Role.ToString()));
        }
    }
}
