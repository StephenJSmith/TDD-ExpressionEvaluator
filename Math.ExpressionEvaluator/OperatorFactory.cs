using System;

namespace Math.ExpressionEvaluator
{
    public class OperatorFactory
    {
        public Operator Create(char operatorChar, int precedenceBoost)
        {
            switch (operatorChar)
            {
                case '+':
                    return (Operator) new AddOperator(precedenceBoost);

                case '-':
                    return (Operator) new SubOperator(precedenceBoost);

                case '*':
                    return (Operator) new MulOperator(precedenceBoost);

                case '/':
                    return (Operator) new DivOperator(precedenceBoost);

                default:
                    var msg = $"Unkown operator [{operatorChar}]";
                    throw new Exception(msg);
            }
        }
    }
}
