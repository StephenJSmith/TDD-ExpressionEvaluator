﻿namespace Math.ExpressionEvaluator
{
    public class Operand : Element
    {
        public int Value { get; private set; }

        public Operand(int value)
        {
            Value = value;
        }
    }
}