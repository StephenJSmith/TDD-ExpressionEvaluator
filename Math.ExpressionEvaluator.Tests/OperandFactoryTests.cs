using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class OperandFactoryTests
    {
        [TestMethod]
        public void Create_ReturnsOperand()
        {
            // Arrange
            var sut = new OperandFactory();
            var value = 5;

            // Act
            var result = sut.Create(value);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Operand));
        }

        [TestMethod]
        public void CreateWithValue_ReturnsOperandWithValue()
        {
            // Arrange
            var sut = new OperandFactory();
            var value = 5;
            var expectedValue = 5;

            // Act
            var result = sut.Create(value);

            // Assert
            Assert.AreEqual(expectedValue, result.Value);
        }
    }
}
