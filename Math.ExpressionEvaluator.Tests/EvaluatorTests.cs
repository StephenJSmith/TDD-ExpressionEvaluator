﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class EvaluatorTests
    {
        private static void AssertAreEqual(string expression, int expected)
        {
            // Arrange
            var parser = new Parser(
                new OperatorFactory(),
                new OperandFactory());
            var sut = new Evaluator(parser);

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
            var parser = new Parser(
                new OperatorFactory(),
                new OperandFactory());
            var sut = new Evaluator(parser);

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

        [TestMethod]
        public void AddingTwoNumbers_ReturnsSum()
        {
            AssertAreEqual("1+2", 3);
        }

        [TestMethod]
        public void SubtractTwoNumbers_ReturnsDifference()
        {
            AssertAreEqual("88-20", 68);
        }

        [TestMethod]
        public void MultiplyTwoIntegerNumbers_ReturnsProduct()
        {
            AssertAreEqual("12*30", 360);
        }

        [TestMethod]
        public void DivideTwoIntegers_ReturnsQuotient()
        {
            AssertAreEqual("30/5", 6);
        }

        [TestMethod]
        public void TwoOperations()
        {
            AssertAreEqual("2*3-5", 1);
        }

        [TestMethod]
        public void TwoOperationsRespectingPrecedence()
        {
            AssertAreEqual("2+3*5", 17);
        }

        [TestMethod]
        public void MultipleOperationsWithOrderOfPrecedence()
        {
            AssertAreEqual("2+3*5-8/2", 13);
        }

        [TestMethod]
        public void ComplexExpression()
        {
            AssertAreEqual("-2+3*(-5+8-9)/2", -11);
        }

        [TestMethod]
        public void NegativeNumber()
        {
            AssertAreEqual("-3", -3);
        }

        [TestMethod]
        public void NumberInParentheses_ReturnsNumber()
        {
            AssertAreEqual("(3)", 3);
            ;
        }

        [TestMethod]
        public void AddANegativeNumberInParentheses()
        {
            AssertAreEqual("2+(-3)", -1);
        }
    }
}
