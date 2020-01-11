using System.Collections.Generic;
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
            var expected = 3;
            var expression = "1+2";

            // Act
            var result = Parse(expression);

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
                .Setup(it => it.Create(It.IsAny<double>()))
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
            var expression = "1+2*3-4";
            var expectedCount = 7;

            // Act
            var result = Parse(expression);

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

        [TestMethod]
        public void NegativeNumber()
        {
            // Arrange
            var expression = "-3";

            // Act
            var result = Parse(expression);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsInstanceOfType(result[0], typeof(SubOperator));
            Assert.AreEqual(3, ((Operand)result[1]).Value);
        }

        [TestMethod]
        public void NumberInParentheses()
        {
            // Arrange
            var expression = "(3)";
            var expectedValue = 3;

            // Act
            var result = Parse(expression);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(expectedValue, ((Operand)result[0]).Value);
        }

        [TestMethod]
        public void OperatorsInParentheses_APrecedenceBoost()
        {
            // Arrange
            var expression = "(1+2)";
            var expectedPrecedence = 11;

            // Act
            var result = Parse(expression);

            // Assert
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, ((Operand)result[0]).Value);
            Assert.AreEqual(expectedPrecedence, ((Operator)result[1]).Precedence);
            Assert.AreEqual(2, ((Operand)result[2]).Value);
        }

        [TestMethod]
        public void FloatingPointNumber()
        {
            // Arrange
            var expression = "1.5";

            // Act
            var result = Parse(expression);

            // Assert
            Assert.AreEqual(1.5, ((Operand)result[0]).Value);
        }
        private static List<Element> Parse(string expression)
        {
            var sut = new Parser(new OperatorFactory(), new OperandFactory());

            return sut.Parse(expression).ToList();
        }
    }
}
