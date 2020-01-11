using System;
using System.Collections.Generic;
using System.Linq;

namespace Math.ExpressionEvaluator
{
    public class Parser
    {
        private const char DecimalPoint = '.';

        private readonly OperatorFactory operatorFactory;
        private readonly IOperandFactory operandFactory;
        private readonly IDictionary<string, double> symbols;

        public Parser(
            OperatorFactory operatorFactory,
            IOperandFactory operandFactory,
            IDictionary<string, double> symbols = null)
        {
            this.operatorFactory = operatorFactory;
            this.operandFactory = operandFactory;
            this.symbols = symbols;
        }

        public IEnumerable<Element> Parse(string expression)
        {
            const int BOOST = 10;
            var precedenceBoost = 0;
            var operand = "";

            foreach (var currentChar in expression.Where(c => !char.IsWhiteSpace(c)))
            {
                if (char.IsLetterOrDigit(currentChar) || currentChar == DecimalPoint)
                {
                    operand += currentChar;
                }
                else
                {
                    if (operand!="")
                    {
                        yield return operandFactory.Create(GetOperand(operand));
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
                yield return operandFactory.Create(GetOperand(operand));
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

        private double GetOperand(string operand)
        {
            return char.IsLetter(operand.First())
                ? symbols[operand]
                : double.Parse(operand);
        }
    }
}
