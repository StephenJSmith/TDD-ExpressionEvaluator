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

        public int Eval(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new Exception();
            }

            var elements = parser.Parse(expression).ToList();
            while (elements.Count > 1)
            {
                var tuple = FindOperation(elements);
                var newElement = tuple.Item2.Compute();
                ReplaceOperation(elements, tuple.Item1, newElement);
            }

            return (elements[0] as Operand).Value;
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
