using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Controllers.Authentification.DTOs;
using System.Net;

namespace NoteBook.Controllers.Authentification
{
    [Route("api/[controller]")]
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
            await _authService.SignupNewAccountAsync(
                signUpModel.UserName, 
                signUpModel.Password,
                signUpModel.Email);

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login ([FromBody] LoginDto loginModel)
        {
            var loginSucess = await _authService.LoginAsync(loginModel.UserName, loginModel.Password);
            if (!loginSucess) return BadRequest( );
            return Ok(_jwtService.GetJwtToken(loginModel.UserName));
        }
    }
}
