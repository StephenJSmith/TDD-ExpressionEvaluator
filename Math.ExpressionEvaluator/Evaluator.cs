using System;
using System.Linq;

namespace Math.ExpressionEvaluator
{
    public class Evaluator
    {
        public int Eval(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new Exception();
            }

            var parser = new Parser();

            var elements = parser.Parse(expression).ToList();
            if (elements.Count == 3)
            {
                var op = elements[1] as Operator;
                var left = int.Parse(elements[0].Value);
                var right = int.Parse(elements[2].Value);

                return op.Compute(left, right);
            }

            return int.Parse(expression);
        }
    }
}
