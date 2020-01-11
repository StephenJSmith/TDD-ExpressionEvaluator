namespace Math.ExpressionEvaluator
{
    public abstract class Operator : Element
    {
        public int Precedence { get; protected set; }
        public abstract double Compute(Operand left, Operand right);
    }
}