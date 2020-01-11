namespace Math.ExpressionEvaluator
{
    public class Operand : Element
    {
        public double Value { get; private set; }

        public Operand(double value)
        {
            Value = value;
        }
    }
}