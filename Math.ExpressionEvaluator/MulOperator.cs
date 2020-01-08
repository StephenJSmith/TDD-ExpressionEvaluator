namespace Math.ExpressionEvaluator
{
    public class MulOperator : Operator
    {
        public override int Compute(Operand left, Operand right)
        {
            return left.Value * right.Value;
        }
    }
}
