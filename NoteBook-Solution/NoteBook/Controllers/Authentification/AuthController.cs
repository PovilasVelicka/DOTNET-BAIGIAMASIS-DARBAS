using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Controllers.Authentification.DTOs;
using NoteBook.Entity.Models;

namespace NoteBook.Controllers.Authentification
{
    [Route("notebook")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;
        private readonly ILogger<AuthController> _logger;
        public AuthController (IAuthService authService, IJwtService jwtService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _jwtService = jwtService;
            _logger = logger;
        }

        [HttpPost("signup")]
        public async Task<ActionResult> SignUp ([FromBody] SignupDto signUpModel)
        {
            var serviceResponse = await _authService.SignupNewAccountAsync(
                  signUpModel.UserName,
                  signUpModel.Password,
                  signUpModel.Email);

            if (serviceResponse.IsSuccess)
            {
                _logger.Log(
                    LogLevel.Information,
                    $"New user created: " +
                    $"\n\tId: {serviceResponse.Object!.Id}" +
                    $"\n\tName: {serviceResponse.Object!.LoginName}");
            }
            return GetResponse(serviceResponse);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login ([FromBody] LoginDto loginModel)
        {
            var serviceResponse = await _authService.LoginAsync(loginModel.UserName, loginModel.Password);
            return GetResponse(serviceResponse);
        }

        private ObjectResult GetResponse (IResponse<Account> serviceResponse)
        {
            if (serviceResponse.IsSuccess)
            {
                return StatusCode(
                    serviceResponse.StatuCode,
                    new ResponseDto
                    {
                        IsSuccess = serviceResponse.IsSuccess,
                        Error = serviceResponse.Message,
                        Token = _jwtService.GetJwtToken(serviceResponse.Object!)
                    });
            }
            else
            {
                return StatusCode(
                   serviceResponse.StatuCode,
                   new ResponseDto
                   {
                       IsSuccess = serviceResponse.IsSuccess,
                       Error = serviceResponse.Message,
                       Token = null,
                   });
            }

        }
    }
}
