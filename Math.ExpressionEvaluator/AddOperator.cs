namespace Math.ExpressionEvaluator
{
    public class AddOperator : Operator
    {
        public AddOperator()
        {}
        
        public override int Compute(Operand left, Operand right)
        {
            return left.Value + right.Value;
        }
    }
}
