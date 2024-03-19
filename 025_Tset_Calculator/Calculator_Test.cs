using _024_Calculator;
using Moq;

namespace _025_Tset_Calculator
{
    public class Calculator_Test
    {
        [Fact]
        public void Add_Should_LogMessage_WhenCalled()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var calculator = new Calculator(loggerMock.Object);

            // Act
            calculator.Add(3, 5);

            // Assert
            loggerMock.Verify(l => l.Log(It.IsAny<string>()), Times.Once);
        }
    }
}