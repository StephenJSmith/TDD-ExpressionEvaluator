using System;
using System.Collections.Generic;

namespace Math.ExpressionEvaluator
{
    public class Parser
    {
        private const char DecimalPoint = '.';

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
                if (char.IsDigit(currentChar) || currentChar == DecimalPoint)
                {
                    operand += currentChar;
                }
                else
                {
                    if (operand!="")
                    {
                        yield return operandFactory.Create(double.Parse(operand));
                    }

                    operand = "";

                    switch (currentChar)
                    {
                        case '(':
                            precedenceBoost += BOOST;
                            break;

                        case ')':
                            precedenceBoost -= BOOST;
                            break;

                        default:
                            yield return operatorFactory.Create(currentChar, precedenceBoost);
                            break;
                    }
                }
            }

            if (operand != "")
            {
                yield return operandFactory.Create(double.Parse(operand));
            }

            if (precedenceBoost > 0)
            {
                throw new Exception("Too many open parentheses");
            }

            if (precedenceBoost < 0)
            {
                throw new Exception("Too many closed parentheses");
            }
        }
    }
}
