using System.Globalization;

namespace Calculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.WriteLine("Калькулятор обратной польской нотации");
            Console.WriteLine("пример ввода: (-2 + 2.5) * √4");
            Console.WriteLine("введите ваше выражение");
            while (true)
            {
                try
                {
                    String input = Expression.ConvertToRPN(Console.ReadLine());
                    Console.WriteLine(input);
                    double res = Expression.Evaluate(input);
                    Console.WriteLine(res);
                }
                catch (Exception)
                {
                    Console.WriteLine("некорректный ввод");
                }
            }
        }
    }
}