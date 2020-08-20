using System;

namespace Calculator.BLL
{
    public class CalculatorService : AnswerService, ICalculatorService
    {
        public void Addition(float number1, float number2)
        {
            Answer = number1 + number2;
        }

        public void Division(float number1, float number2)
        {
            if (number2 == 0)
                throw new Exception("Can not divide by a Zero");

            Answer = number1 / number2;
        }

        public void Multiplication(float number1, float number2)
        {
            Answer = number1 * number2;
        }

        public void Subtraction(float number1, float number2)
        {
            Answer = number1 - number2;
        }
    }
}
