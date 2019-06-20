using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите информационные разряды, например \"10001\"");
            var input = Console.ReadLine()
                .ToCharArray()
                .Select(x => x == '0' ? 0 : 1)
                .ToList();
            var result = "";
            foreach (var i in InsertControl(input))
            {
                result += i;
            }
            Console.WriteLine("Код Хэмминга:");
            Console.WriteLine(result);
            Console.ReadKey();
        }

        static List<int> InsertControl(List<int> input)
        {
            var m = input.Count;
            var k = 0;
            while (Math.Pow(2, k) < m + k + 1) k++;
            for (var i = 1; i <= m + k; i++)
            {
                var b = i & (i - 1);
                if (b != 0) continue;
                input.Insert(i - 1, 0);
            }
            for (var i = 1; i <= m + k; i++)
            {
                var b = i & (i - 1);
                if (b != 0) continue;
                var sum = 0;
                for (int j = i - 1; j < m - i; j += i + 1)
                    for (int l = 0; l < i; l++)
                    {
                        sum += input[j + l];
                    }
                input[i - 1] = sum % 2;
            }
            return input;
        }
    }
}
