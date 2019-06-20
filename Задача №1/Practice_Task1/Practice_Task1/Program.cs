using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0290
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ввод размеров карты с помощью LINQ
            int[] inputSize = Console.ReadLine().Split(new char[] { ' ' }).Select(s => int.Parse(s)).ToArray();
            //Создание двухмерного массива символов
            char[][] plan = new char[inputSize[0]][];
            //Ввод символов 
            for (int i = 0; i < inputSize[0]; i++)
            {
                plan[i] = Console.ReadLine().ToCharArray();

            }

            //Ввод размеров территории
            int[] inputSize2 = Console.ReadLine().Split(new char[] { ' ' }).Select(s => int.Parse(s)).ToArray();
            //Создание двухмерного массива символов территории
            char[][] map = new char[inputSize2[0]][];

            //Ввод символов
            for (int i = 0; i < inputSize2[0]; i++)
            {
                map[i] = Console.ReadLine().ToCharArray();

            }

            //Счетчик вероятных расположений
            int counter = 0;

            //есть ли совпадение
            bool isMatch = true;
            for (int i = 0; i < inputSize2[0] - inputSize[0] + 1; i++)
            {
                for (int j = 0; j < inputSize2[1] - inputSize[1] + 1; j++)
                {
                    isMatch = true;
                    for (int k = 0; k < inputSize[0]; k++)
                    {
                        for (int l = 0; l < inputSize[1]; l++)
                        {
                            if (plan[k][l] == '#' && plan[k][l] != map[i + k][j + l])
                            {
                                //Если совпадения нет, то выходим из внутреннего цикла
                                isMatch = false;
                                break;
                            }
                        }
                        //Если совпадения нет, выходим из внешнего цикла
                        if (!isMatch)
                        {
                            break;
                        }

                    }
                    //Если переменная сохранила значение true, прибавляем к счетчику 1
                    if (isMatch)
                        counter++;
                }
            }
            //Вывод
            Console.WriteLine(counter);
        }
    }
}
