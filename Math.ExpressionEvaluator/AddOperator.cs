namespace Math.ExpressionEvaluator
{
    public class AddOperator : Operator
    {
        public AddOperator()
        {
            Precedence = 1;
        }
        
        public override int Compute(Operand left, Operand right)
        {
            return left.Value + right.Value;
        }
    }
}
