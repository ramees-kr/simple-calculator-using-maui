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
            switch (operand)
            {
                case "+":
                    return operator1 + operator2;
                case "-":
                    return operator1 - operator2;
                case "x":
                    return operator1 * operator2;
                case "/":
                    if (operator2 != 0)
                        return operator1 / operator2;
                    else
                        throw new DivideByZeroException("Cannot divide by zero");
                default:
                    throw new ArgumentException("Invalid operand");
            }
        }

    }
}
