namespace Math.ExpressionEvaluator
{
    public class OperandFactory : IOperandFactory
    {
        public Operand Create(int value)
        {
            return new Operand(value);
        }
    }
}
