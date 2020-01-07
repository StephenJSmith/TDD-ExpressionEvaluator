using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class OperatorTests
    {
        [TestMethod]
        public void Constructor_setsValueProperty()
        {
            // Arrange
            var expected = "+";
            var expression = '+';

            // Act
            var sut = new Operator(expression);
            var actual = sut.Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
