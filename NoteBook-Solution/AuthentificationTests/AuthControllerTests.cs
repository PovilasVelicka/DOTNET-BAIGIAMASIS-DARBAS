using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NoteBook.BusinessLogic.DTOs;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Controllers.Authentification;
using NoteBook.Controllers.Authentification.DTOs;
using System.Net;
using NoteBook.Entity.Models;
namespace AuthentificationTests
{
    public class AuthControllerTests
    {
        private readonly Mock<IAuthService> _authServiceMock;
        private readonly Mock<IJwtService> _jwtServiceMock;
        private readonly Mock<ILogger<AuthController>> _logger;
        private readonly AuthController _sut;
        public AuthControllerTests ( )
        {
            _authServiceMock = new Mock<IAuthService>( );
            _jwtServiceMock = new Mock<IJwtService>( );
            _logger = new Mock<ILogger<AuthController>>( );
            _sut = new AuthController(
                _authServiceMock.Object,
                _jwtServiceMock.Object,
                _logger.Object);
        }

        [Theory, AutoData]
        public async Task SignUp_WhenUserExists_ResponseBadRequest (SignupDto signupDto)
        {
            _authServiceMock
                .Setup(a => a.SignupNewAccountAsync(It.IsAny<string>( ), It.IsAny<string>( ), It.IsAny<string>( )))
                .ReturnsAsync(new AuthResponseDto(null, "User name or email exists", 400));

            var response = await _sut.SignUp(signupDto);
            var responseObject = response as ObjectResult;
            Assert.Equal((int)HttpStatusCode.BadRequest, responseObject!.StatusCode);
        }

        [Theory, AutoData]
        public async Task SignUp_WhenUserNotExists_ResponseOk (SignupDto signupDto)
        {
            _authServiceMock
                .Setup(a => a.SignupNewAccountAsync(signupDto.UserName, signupDto.Password,signupDto.Email))
                .ReturnsAsync(new AuthResponseDto(new Account(), "UserCreated", 200));

            var response = await _sut.SignUp(signupDto);
            var responseObject = response as ObjectResult;
            
            Assert.Equal((int)HttpStatusCode.OK, responseObject!.StatusCode);
        }
    }
}
