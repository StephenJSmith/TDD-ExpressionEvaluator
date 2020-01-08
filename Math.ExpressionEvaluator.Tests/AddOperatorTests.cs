using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class AddOperatorTests
    {
        [TestMethod]
        public void AdditionOperator_ReturnsSum()
        {
            // Arrange
            var operand1 = new Operand("10");
            var operand2 = new Operand("20");
            var expected = 30;

            // Act
            var sut = new AddOperator();
            var actual = sut.Compute(operand1, operand2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
