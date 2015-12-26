using System;

namespace BLL
{
    public class Calculation
    {
        public int Calculate(int num1, int num2, string act)
        {
            var result = 0;
            switch (act)
            {
                case "Add": result = num1 + num2; break;
                case "Sub": result = num1 - num2; break;
                case "Mul": result = num1 * num2; break;
                case "Div":
                    {
                        if (num2 == 0)
                        {
                            throw new DivideByZeroException();
                        }

                        result = num1 / num2;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
