﻿using System;
using System.Linq;

namespace Math.ExpressionEvaluator
{
    public class Evaluator
    {
        private readonly Parser parser;

        public Evaluator(Parser parser)
        {
            this.parser = parser;
        }

        public int Eval(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new Exception();
            }

            var elements = parser.Parse(expression).ToList();
            if (elements.Count == 3)
            {
                var op = elements[1] as Operator;
                var left = elements[0] as Operand;
                var right = elements[2] as Operand;

                return op.Compute(left, right);
            }

            return int.Parse(expression);
        }
    }
}
