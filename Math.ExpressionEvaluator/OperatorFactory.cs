using System;

namespace Math.ExpressionEvaluator
{
    public class OperatorFactory
    {
        public Operator Create(char operatorChar)
        {
            switch (operatorChar)
            {
                case '+':
                    return (Operator) new AddOperator();

                case '-':
                    return (Operator)new SubOperator();

                default:
                    throw new Exception();
            }
        }
    }
}
