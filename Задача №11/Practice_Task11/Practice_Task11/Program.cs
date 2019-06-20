using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите К");
            var k = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите перестановку, разделяя числа пробелом");
            var p = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine("Введите текст");
            var s = Console.ReadLine();
            for (int i = 0; i < s.Length % k; i++)
                s += " ";
            var output = Encrypt(s, p);
            Console.WriteLine("Зашифрованный текст:");
            Console.WriteLine(output);
            Console.WriteLine("Расшифрованный текст:");
            Console.WriteLine(Decrypt(output, p));
            Console.ReadKey();
        }

        static string Encrypt(string s, int[] p)
        {
            var result = new StringBuilder();
            for (int i = 1; i < s.Length; i += p.Length)
            {
                foreach (var n in p)
                {
                    result.Append(s[i - 1 + n - 1]);
                }
            }
            return result.ToString();
        }

        static string Decrypt(string s, int[] p)
        {
            var result = new char[s.Length];
            for (int i = 1; i < s.Length; i += p.Length)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    result[i - 1 + p[j] - 1] = s[i - 1 + j];
                }
            }

            for (int i = 0; i < p.Length; i++)
            {
                result[p[i] - 1] = s[i];
            }
            var answer = new StringBuilder();
            foreach (var e in result)
            {
                answer.Append(e);
            }
            return answer.ToString();
        }
    }
}
