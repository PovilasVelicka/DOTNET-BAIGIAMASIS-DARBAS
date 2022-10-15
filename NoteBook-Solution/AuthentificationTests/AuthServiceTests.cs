using AutoFixture;
using AutoFixture.Xunit2;
using Microsoft.Extensions.Logging;
using Moq;
using NoteBook.BusinessLogic.Services.AuthServices;
using NoteBook.Common.Interfaces.DataAccess;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Controllers.AuthController.DTOs;
using NoteBook.Entity.Models;
using System.Net;

namespace AuthentificationTests
{
    public class AuthServiceTests
    {
        private readonly IFixture _fixture;
        private readonly IAuthService _sut;
        private readonly Mock<IAccountsRepository> _accountRepositoryMock;
        private readonly Mock<ILogger<AuthService>> _loggerMock;
        private readonly Mock<IJwtService> _jwtServiceMock;
        public AuthServiceTests ( )
        {
            _fixture = new Fixture( );
            _accountRepositoryMock = new Mock<IAccountsRepository>( );
            _jwtServiceMock = new Mock<IJwtService>( );
            _loggerMock = new Mock<ILogger<AuthService>>( );
            _sut = new AuthService(_accountRepositoryMock.Object,_jwtServiceMock.Object, _loggerMock.Object);
        }

        [Theory, AutoData]
        public async void LoginAsync_WhenUserNotExists_ReturnNotFoundStatus (LoginDto account)
        {
            _accountRepositoryMock
                .Setup(a => a.GetByNameAsync(account.UserName))
                .ReturnsAsync(default(Account));

            var response = await _sut.LoginAsync(account.UserName, account.Password);
            Assert.False(response.IsSuccess);
            Assert.Equal((int)HttpStatusCode.NotFound, response.StatuCode);
        }

        [Theory, AutoData]
        public async void SignUpAndLogin_WhenNewUserCreatedAndLoggedIn_ResponseOk (SignupDto signUpDto)
        {
            Account? account = default(Account);
            _accountRepositoryMock
                .Setup(r => r.AddAsync(It.IsAny<Account>( )))
                .Callback<Account>(a => account = a);

            _accountRepositoryMock
                .Setup(r => r.GetByEmailAsync(signUpDto.Email))
                .ReturnsAsync(default(Account));

            _jwtServiceMock
                .Setup(t => t.GetJwtToken(It.IsAny<Account>( )))
                .Returns("JWTTOKENEXAMPLE");

            var signUpResponse = await _sut.SignupNewAccountAsync(signUpDto.UserName, signUpDto.Password, signUpDto.Email);
            Assert.True(signUpResponse.IsSuccess);
    

            _accountRepositoryMock
              .Setup(r => r.GetByNameAsync(signUpDto.UserName))
              .ReturnsAsync(account);

            var loginResponse = await _sut.LoginAsync(signUpDto.UserName, signUpDto.Password);
            Assert.True(loginResponse.IsSuccess);
            _accountRepositoryMock.Verify(a=> a.AddAsync(It.IsAny<Account>()), Times.Once());
            _accountRepositoryMock.Verify(a => a.GetByNameAsync(signUpDto.UserName), Times.Between(2, 2, Moq.Range.Inclusive));
            _accountRepositoryMock.Verify(a => a.GetByEmailAsync( signUpDto.Email),Times.Once());
            _jwtServiceMock.Verify(a => a.GetJwtToken(It.IsAny<Account>( )), Times.Between(2, 2, Moq.Range.Inclusive));
        }

        [Theory, AutoData]
        public async void SignUpAndLogin_WhenNewUserCreatedAndPasswordIncorrect_ResponseUnAuthorized (SignupDto signUpDto)
        {
            Account? account = default(Account);
            _accountRepositoryMock
                .Setup(r => r.AddAsync(It.IsAny<Account>( )))
                .Callback<Account>(a => account = a);

            _accountRepositoryMock
                 .Setup(r => r.GetByEmailAsync(signUpDto.Email))
                 .ReturnsAsync(default(Account));

            _jwtServiceMock
                .Setup(t => t.GetJwtToken(It.IsAny<Account>( )))
                .Returns("JWTTOKENEXAMPLE");

            var signUpResponse = await _sut.SignupNewAccountAsync(signUpDto.UserName, signUpDto.Password, signUpDto.Email);
            Assert.True(signUpResponse.IsSuccess);

            _accountRepositoryMock
              .Setup(r => r.GetByNameAsync(signUpDto.UserName))
              .ReturnsAsync(account);

            var loginResponse = await _sut.LoginAsync(signUpDto.UserName, "incorrect-password");
            Assert.False(loginResponse.IsSuccess);
            Assert.Equal((int)HttpStatusCode.Unauthorized, loginResponse.StatuCode);
            _accountRepositoryMock.Verify(a => a.AddAsync(It.IsAny<Account>( )), Times.Once( ));
            _accountRepositoryMock.Verify(a => a.GetByNameAsync(signUpDto.UserName), Times.Between(2,2,Moq.Range.Inclusive));
            _accountRepositoryMock.Verify(a => a.GetByEmailAsync( signUpDto.Email), Times.Once( ));
            _jwtServiceMock.Verify(a => a.GetJwtToken(It.IsAny<Account>( )), Times.Once( ));
        }
    }
}