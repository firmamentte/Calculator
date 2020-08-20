using System;
using System.Reflection;
using Calculator.BLL.DataContract;

namespace Calculator.BLL
{
    public static class CalculatorBLL
    {
        [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
        public sealed class EnumDescriptionAttribute : Attribute
        {
            public string Description { get; }

            public EnumDescriptionAttribute(string description) : base()
            {
                Description = description;
            }
        }

        public static class EnumHelper
        {
            public static string GetDescription(Enum value)
            {
                if (value is null)
                {
                    throw new ArgumentNullException("value");
                }

                string description = value.ToString();
                FieldInfo fieldInfo = value.GetType().GetField(description);
                EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    description = attributes[0].Description;
                }
                return description;
            }
        }

        public static CalculateResp Calculate(CalculateReq calculateReq)
        {
            try
            {
                CalculatorService _calculatorService = new CalculatorService();

                if (calculateReq.MathSign == CalculatorEnum.MathSign.Addition.ToString())
                {
                    _calculatorService.Addition(calculateReq.GetNumber1, calculateReq.GetNumber2);
                }

                if (calculateReq.MathSign == CalculatorEnum.MathSign.Subtraction.ToString())
                {
                    _calculatorService.Subtraction(calculateReq.GetNumber1, calculateReq.GetNumber2);
                }

                if (calculateReq.MathSign == CalculatorEnum.MathSign.Division.ToString())
                {
                    _calculatorService.Division(calculateReq.GetNumber1, calculateReq.GetNumber2);
                }

                if (calculateReq.MathSign == CalculatorEnum.MathSign.Multiplication.ToString())
                {
                    _calculatorService.Multiplication(calculateReq.GetNumber1, calculateReq.GetNumber2);
                }

                return new CalculateResp()
                {
                    Answer = _calculatorService.Answer,
                    Number1 = calculateReq.GetNumber1,
                    Number2 = calculateReq.GetNumber2,
                    MathSign = calculateReq.MathSign
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
