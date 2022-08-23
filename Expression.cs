using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Expression
    {
        public static double Evaluate(String expression)
        {
            Stack<double> stack = new Stack<double>();
            stack.Push(0);
            for (int i = 0; i < expression.Length; i++)
            {
                if (Char.IsDigit(expression[i]) || expression[i] == ',')
                {
                    int startIndex = i;
                    while (Char.IsDigit(expression[i]) || expression[i] == ',')
                    {
                        i++;
                    }
                    string substr = expression.Substring(startIndex,i-startIndex);
                    stack.Push(double.Parse(substr));
                    i--;
                }
                else if ("+-/*".Contains(expression[i])) 
                {
                    double a = stack.Pop();
                    double b = stack.Pop();
                    double res = 0;
                    switch (expression[i])
                    {
                        case '+': res = b + a; break;
                        case '-': res = b - a; break;
                        case '*': res = b * a; break;
                        case '/': res = b / a; break;
                    }
                    stack.Push(res);
                }
            }
            return stack.Peek();
        }
    }
}
