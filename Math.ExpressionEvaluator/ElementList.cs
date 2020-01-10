using System.Collections.Generic;
using System.Linq;

namespace Math.ExpressionEvaluator
{
    public class ElementList
    {
        private IList<Element> elements;

        public ElementList(IEnumerable<Element> elements)
        {
            this.elements = new List<Element>(elements);
        }

        public Operand First
        {
            get { return elements[0] as Operand; }
        }

        public Operation FindOperation()
        {
            var operators = elements
                .Where(el => el is Operator)
                .Cast<Operator>();
            if (!operators.Any()) { return null; }

            var maxPrecedence = operators.Max(op => op.Precedence);
            var firstOp = operators.First(op => op.Precedence == maxPrecedence);
            var index = elements.IndexOf(firstOp);
            var operation = new Operation(
                elements[index - 1] as Operand,
                elements[index] as Operator,
                elements[index + 1] as Operand);

            return operation;
        }

        public void ReplaceOperation(Operation operation, Operand operand)
        {
            var index = elements.IndexOf(operation.LOperand);
            elements.RemoveAt(index + 2);
            elements.RemoveAt(index + 1);
            elements[index] = operand;
        }
    }
}
