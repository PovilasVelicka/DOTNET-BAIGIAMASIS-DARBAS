using NoteBook.Entity.Models;

namespace EntityTests
{
    
    public class FirstNameTest
    {
        [Theory]
        [InlineData("povilas velicka")]
        [InlineData("pOviLas vEliCKA")]
        [InlineData("Povilas Velicka")]
        [InlineData("POVILAS VELICKA")]
        public void NameChangeTest_FirstLetterUpperCase (string name)
        {  
            var actual = new FirstName(name).Value;
            var expected = "Povilas Velicka";
            Assert.Equal( expected, actual );
        }
    }
}
