using System;
using WebApplication.Controllers;
using Xunit;

namespace WebApplication.Tests
{
    public class ValuesControllerTests
    {
        [Fact]
        public void Get_Success()
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = controller.Get()?.Value;

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Get_WithValidId_Success()
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = controller.Get(1)?.Value;

            // Assert
            Assert.NotNull(result);
        }
    }
}
