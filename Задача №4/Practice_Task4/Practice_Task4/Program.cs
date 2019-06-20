using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static Func<int, double> f = (i) => 1d / (i * (i + 1));

        static void Main(string[] args)
        {
            double eps;
            bool ok = false;
            do
            {
                Console.Write("Введите epsilon: ");
                string buf = Console.ReadLine();
                ok = double.TryParse(buf, out eps);
                if (!ok || eps <= 0)
                    Console.WriteLine("epsilon задается неотрицательным числом");
            } while (!ok || eps <= 0);

            double sum = 0d;
            int i = 1;
            for (; i < 3; i++)
                sum += f(i);
            while (true)
            {
                if (f(i) < eps) break;
                sum += f(i);
                i++;
            }
            Console.WriteLine("Сумма равна: " + sum);
            Console.ReadKey();
        }
    }
}
