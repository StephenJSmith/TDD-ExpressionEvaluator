namespace Math.ExpressionEvaluator
{
    public class SubOperator : Operator
    {
        public override int Compute(Operand left, Operand right)
        {
            return left.Value - right.Value;
        }
    }
}
