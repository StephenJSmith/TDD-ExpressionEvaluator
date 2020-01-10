namespace Math.ExpressionEvaluator
{
    public class SubOperator : Operator
    {

        public SubOperator()
        {
            Precedence = 1;
        }

        public override int Compute(Operand left, Operand right)
        {
            return left.Value - right.Value;
        }
    }
}
