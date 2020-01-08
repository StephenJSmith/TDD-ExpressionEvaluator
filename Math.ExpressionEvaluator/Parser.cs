using System.Collections.Generic;

namespace Math.ExpressionEvaluator
{
    public class Parser
    {
        public IEnumerable<Element> Parse(string expression)
        {
            var operatorFactory = new OperatorFactory();
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
                    yield return operatorFactory.Create(currentChar);
                }
            }

            if (operand != "")
            {
                yield return new Operand(operand);
            }
        }
    }
}
