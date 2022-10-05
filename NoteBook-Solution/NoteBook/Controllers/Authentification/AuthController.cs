﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Controllers.Authentification.DTOs;
using System.Net;

namespace NoteBook.Controllers.Authentification
{
    [Route("notebook")]
    [ApiController]
    [AllowAnonymous]
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
            var response = await _authService.SignupNewAccountAsync(
                  signUpModel.UserName,
                  signUpModel.Password,
                  signUpModel.Email);
            if (!response.IsSuccess) return StatusCode(response.StatuCode, response);

            return StatusCode(response.StatuCode,response.Message);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login ([FromBody] LoginDto loginModel)
        {
            var response = await _authService.LoginAsync(loginModel.UserName, loginModel.Password);
            if (!response.IsSuccess) return StatusCode(response.StatuCode, response.Message);
            return StatusCode(
                response.StatuCode,
                _jwtService.GetJwtToken(
                    response.Object!.LoginName,
                    response.Object!.Role.ToString( )));
        }
    }
}
