using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10
{
    public class Calculator
    {
        public double Calculate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                return 0;

            string[] terms = expression.Split();

            if (terms.Length < 3)
                throw new Exception("Invalid expression");

            var stack = new Stack<double>();

            stack.Push(Convert.ToDouble(terms[0]));
            stack.Push(Convert.ToDouble(terms[1]));

            double a;
            double b;
            for (int i = 2; i < terms.Length; i++)
            {
                if (terms[i] == "+")
                {
                    b = stack.Pop();
                    a = stack.Pop();
                    stack.Push(a + b);
                }
                else if (terms[i] == "-")
                {
                    b = stack.Pop();
                    a = stack.Pop();
                    stack.Push(a - b);
                }
                else if (terms[i] == "*")
                {
                    b = stack.Pop();
                    a = stack.Pop();
                    stack.Push(a * b);
                }
                else if (terms[i] == "/")
                {
                    b = stack.Pop();
                    a = stack.Pop();
                    stack.Push(a / b);
                }
                else
                {
                    stack.Push(Convert.ToDouble(terms[i]));
                }
            }

            if (stack.Count() != 1)
                throw new Exception("Invalid expression");
            else
                return stack.Pop();
        }
    }
}