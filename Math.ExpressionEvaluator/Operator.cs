using System;

namespace Math.ExpressionEvaluator
{
    public class Operator : Element
    {
        private readonly char value;

        public Operator(char operatorChar)
        {
            value = operatorChar;
        }

        public int Compute(Operand left, Operand right)
        {
            switch (value)
            {
                case '+':
                    return left.Value + right.Value;

                case '-':
                    return left.Value - right.Value;

                default:
                    throw new Exception();
            }
        }
    }
}