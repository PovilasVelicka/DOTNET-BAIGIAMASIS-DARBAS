using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NoteBook.Common.Interfaces.DTOs;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Controllers.AuthController;
using NoteBook.Controllers.AuthController.DTOs;
using NoteBook.Entity.Models;
using System.Net;

namespace AuthentificationTests
{
    public class AuthControllerTests
    {
        private readonly Mock<IAuthService> _authServiceMock;
        private readonly Mock<ILogger<AuthController>> _logger;
        private readonly AuthController _sut;
        public AuthControllerTests ( )
        {
            _authServiceMock = new Mock<IAuthService>( );

            _logger = new Mock<ILogger<AuthController>>( );
            _sut = new AuthController(
                _authServiceMock.Object,            
                _logger.Object);
        }

        [Theory, AutoData]
        public async Task SignUp_WhenUserExists_ResponseBadRequest (SignupDto signupDto)
        {
            _authServiceMock
                .Setup(a => a.SignupNewAccountAsync(It.IsAny<string>( ), It.IsAny<string>( ), It.IsAny<string>( )))
                .ReturnsAsync(new ServiceResponseDto<string>(null, "User name or email exists", 400));

            var response = await _sut.SignUp(signupDto);
            var responseObject = response as ObjectResult;
            Assert.Equal((int)HttpStatusCode.BadRequest, responseObject!.StatusCode);
        }

        [Theory, AutoData]
        public async Task SignUp_WhenUserNotExists_CreateNewResponseOk (SignupDto signupDto)
        {
            _authServiceMock
                .Setup(a => a.SignupNewAccountAsync(signupDto.UserName, signupDto.Password, signupDto.Email))
                .ReturnsAsync(new ServiceResponseDto<string>(true,"User created"));

            var response = await _sut.SignUp(signupDto);
            var responseObject = response as ObjectResult;

            Assert.Equal((int)HttpStatusCode.OK, responseObject!.StatusCode);
        }
    }
}
