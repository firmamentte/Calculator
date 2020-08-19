
namespace Calculator.BLL
{
    public class CalculatorEnum
    {
        public enum MathSign
        {
            [CalculatorBLL.EnumDescription("+")]
            Addition,
            [CalculatorBLL.EnumDescription("-")]
            Subtraction,
            [CalculatorBLL.EnumDescription("÷")]
            Division,
            [CalculatorBLL.EnumDescription("x")]
            Multiplication
        }
    }
}
