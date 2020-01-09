using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class ElementListTests
    {
        [TestMethod]
        public void FindOperation_ReturnsFirstOperation()
        {
            // Arrange
            var lOperand = new Operand(0);
            var op = new AddOperator();
            var rOperand = new Operand(0);
            var elements = new Element[]
            {
                new Operand(0),
                new Operand(0),
                lOperand,
                op,
                rOperand
            };
            var sut = new ElementList(elements);

            // Act
            var result = sut.FindOperation();

            // Assert
            Assert.AreEqual(lOperand, result.LOperand);
            Assert.AreEqual(op, result.Op);
            Assert.AreEqual(rOperand, result.ROperand);
        }

        [TestMethod]
        public void ReplaceOperation_ReplacesCorrectOperation()
        {
            // Arrange
            var otherOpd1 = new Operand(0);
            var otherOp = new AddOperator();
            var otherOpd2 = new Operand(0);
            var lOperand = new Operand(0);
            var op = new AddOperator();
            var rOperand = new Operand(0);
            var elements = new Element[]
            {
                otherOpd1, otherOp, otherOpd2,
                lOperand, op, rOperand
            };
            var sut = new ElementList(elements);
            var operation = new Operation(lOperand, op, rOperand);
            
            // Act
            sut.ReplaceOperation(operation, new Operand(0));
            var result = sut.FindOperation();

            // Assert
            Assert.AreEqual(otherOpd1, result.LOperand);
            Assert.AreEqual(otherOp, result.Op);
            Assert.AreEqual(otherOpd2, result.ROperand);
        }

        [TestMethod]
        public void ReplaceOperationWorks()
        {
            // Arrange
            var lOperand = new Operand(0);
            var op = new AddOperator();
            var rOperand = new Operand(0);
            var elements = new Element[]
            {
                lOperand, op, rOperand
            };
            var sut = new ElementList(elements);
            var operation = new Operation(lOperand, op, rOperand);

            // Act
            sut.ReplaceOperation(operation, new Operand(0));
            var result = sut.FindOperation();

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void First_ReturnsFirstElement()
        {
            // Arrange
            var lOperand = new Operand(0);
            var op = new AddOperator();
            var rOperand = new Operand(0);
            var elements = new Element[]
            {
                lOperand, op, rOperand
            };
            var sut = new ElementList(elements);

            // Act
            var result = sut.First;

            // Assert
            Assert.AreEqual(lOperand, result);
        }
    }
}
