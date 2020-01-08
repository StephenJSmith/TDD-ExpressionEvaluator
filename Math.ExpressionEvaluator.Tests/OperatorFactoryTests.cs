using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class OperatorFactoryTests
    {
        private OperatorFactory sut;

        [TestInitialize]
        public void Setup()
        {
            sut = new OperatorFactory();
        }

        [TestMethod]
        public void PlusSign_ReturnsAddOperator()
        {
            AssertType('+', typeof(AddOperator));
        }

        [TestMethod]
        public void MinusSign_ReturnsSubOperator()
        {
            AssertType('-', typeof(SubOperator));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UnknownSign_ThrowsExceptions()
        {
            // Arrange
            var unknownOperator = 'x';

            // Act
            var result = sut.Create(unknownOperator);

            // Assert
            Assert.Fail("Should have thrown an exception");
        }

        [TestMethod]
        public void AsteriskSign_ReturnsMulOperator()
        {
            AssertType('*', typeof(MulOperator));
        }

        [TestMethod]
        public void ForwardSlashSign_ReturnsDivOperator()
        {
            AssertType('/', typeof(DivOperator));
        }

        private void AssertType(char op, Type expected)
        {
            // Act
            var actual = sut.Create(op);

            // Assert
            Assert.IsInstanceOfType(actual, expected);
        }
    }
}
