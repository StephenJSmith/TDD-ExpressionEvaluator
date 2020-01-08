using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class OperandTests
    {
        [TestMethod]
        public void Constructor_SetsValueProperty()
        {
            // Arrange
            var expected = 123;
            var expression = 123;
            
            // Act
            var sut = new Operand(expression);
            var actual = sut.Value;

            // Act
            Assert.AreEqual(expected, actual);
        }
    }
}
