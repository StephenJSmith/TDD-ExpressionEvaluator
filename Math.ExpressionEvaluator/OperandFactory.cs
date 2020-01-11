namespace Math.ExpressionEvaluator
{
    public class OperandFactory : IOperandFactory
    {
        public Operand Create(double value)
        {
            return new Operand(value);
        }
    }
}
