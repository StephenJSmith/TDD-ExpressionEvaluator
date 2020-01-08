namespace Math.ExpressionEvaluator
{
    public class OperandFactory
    {
        public Operand Create(int value)
        {
            return new Operand(value);
        }
    }
}
