using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Controllers.AuthController.DTOs;
using NoteBook.Exstentions;

namespace NoteBook.Controllers.AuthController
{
    [Route("notebook")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        private readonly ILogger<AuthController> _logger;

        public AuthController (IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;

            _logger = logger;
        }

        [HttpPost("signup")]
        public async Task<ActionResult> SignUp ([FromBody] SignupDto signUpModel)
        {
            var serviceResponse = await _authService.SignupNewAccountAsync(
                  signUpModel.UserName,
                  signUpModel.Password,
                  signUpModel.Email,
                  signUpModel.FirstName,
                  signUpModel.LastName);

            return this.GetActionResult(serviceResponse, serviceResponse.Object);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login ([FromBody] LoginDto loginModel)
        {
            var serviceResponse = await _authService.LoginAsync(loginModel.UserName, loginModel.Password);
            return this.GetActionResult(serviceResponse, serviceResponse.Object);
        }
    }
}
