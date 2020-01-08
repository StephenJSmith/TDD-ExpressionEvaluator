namespace Math.ExpressionEvaluator
{
    public interface IOperandFactory
    {
        Operand Create(int value);
    }
}