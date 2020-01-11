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
            var value = 5;

            // Act
            var result = GetOperand(value);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Operand));
        }

        [TestMethod]
        public void CreateWithValue_ReturnsOperandWithValue()
        {
            // Arrange
            var value = 5;
            var expectedValue = 5;

            // Act
            var result = GetOperand(value);

            // Assert
            Assert.AreEqual(expectedValue, result.Value);
        }

        [TestMethod]
        public void Create_ReturnsOperandWithFloatingPointValue()
        {
            // Arrange
            var value = 5.73;
            var expectedValue = 5.73;

            // Assert
            var result = GetOperand(value);

            // Assert
            Assert.AreEqual(expectedValue, result.Value, 0.01);
        }

        private static Operand GetOperand(double value)
        {
            var sut = new OperandFactory();

            return sut.Create(value);
        }
    }
}
