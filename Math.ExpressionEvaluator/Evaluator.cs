using System;

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

            var result = int.Parse(expression);

            return result;
        }
    }
}
