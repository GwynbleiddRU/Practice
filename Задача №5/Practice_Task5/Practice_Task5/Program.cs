using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ok = false;
            int n;
            do
            {
                Console.Write("Введите n: ");
                string buf = Console.ReadLine();
                ok = int.TryParse(buf, out n);
                if (!ok || n <= 0)
                    Console.WriteLine("n задается целым неотрицательным числом");
            } while (!ok || n <= 0);
            try
            {
                Console.WriteLine("Введите матрицу, построчно, разделяя числа пробелом");
                var matrix = new string[n][];
                for (int i = 0; i < n; i++)
                    matrix[i] = Console.ReadLine().Split(' ');
                //int sum = 0;
                int max = 0;
                
                for (int i = 0; i < n; i++)
                    for (int j = i; j != n - i - 1; j += Math.Sign((n % 2 == 0 ? n / 2 - 0.5 : n / 2) - i))
                    {
                        //sum += int.Parse(matrix[i][j]);
                        if (Convert.ToInt32(matrix[i][j]) > max)
                            max = Convert.ToInt32(matrix[i][j]);
                    }
                //sum += n;
                //Console.WriteLine("Сумма элементов в заштрихованной части матрицы: " + sum);
                Console.WriteLine("Максимальное значение в заштрихованной части матрицы: " + max);
            }
            catch
            {
                Console.WriteLine("Матрица задана неверно");
            }
        }
    }
}