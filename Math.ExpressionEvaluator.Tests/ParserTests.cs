using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void Parse_ReturnsAdditionElements()
        {
            // Arrange
            var sut = new Parser(
                new OperatorFactory(),
                new OperandFactory());
            var expected = 3;
            var expression = "1+2";

            // Act
            var result = sut.Parse(expression).ToList();

            // Assert
            Assert.AreEqual(expected, result.Count);
            Assert.IsInstanceOfType(result[0], typeof(Operand));
            Assert.IsInstanceOfType(result[1], typeof(Operator));
            Assert.IsInstanceOfType(result[2], typeof(Operand));
        }
    }
}
