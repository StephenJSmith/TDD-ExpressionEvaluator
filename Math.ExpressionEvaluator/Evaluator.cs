using System;
using System.Collections.Generic;
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

            var elements = Parse(expression).ToList();
            if (elements.Count == 3)
            {
                if (elements[1].Value == "+")
                {
                    return int.Parse(elements[0].Value) + int.Parse(elements[2].Value);
                }

                if (elements[1].Value == "-")
                {
                    return int.Parse(elements[0].Value) - int.Parse(elements[2].Value);
                }
            }

            return int.Parse(expression);
        }

        public IEnumerable<Element> Parse(string expression)
        {
            var operand = "";
            foreach (var currentChar in expression)
            {
                if (char.IsDigit(currentChar))
                {
                    operand += currentChar;
                }
                else
                {
                    yield return new Operand(operand);

                    operand = "";
                    yield return new Operator(currentChar);
                }
            }

            if (operand != "")
            {
                yield return new Operand(operand);
            }
        }
    }
}
