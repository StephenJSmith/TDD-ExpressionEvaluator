using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class OperatorTests
    {
        [TestMethod]
        public void AddOperator_PrecedenceSetCorrectly()
        {
            // Arrange
            var expected = 1;
            var sut = new AddOperator();

            // Act
            var actual = sut.Precedence;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SubOperator_PrecedenceSetCorrectly()
        {
            // Arrange
            var expected = 1;
            var sut = new SubOperator();

            // Act
            var actual = sut.Precedence;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MulOperator_PrecedenceSetCorrectly()
        {
            // Arrange
            var expected = 2;
            var sut = new MulOperator();

            // Act
            var actual = sut.Precedence;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DivOperator_PrecedenceSetCorrectly()
        {
            // Arrange
            var expected = 2;
            var sut = new DivOperator();

            // Act
            var actual = sut.Precedence;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
