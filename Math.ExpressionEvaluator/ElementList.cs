using System.Collections.Generic;

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

            for (var i = 0; i < elements.Count; i++)
            {
                if (elements[i] is Operator)
                {
                    var operation = new Operation(
                        elements[i - 1] as Operand,
                        elements[i] as Operator,
                        elements[i + 1] as Operand);

                    return operation;
                }
            }

            return null;
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
