using System;

namespace Math.ExpressionEvaluator
{
    public class Operator : Element
    {
        public Operator(char operatorChar)
        {
            Value = operatorChar.ToString();
        }

        public int Compute(int left, int right)
        {
            switch (Value)
            {
                case "+":
                    return left + right;

                case "-":
                    return left - right;

                default:
                    throw new Exception();
            }
        }
    }
}