namespace Calculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Калькулятор обратной польской нотации");
            Console.WriteLine("пример ввода: 162 2 1 + 4 * /");
            Console.WriteLine("введите ваше выражение");
            while (true)
            {
                try
                {
                    String input = Console.ReadLine();
                    double res = Expression.Evaluate(input);
                    Console.WriteLine(res);
                }
                catch (Exception e)
                {
                    Console.WriteLine("некорректный ввод");
                }
            }
        }
    }
}