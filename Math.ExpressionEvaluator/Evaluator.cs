using System;
using System.Collections.Generic;
using System.Linq;

namespace Math.ExpressionEvaluator
{
    public class Evaluator
    {
        private readonly Parser parser;

        public Evaluator(Parser parser)
        {
            this.parser = parser;
        }

        public double Eval(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new Exception();
            }

            var elementsArg = parser.Parse(expression);
            var elements = new ElementList(elementsArg);
            var operation = elements.FindOperation();
            while (operation != null)
            {
                var newElement = operation.Compute();
                elements.ReplaceOperation(operation, newElement);
                operation = elements.FindOperation();
            }

            return elements.First.Value;
        }

        private static Tuple<int, Operation> FindOperation(List<Element> elements)
        {
            for (var i = 0; i < elements.Count; i++)
            {
                if (elements[i] is Operator)
                {
                    var operation = new Operation(
                        elements[i - 1] as Operand,
                        elements[i] as Operator,
                        elements[i + 1] as Operand);

                    return new Tuple<int, Operation>(i - 1, operation);
                }
            }

            return null;
        }

        private static void ReplaceOperation(IList<Element> elements,
            int index, Operand operand)
        {
            elements.RemoveAt(index + 2);
            elements.RemoveAt(index + 1);
            elements.RemoveAt(index);
            elements.Insert(index, operand);
        }
    }
}
