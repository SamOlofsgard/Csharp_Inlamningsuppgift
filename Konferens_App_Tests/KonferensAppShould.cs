
using Xunit;


namespace Konferens_App_Tests
{
    public class KonferensAppShould
    {
        [Fact]
        public void Get_Contacts()
        {
            //Arrange
            
            //Action

            //Assert
        }

        [Fact]
        public void Create_Todo()
        {
            // Arrange
            TodoHandler 

            //TodoHandler sut = new TodoHandler();

            // Action
            TodoItem todo = sut.CreateTodo("Todo Title");

            // Assert
            Assert.NotNull(todo);
        }
    }
}