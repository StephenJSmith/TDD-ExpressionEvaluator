using System;
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

        [TestMethod]
        public void AdditionOperator_ReturnsSum()
        {
            // Arrange
            var operatorChar = '+';
            var addend1 = 10;
            var addend2 = 20;
            var expected = 30;

            // Act
            var sut = new Operator(operatorChar);
            var actual = sut.Compute(addend1, addend2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionOperator_ReturnsDifference()
        {
            // Arrange
            var operatorChar = '-';
            var minuend = 20;
            var subtrahend = 7;
            var expected = 13;

            // Act
            var sut = new Operator(operatorChar);
            var actual = sut.Compute(minuend, subtrahend);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UnknownOperator_ThrowsException()
        {
            // Arrange
            var operatorChar = 'x';
            var left = 0;
            var right = 0;

            // Act
            var sut = new Operator(operatorChar);
            sut.Compute(left, right);

            // Assert
            Assert.Fail("Should have thrown an exception");
        }
    }
}
