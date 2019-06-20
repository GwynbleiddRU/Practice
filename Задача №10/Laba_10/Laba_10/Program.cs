using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_10
{
    class Program
    {
        static bool ok = false;
        static Random rnd = new Random();

        #region Functions
        static public int InputAmount()
        {
            int amount;
            string buf;
            bool ok;
            do
            {
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out amount);
                if (!ok)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ошибка! Необходимо ввести целое число!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            } while (!ok);
            return amount;
        }
        static void MakeObj(ref State[] arr, out int size)
        {
            Console.WriteLine("Введите количество элементов в массиве: ");
            do
            {
                size = InputAmount();
                if (size < 1 || size > 300)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Введите число, отличное от 0, не превышающее 300");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            } while (size < 1 || size > 300);

            arr = new Laba_10.State[size];
            for (int i = 0; i < size; i++)
            {
                int ts_num = rnd.Next(1, 150);
                if (ts_num <= 50)
                {
                    Monarchy c = new Laba_10.Monarchy();
                    State s = c;
                    //s.Name = "монархия";
                    arr[i] = s;
                }
                if (ts_num > 50 && ts_num <= 100)
                {
                    Republic t = new Laba_10.Republic();
                    State s = t;
                    //s.Name = "республика";
                    arr[i] = s;
                }
                if (ts_num > 100)
                {
                    Kingdom t = new Laba_10.Kingdom();
                    State s = t;
                    //s.Name = "Королевство";
                    arr[i] = s;
                }
            }
            ok = true;
        }

        static void MenuZ1()
        {
            Console.WriteLine();
            Console.WriteLine(@"1. Вывести массив.
2. Вывести элемент массива.
0. Назад.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nВыберите действие: ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void MasView(ref State[] arr, int size)
        {
            int response = -1;
            //Console.WriteLine("\nЧасть 1");
            if (ok == true)
            {
                do
                {
                    MenuZ1();
                    do
                    {
                        response = InputAmount();
                        if (response < 0 || response > 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Выберите вариант 1-2 или вернитесь в предыдущее меню");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    } while (response < 0 || response > 2);

                    switch (response)
                    {
                        case 1:
                            {
                                Console.WriteLine("Элементы массива: ");
                                for (int i = 0; i < size; i++)
                                {
                                    arr[i].Show();
                                }
                                break;
                            }
                        case 2:
                            {
                                int num = 0;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Введите номер элемента для просмотра: ");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                num = InputAmount();

                                do
                                {
                                    if (num > size || num < 1)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Неверно введен номер элемента! Повторите ввод! ");
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        num = InputAmount();
                                    }

                                } while (num > size || num < 1);

                                Console.WriteLine("Элемент {0} :", num);
                                arr[num - 1].Show();
                                break;
                            }
                        case 0: break;
                    }
                } while (response != 0);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Массив элементов не создан!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        static void Menu()
        {
            Console.WriteLine(@"
1. Создать массив.
2. Печать массива.
3. Поиск монархов.
0. Выход");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nВыберите действие: ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        #endregion Functions
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Добро пожаловать в обозреватель государств!");
            Console.ForegroundColor = ConsoleColor.Gray;
            State[] arr = null;
            int size = 0;
            int response = -1;
            do
            {
                Menu();
                do
                {
                    response = InputAmount();
                    if (response < 0 || response > 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Выберите вариант 1-3 или завершите приложение");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                } while (response < 0 || response > 3);

                switch (response)
                {
                    case 1:
                        {
                            MakeObj(ref arr, out size);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nМассив создан");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        }
                    case 2: MasView(ref arr, size); break;
                    case 3:
                        {
                            int check = 0;
                            int amount = Kingdom.MonarchSearch();

                            for (int i = 0; i < Kingdom.counter; i++)
                            {
                                if (amount == 1 && Kingdom.CONTINENT_LIST[i] == "Европа") { Console.WriteLine("Монарх континента " + Kingdom.CONTINENT_LIST[i] + ": " + Kingdom.MONARCH_LIST[i]); check = 1; continue; }
                                if (amount == 2 && Kingdom.CONTINENT_LIST[i] == "Азия") { Console.WriteLine("Монарх континента " + Kingdom.CONTINENT_LIST[i] + ": " + Kingdom.MONARCH_LIST[i]); check = 1; continue; }
                                if (amount == 3 && Kingdom.CONTINENT_LIST[i] == "Африка") { Console.WriteLine("Монарх континента " + Kingdom.CONTINENT_LIST[i] + ": " + Kingdom.MONARCH_LIST[i]); check = 1; continue; }
                                if (amount == 4 && Kingdom.CONTINENT_LIST[i] == "Австралия") { Console.WriteLine("Монарх континента " + Kingdom.CONTINENT_LIST[i] + ": " + Kingdom.MONARCH_LIST[i]); check = 1; continue; }
                                if (amount == 5 && Kingdom.CONTINENT_LIST[i] == "Антарктида") { Console.WriteLine("Монарх континента " + Kingdom.CONTINENT_LIST[i] + ": " + Kingdom.MONARCH_LIST[i]); check = 1; continue; }
                                if (amount == 6 && Kingdom.CONTINENT_LIST[i] == "Северная Америка") { Console.WriteLine("Монарх континента " + Kingdom.CONTINENT_LIST[i] + ": " + Kingdom.MONARCH_LIST[i]); check = 1; continue; }
                                if (amount == 7 && Kingdom.CONTINENT_LIST[i] == "Южная Америка") { Console.WriteLine("Монарх континента " + Kingdom.CONTINENT_LIST[i] + ": " + Kingdom.MONARCH_LIST[i]); check = 1; continue; }
                                if (amount == 8 && Kingdom.CONTINENT_LIST[i] == "Программная Инженерия") { Console.WriteLine("Монарх континента " + Kingdom.CONTINENT_LIST[i] + ": " + Kingdom.MONARCH_LIST[i]); check = 1; continue;}
                            }

                            if (check == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("На выбранном континенте монархов не обнаружено");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }

                            break;
                        }

                    case 0: break;
                }
            } while (response != 0);
        }
    }
}
