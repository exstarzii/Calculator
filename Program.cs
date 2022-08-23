namespace Calculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            while (true)
            {
                try
                {
                    String input = Console.ReadLine();
                    float res = Expression.Evaluate(input);
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