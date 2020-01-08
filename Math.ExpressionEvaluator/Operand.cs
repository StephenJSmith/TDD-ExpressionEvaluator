namespace Math.ExpressionEvaluator
{
    public class Operand : Element
    {
        public int Value { get; private set; }

        public Operand(string operand)
        {
            Value = int.Parse(operand);
        }
    }
}