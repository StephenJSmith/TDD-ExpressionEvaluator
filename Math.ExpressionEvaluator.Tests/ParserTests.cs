﻿using System.Linq;
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

        [TestMethod]
        public void NegativeNumber()
        {
            // Arrange
            var expression = "-3";
            var sut = CreateParser();

            // Act
            var result = sut.Parse(expression).ToList();

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
            var sut = CreateParser();

            // Act
            var result = sut.Parse(expression).ToList();

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
            var sut = CreateParser();

            // Act
            var result = sut.Parse(expression).ToList();

            // Assert
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, ((Operand)result[0]).Value);
            Assert.AreEqual(expectedPrecedence, ((Operator)result[1]).Precedence);
            Assert.AreEqual(2, ((Operand)result[2]).Value);
        }

        private static Parser CreateParser()
        {
            return new Parser(new OperatorFactory(), new OperandFactory());
        }
    }
}
