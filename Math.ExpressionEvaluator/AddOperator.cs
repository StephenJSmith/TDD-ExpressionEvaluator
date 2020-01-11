namespace Math.ExpressionEvaluator
{
    public class AddOperator : Operator
    {
        public AddOperator(int precedenceBoost = 0)
        {
            Precedence = 1 + precedenceBoost;
        }
        
        public override double Compute(Operand left, Operand right)
        {
            return left.Value + right.Value;
        }
    }
}
