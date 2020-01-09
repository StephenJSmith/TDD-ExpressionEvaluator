using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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

        [TestMethod]
        public void Parse_CallsOperandFactoryCreate()
        {
            // Arrange
            var operandFactory = new Mock<IOperandFactory>();
            operandFactory
                .Setup(it => it.Create(It.IsAny<int>()))
                .Verifiable();
            var sut = new Parser(new OperatorFactory(),
                operandFactory.Object);

            // Act
            sut.Parse("1").ToList();

            // Assert
            operandFactory.Verify();
        }

        [TestMethod]
        public void ParseMultipleOperandAndOperators()
        {
            // Arrange
            var sut = new Parser(
                new OperatorFactory(),
                new OperandFactory());
            var expression = "1+2*3-4";
            var expectedCount = 7;

            // Act
            var result = sut.Parse(expression).ToList();

            // Assert
            Assert.AreEqual(expectedCount, result.Count);
            Assert.IsInstanceOfType(result[0], typeof(Operand));
            Assert.IsInstanceOfType(result[1], typeof(Operator));
            Assert.IsInstanceOfType(result[2], typeof(Operand));
            Assert.IsInstanceOfType(result[3], typeof(Operator));
            Assert.IsInstanceOfType(result[4], typeof(Operand));
            Assert.IsInstanceOfType(result[5], typeof(Operator));
            Assert.IsInstanceOfType(result[6], typeof(Operand));
        }
    }
}
