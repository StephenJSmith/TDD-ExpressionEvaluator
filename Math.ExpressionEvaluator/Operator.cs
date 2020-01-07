namespace Math.ExpressionEvaluator
{
    public class Operator : Element
    {
        public Operator(char operatorChar)
        {
            Value = operatorChar.ToString();
        }
    }
}