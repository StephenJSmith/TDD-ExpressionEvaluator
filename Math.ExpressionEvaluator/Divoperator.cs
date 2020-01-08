namespace Math.ExpressionEvaluator
{
    public class DivOperator : Operator
    {
        public override int Compute(Operand left, Operand right)
        {
            return left.Value / right.Value;
        }
    }
}
