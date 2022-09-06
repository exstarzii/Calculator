using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Expression
    {
        public static double Evaluate(String expression)
        {
            char numberDecimalSeparator = CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator[0];
            Stack<double> stack = new Stack<double>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (Char.IsDigit(expression[i]) || expression[i] == numberDecimalSeparator)
                {
                    int startIndex = i;
                    while (Char.IsDigit(expression[i]) || expression[i] == numberDecimalSeparator)
                    {
                        i++;
                    }
                    string substr = expression.Substring(startIndex, i - startIndex);
                    stack.Push(double.Parse(substr));
                    i--;
                }
                else if ("+/*^%".Contains(expression[i]))
                {
                    double a = stack.Pop();
                    double b = stack.Pop();
                    double res = 0;
                    switch (expression[i])
                    {
                        case '+': res = b + a; break;
                        case '*': res = b * a; break;
                        case '/': res = b / a; break;
                        case '^': res = Math.Pow(b, a); break;
                        case '%': res = a * b / 100; break;
                    }
                    stack.Push(res);
                }else if ("-√".Contains(expression[i]))
                {
                    double a = stack.Pop();
                    double res = 0;
                    switch (expression[i])
                    {
                        case '-':
                            res = -a;
                            break;
                        case '√':
                            res = Math.Sqrt(a);
                            break;
                    }
                    stack.Push(res);
                }
            }
            return stack.Peek();
        }

        public static string ConvertToRPN(string input)
        {
            input = input.Replace(" ", "");
            input = input.Replace("--", "+");

            string output = string.Empty;
            Stack<char> operStack = new Stack<char>(); 

            for (int i = 0; i < input.Length; i++) 
            {
                

                if (IsDelimeter(input[i]))
                    continue; 
                
                if (Char.IsDigit(input[i])) 
                {
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i];
                        i++; 

                        if (i == input.Length) break; 
                    }

                    output += " ";
                    i--; 
                }

                if (IsOperator(input[i]))
                {
                    // замена '-' на '+ -' где необходимо
                    if (input[i] == '-')
                    {
                        for (int j = i - 1; j >= 0; j--)
                        {
                            if ("+-/*^√%".IndexOf(input[j]) != -1)
                            {
                                break;
                            }
                            else if (Char.IsDigit(input[j]))
                            {
                                if (operStack.Count > 0)
                                    if (GetPriority('+') <= GetPriority(operStack.Peek()))
                                        output += operStack.Pop().ToString() + " ";
                                operStack.Push('+');
                            }
                        }
                    }


                    if (input[i] == '(') 
                        operStack.Push(input[i]); 
                    else if (input[i] == ')') 
                    {
                        
                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else 
                    {
                        if (operStack.Count > 0)
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek()))
                                output += operStack.Pop().ToString() + " ";
                        operStack.Push(char.Parse(input[i].ToString()));
                    }
                }
            }
            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            return output;
        }
        static byte GetPriority(Char symbole)
        {
            switch (symbole)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '*': return 3;
                case '/': return 3;
                case '^': return 4;
                case '-': return 5;
                case '√': return 6;
                default: return 7;
            }
        }

        static private bool IsOperator(char с)
        {
            if (("+-/*^()√%".IndexOf(с) != -1))
                return true;
            return false;
        }
        static private bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }
    }
}
