using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите x");
            var x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите y");
            var y = double.Parse(Console.ReadLine());
            var u = x * x + y * y <= 1 && y >= x && y >= -x ? Math.Sqrt(Math.Abs(x * x - 1)) : x + y;
            Console.WriteLine("u = " + u);
            Console.ReadKey();
        }
    }
}
