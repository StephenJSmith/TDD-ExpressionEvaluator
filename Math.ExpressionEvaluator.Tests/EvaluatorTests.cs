using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class EvaluatorTests
    {
        private static void AssertAreEqual(string expression, int expected)
        {
            // Arrange
            var sut = new Evaluator();

            // Act
            var actual = sut.Eval(expression);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NullOrEmptyString_ThrowsException()
        {
            // Arrange
            var sut = new Evaluator();

            // Act
            sut.Eval("");

            // Assert
            Assert.Fail("Should have thrown an exception");
        }

        [TestMethod]
        public void OneDigitNumber_Attempt1_ReturnsIntegerValue()
        {
            AssertAreEqual("7", 7);
        }

        [TestMethod]
        public void OneDigitNumber_Attempt2_ReturnsIntegerValue()
        {
            AssertAreEqual("5", 5);
        }

        [TestMethod]
        public void MultipleDigitsNumber_ReturnsIntegerValue()
        {
            AssertAreEqual("324", 324);
        }
    }
}
