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
                float _answer = 0, 
                    _number1 = float.Parse(calculateReq.Number1.Replace('.', ',').Replace(" ", "")), 
                    _number2 = float.Parse(calculateReq.Number2.Replace('.', ',').Replace(" ", ""));

                if (calculateReq.MathSign == CalculatorEnum.MathSign.Addition.ToString())
                {
                    _answer = _number1 + _number2;
                }

                if (calculateReq.MathSign == CalculatorEnum.MathSign.Subtraction.ToString())
                {
                    _answer = _number1 - _number2;
                }

                if (calculateReq.MathSign == CalculatorEnum.MathSign.Division.ToString())
                {
                    _answer = _number1 / _number2;
                }

                if (calculateReq.MathSign == CalculatorEnum.MathSign.Multiplication.ToString())
                {
                    _answer = _number1 * _number2;
                }

                return new CalculateResp()
                {
                    Answer = _answer,
                    Number1 = _number1,
                    Number2 = _number2,
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
