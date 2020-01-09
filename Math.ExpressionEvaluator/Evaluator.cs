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
                var tupleIndex = FindOperation(elements);
                var newElement = Compute(
                    elements[tupleIndex],
                    elements[tupleIndex + 1],
                    elements[tupleIndex + 2]);
                ReplaceOperation(elements, tupleIndex, newElement);
            }

            return (elements[0] as Operand).Value;
        }

        private static int FindOperation(List<Element> elements)
        {
            for (var i = 0; i < elements.Count; i++)
            {
                if (elements[i] is Operator)
                {
                    return i - 1;
                }
            }

            return 0;
        }

        private static Operand Compute(Element lOperand, Element op, Element rOperand)
        {
            return new Operand((op as Operator).Compute(
                lOperand as Operand, 
                rOperand as Operand));
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
