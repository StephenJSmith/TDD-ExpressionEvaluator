namespace Math.ExpressionEvaluator
{
    public abstract class Operator : Element
    {
        public abstract int Compute(Operand left, Operand right);
    }
}