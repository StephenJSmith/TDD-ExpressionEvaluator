using System.Collections.Generic;

namespace Math.ExpressionEvaluator
{
    public class Parser
    {
        private readonly OperatorFactory operatorFactory;
        private readonly OperandFactory operandFactory;

        public Parser(
            OperatorFactory operatorFactory,
            OperandFactory operandFactory)
        {
            this.operatorFactory = operatorFactory;
            this.operandFactory = operandFactory;
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
                    yield return new Operand(int.Parse(operand));

                    operand = "";
                    yield return operatorFactory.Create(currentChar);
                }
            }

            if (operand != "")
            {
                yield return new Operand(int.Parse(operand));
            }
        }
    }
}
