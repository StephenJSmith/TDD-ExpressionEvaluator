using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class DivOperatorTests
    {
        [TestMethod]
        public void DivOperator_ReturnsQuotient()
        {
            // Arrange
            var sut =  new DivOperator();
            var operandLeft = new Operand("20");
            var operandRight = new Operand("10");
            var expected = 2;

            // Act
            var actual = sut.Compute(operandLeft, operandRight);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
