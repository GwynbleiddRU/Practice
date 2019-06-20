using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0049
{
    class Program
    {
        static void Main(string[] args)
        {

            //Массив цифр
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            //Массив букв
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };

            //n1 и n2 - количество возможных значений символа первой и второй строки соответственно
            int n1 = -1, n2 = -1;
            //Переменные p1 и p2 обозначают позиции в массиве букв, если в строках есть буквы
            int p1 = -1, p2 = -1;

            // Ввод строк и преобразование их в массив char
            char[] s1 = Console.ReadLine().ToCharArray();
            char[] s2 = Console.ReadLine().ToCharArray();


            int combinations = 1;
            bool isNum = false;

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] == '?')//Если символ - ?, то кол-во вероятных значений - 10
                    n1 = 10;
                else if (letters.Contains(s1[i])) //Если символ - буква, то кол-во пока не считаем, но фиксируем позицию
                    p1 = Array.IndexOf(letters, s1[i]);
                else
                {
                    isNum = true; //Иначе фиксируем, что символ - цифра
                    n1 = 1;
                }

                //Аналогично с символом второй строки
                if (s2[i] == '?')
                    n2 = 10;
                else if (letters.Contains(s2[i]))
                    p2 = Array.IndexOf(letters, s2[i]);
                else if (isNum && s2[i] != s1[i])//Если первый символ является цифрой, то кол-во вероятностей - 0
                    n2 = 0;
                else // Иначе - 1
                    n2 = 1;


                //Блок кода, если один из двух символов - буква
                if (n2 == -1 || n1 == -1)
                {
                    //Если буква - первый символ, второй символ - цифра
                    if (n2 == 1 && p1 != -1)
                        n1 = Array.IndexOf(letters, s1[i]) + 3 >= Array.IndexOf(numbers, s2[i]) && Array.IndexOf(letters, s1[i]) <= Array.IndexOf(numbers, s2[i]) ? 1 : 0;
                    //Если буква - второй символ, первый символ - цифра
                    else if (n1 == 1 && p2 != -1)
                        n2 = Array.IndexOf(letters, s2[i]) + 3 >= Array.IndexOf(numbers, s1[i]) && Array.IndexOf(letters, s2[i]) <= Array.IndexOf(numbers, s1[i]) ? 1 : 0;
                    //Если буква - второй символ, первый символ - знак вопроса
                    else if (p1 == -1 && p2 != -1)
                        n2 = 4;
                    //Если буква - первый символ, второй символ - знак вопроса
                    else if (p2 == -1 && p1 != -1)
                        n1 = 4;
                    //Если оба символа - буквы
                    else
                    {
                        n2 = 4 - Math.Abs(p2 - p1);
                        n2 = n2 < 0 ? 0 : n2;
                        n1 = n2;
                    }
                }

                //Подсчитываем количество вероятностей столбца символов 
                // Это минимальное значение из n1 и n2
                combinations *= Math.Min(n1, n2);
                n1 = -1;
                n2 = -1;
                p1 = -1;
                p2 = -1;
                isNum = false;



            }
            Console.WriteLine(combinations);
        }
    }
}
