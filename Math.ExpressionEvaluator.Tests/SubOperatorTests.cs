using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class SubOperatorTests
    {
        [TestMethod]
        public void SubtractionOperator_ReturnsDifference()
        {
            // Arrange
            var operand1 = new Operand("20");
            var operand2 = new Operand("7");
            var expected = 13;

            // Act
            var sut = new SubOperator();
            var actual = sut.Compute(operand1, operand2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
