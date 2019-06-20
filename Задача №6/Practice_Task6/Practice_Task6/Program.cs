using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    class Program
    {
        public static double EnterDouble()
        //Ввод вещественных чисел
        {
            double number;
            bool ok = false;
            do
            {
                ok = double.TryParse(Console.ReadLine(), out number);
                if (!ok)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Введите вещественное число: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            } while (!ok);
            return number;
        }

        static int N;
        static double E;
        static int count = 0;

        static void Main(string[] args)
        {
            bool ok = false;
            Console.Write("Введите a1: ");
            double a1 = EnterDouble();
            Console.Write("Введите a2: ");
            double a2 = EnterDouble();
            Console.Write("Введите a3: ");
            double a3 = EnterDouble();
            Console.Write("Введите N: ");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out N);
                if (!ok)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Введите целое число: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            } while (!ok);
            Console.Write("Введите E: ");
            E = EnterDouble();

            Console.WriteLine($"N = {N}, E = {E}");
            Console.WriteLine(
                "\nПервый столбец - номер числа, во втором отмечены числа, такие что |Ak - Ak-1| > E, а в третьем представлены сами числа");
            Console.WriteLine("  k  | ? |Ak");
            Console.WriteLine("-----|---|---");
            Console.WriteLine($" 001 |   |{a1}");
            if (Math.Abs(a2 - a1) > E)
            {
                Console.WriteLine($" 002 | + |{a2}");
                count++;
            }
            else Console.WriteLine($" 002 |   |{a2}");
            if (Math.Abs(a3 - a2) > E)
            {
                Console.WriteLine($" 003 | + |{a3}");
                count++;
            }
            else Console.WriteLine($" 003 |   |{a3}");
            Rec(a3, a2, a1);
            Console.ReadKey();
        }

        static void Rec(double Ak_1, double Ak_2, double Ak_3, int k = 4)
        {
            if (count == N) return;
            var a = Ak_1 + 2 * Ak_2 * Ak_3;
            var t = "";
            if (Math.Abs(a - Ak_1) > E)
            {
                t = "+";
                count++;
            }
            else t = " ";
            Console.WriteLine($" {k:000} | {t} |{a}");
            Rec(a, Ak_1, Ak_2, k + 1);
        }
    }
}
