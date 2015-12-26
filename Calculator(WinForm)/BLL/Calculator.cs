using System;

namespace BLL
{
    public class Calculator
    {
        public int Calculate(int num1, int num2, char action)
        {
            var result = 0;

            switch (action)
            {
                case '+': result = (num1 + num2); break;
                case '-': result = (num1 - num2); break;
                case '*': result = (num1 * num2); break;
                case '/':
                    {
                        if (num2 == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        result = (num1 / num2);
                    }
                    break;
                default: break;
            }
            return result;
        }
    }
}
