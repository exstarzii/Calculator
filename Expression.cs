using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Expression
    {
        public static float Evaluate(String expression)
        {
            Stack<float> stack = new Stack<float>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (Char.IsDigit(expression[i]))
                {
                    int startIndex = i;
                    while (Char.IsDigit(expression[i]))
                    {
                        i++;
                    }
                    string substr = expression.Substring(startIndex,i-startIndex);
                    stack.Push(float.Parse(substr));
                    i--;
                }
                else if (expression[i] == '+' ||
                         expression[i] == '-' ||
                         expression[i] == '/' ||
                         expression[i] == '*')
                {
                    float a = stack.Pop();
                    float b = stack.Pop();
                    float res = 0;
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
