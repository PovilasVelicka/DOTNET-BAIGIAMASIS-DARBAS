using NoteBook.Entity.Models;

namespace EntityTests
{
    public class EmailTest
    {
        [Theory]
        [InlineData("simple@example.com")]
        [InlineData("very.common@example.com")]
        [InlineData("disposable.style.email.with+symbol@example.com")]
        [InlineData("other.email-with-hyphen@example.com")]
        [InlineData("fully-qualified-domain@example.com")]
        [InlineData("user.name+tag+sorting@example.com")]
        [InlineData("x@example.com")]
        [InlineData("example-indeed@strange-example.com")]
        [InlineData("test/test@test.com")]       
        [InlineData("example@s.example")]
        [InlineData("mailhost!username@example.org")]
        [InlineData("user%example.com@example.org")]
        [InlineData("user-@example.org")]
        [InlineData("postmaster@[123.123.123.123]")]
        public void WhenEmailValid (string expected)
        {
            var actual = new Email(expected).Value;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Abc.example.com")]
        [InlineData("A@b@c@example.com")]       
        [InlineData(@"this isnot\allowed@example.com")]
        [InlineData(@"this still not\\allowed@example.com")]
        [InlineData("QA[icon]CHOCOLATE[icon]@test.com")]
        public void WhenEmailNotValid (string expected)
        {
            var actual = new Email(expected).Value;

            Assert.NotEqual(expected, actual);
        }
    }
}