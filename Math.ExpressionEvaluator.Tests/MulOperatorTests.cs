using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class MulOperatorTests
    {
        [TestMethod]
        public void MulOperator_ReturnsProduct()
        {
            // Arrange
            var leftOperand = new Operand(10);
            var rightOperand = new Operand(25);
            var expected = 250;
            var sut = new MulOperator();

            // Act
            var actual = sut.Compute(leftOperand, rightOperand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TakesPrecedenceBoostIntoAccount()
        {
            // Arrange
            var precedenceBoost = 7;
            var expected = 9;
            var sut = new MulOperator(precedenceBoost);

            // Act
            var actual = sut.Precedence;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
