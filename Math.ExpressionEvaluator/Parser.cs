using System.Collections.Generic;

namespace Math.ExpressionEvaluator
{
    public class Parser
    {
        private readonly OperatorFactory operatorFactory;
        private readonly IOperandFactory operandFactory;

        public Parser(
            OperatorFactory operatorFactory,
            IOperandFactory operandFactory)
        {
            this.operatorFactory = operatorFactory;
            this.operandFactory = operandFactory;
        }

        public IEnumerable<Element> Parse(string expression)
        {
            const int BOOST = 10;
            var precedenceBoost = 0;
            var operand = "";

            foreach (var currentChar in expression)
            {
                if (char.IsDigit(currentChar))
                {
                    operand += currentChar;
                }
                else
                {
                    if (operand!="")
                    {
                        yield return operandFactory.Create(int.Parse(operand));
                    }

                    operand = "";
                    if (currentChar == '(')
                    {
                        precedenceBoost += BOOST;
                    } else if (currentChar == ')')
                    {
                        precedenceBoost -= BOOST;
                    }
                    else
                    {
                        yield return operatorFactory.Create(currentChar, precedenceBoost);
                    }
                }
            }

            if (operand != "")
            {
                yield return operandFactory.Create(int.Parse(operand));
            }
        }
    }
}
