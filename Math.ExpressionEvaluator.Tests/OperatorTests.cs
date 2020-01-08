using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class OperatorTests
    {
        [TestMethod]
        public void AdditionOperator_ReturnsSum()
        {
            // Arrange
            var operatorChar = '+';
            var operand1 = new Operand("10");
            var operand2 = new Operand("20");
            var expected = 30;

            // Act
            var sut = new Operator(operatorChar);
            var actual = sut.Compute(operand1, operand2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionOperator_ReturnsDifference()
        {
            // Arrange
            var operatorChar = '-';
            var operand1 = new Operand("20");
            var operand2 = new Operand("7");
            var expected = 13;

            // Act
            var sut = new Operator(operatorChar);
            var actual = sut.Compute(operand1, operand2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UnknownOperator_ThrowsException()
        {
            // Arrange
            var operatorChar = 'x';
            var operand1 = new Operand("0");
            var operand2 = new Operand("0");

            // Act
            var sut = new Operator(operatorChar);
            sut.Compute(operand1, operand2);

            // Assert
            Assert.Fail("Should have thrown an exception");
        }
    }
}
