namespace Math.ExpressionEvaluator
{
    public interface IOperandFactory
    {
        Operand Create(double value);
    }
}