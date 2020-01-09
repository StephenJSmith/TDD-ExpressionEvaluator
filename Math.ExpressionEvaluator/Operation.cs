namespace Math.ExpressionEvaluator
{
    public class Operation
    {
        public Operand LOperand { get; set; }
        public Operator Op { get; set; }
        public Operand ROperand { get; set; }

        public Operation(Operand lOperand, Operator op, Operand rOperand)
        {
            this.LOperand = lOperand;
            this.Op = op;
            this.ROperand = rOperand;
        }

        public Operand Compute()
        {
            return new Operand(Op.Compute(LOperand, ROperand));
        }
    }
}
