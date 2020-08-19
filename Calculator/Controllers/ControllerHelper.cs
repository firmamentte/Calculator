
using System;
using Calculator.BLL;

namespace Calculator.Controllers
{
    public class ControllerHelper
    {
        public static class EnumHelper
        {
            public enum Number
            {
                [CalculatorBLL.EnumDescription("1")]
                One,
                [CalculatorBLL.EnumDescription("2")]
                Two,
                [CalculatorBLL.EnumDescription("3")]
                Three,
                [CalculatorBLL.EnumDescription("4")]
                Four,
                [CalculatorBLL.EnumDescription("5")]
                Five,
                [CalculatorBLL.EnumDescription("6")]
                Six,
                [CalculatorBLL.EnumDescription("7")]
                Seven,
                [CalculatorBLL.EnumDescription("8")]
                Eight,
                [CalculatorBLL.EnumDescription("9")]
                Nine,
                [CalculatorBLL.EnumDescription("0")]
                Zero
            }

            public enum Function
            {
                [CalculatorBLL.EnumDescription("CE")]
                ClearEntry,
                [CalculatorBLL.EnumDescription("C")]
                ClearAll,
                [CalculatorBLL.EnumDescription("=")]
                Equal
            }

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

            public static string GetDescription(Enum enumValue)
            {
                return CalculatorBLL.EnumHelper.GetDescription(enumValue);
            }
        }
    }
}
