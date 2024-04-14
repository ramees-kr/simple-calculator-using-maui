using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class CalculatorProcessor
    {
        public static double Process(double operator1, double operator2, string operand)
        {
            double result = 0;

            switch (operand)
            {
                case "+":
                    result = operator1 + operator2;
                    break;
                case "-":
                    result = operator1 - operator2;
                    break;
                case "x":
                    result = operator1 * operator2;
                    break;
                case "/":
                    if (operator2 != 0)
                        result = operator1 / operator2;
                    else
                        throw new DivideByZeroException("Cannot divide by zero");
                    break;
                default:
                    throw new ArgumentException("Invalid operand");
            }

            return Math.Round(result, 8);

        }

    }
}
