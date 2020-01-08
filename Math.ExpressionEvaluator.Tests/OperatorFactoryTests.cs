using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class OperatorFactoryTests
    {
        [TestMethod]
        public void PlusSign_ReturnsAddOperator()
        {
            // Arrange
            var operatorChar = '+';
            var sut = new OperatorFactory();

            // Act
            var result = sut.Create(operatorChar);

            // Assert
            Assert.IsInstanceOfType(result, typeof(AddOperator));
        }

        [TestMethod]
        public void MinusSign_ReturnsSubOperator()
        {
            // Arrange
            var operatorChar = '-';
            var sut = new OperatorFactory();

            // Act
            var result = sut.Create(operatorChar);

            // Assert
            Assert.IsInstanceOfType(result, typeof(SubOperator));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UnknownSign_ThrowsExceptions()
        {
            // Arrange
            var unknownOperator = 'x';
            var sut = new OperatorFactory();

            // Act
            var result = sut.Create(unknownOperator);

            // Assert
            Assert.Fail("Should have thrown an exception");
        }

        [TestMethod]
        public void AsteriskSign_ReturnsMulOperator()
        {
            // Arrange
            var operatorChar = '*';
            var sut = new OperatorFactory();

            // Act
            var result = sut.Create(operatorChar);

            // Assert
            Assert.IsInstanceOfType(result, typeof(MulOperator));
        }
    }
}
