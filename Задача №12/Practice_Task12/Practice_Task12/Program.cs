using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12
{
    class Sorting
    {
        public static int RadixSorting(int[] arr, int range, int length)
        {
            var count = 0;
            ArrayList[] lists = new ArrayList[range];
            for (int i = 0; i < range; ++i)
                lists[i] = new ArrayList();

            for (int step = 0; step < length; ++step)
            {
                foreach (var t in arr)
                {
                    int temp = (t % (int)Math.Pow(range, step + 1)) / (int)Math.Pow(range, step);
                    lists[temp].Add(t);
                }
                int k = 0;
                for (int i = 0; i < range; ++i)
                {
                    for (int j = 0; j < lists[i].Count; ++j)
                    {
                        count++;
                        arr[k++] = (int)lists[i][j];
                    }
                }
                for (int i = 0; i < range; ++i)
                    lists[i].Clear();
            }
            return count;
        }

        public static int HoareSort(int[] array, int start, int end, int count)
        {
            if (end == start) return count;
            var pivot = array[end];
            var storeIndex = start;
            for (int i = start; i <= end - 1; i++)
                if (array[i] <= pivot)
                {
                    count++;
                    var t = array[i];
                    array[i] = array[storeIndex];
                    array[storeIndex] = t;
                    storeIndex++;
                }

            var n = array[storeIndex];
            array[storeIndex] = array[end];
            array[end] = n;
            if (storeIndex > start) HoareSort(array, start, storeIndex - 1, count);
            if (storeIndex < end) HoareSort(array, storeIndex + 1, end, count);
            return count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите n: ");
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            int[] ascendingArr = new int[n];
            int[] descendingArr = new int[n];
            int[] randomArr = new int[n];
            int[] ascendingArr2 = new int[n];
            int[] descendingArr2 = new int[n];
            int[] randomArr2 = new int[n];

            Random rd = new Random();
            for (int i = 0; i < n; ++i)
            {
                ascendingArr[i] = i;
                descendingArr[i] = n - i;
                ascendingArr2[i] = i;
                descendingArr2[i] = n - i;
                var next = rd.Next(0, 100);
                randomArr[i] = next;
                randomArr2[i] = next;
            }
            System.Console.WriteLine("Массивы до сортировки:");
            foreach (var x in ascendingArr)
            {
                System.Console.Write(x + " ");
            }
            Console.WriteLine();
            foreach (var x in descendingArr)
            {
                System.Console.Write(x + " ");
            }
            Console.WriteLine();
            foreach (var x in randomArr)
            {
                System.Console.Write(x + " ");
            }
            Console.WriteLine();
            var rAsCount = Sorting.RadixSorting(ascendingArr, 10, 2);
            var rDesCount = Sorting.RadixSorting(descendingArr, 10, 2);
            var rRndCount = Sorting.RadixSorting(randomArr, 10, 2);
            System.Console.WriteLine("\n\nМассивы после поразрядной сортировки:\n");
            foreach (var x in ascendingArr)
            {
                System.Console.Write(x + " ");
            }
            Console.WriteLine();
            foreach (var x in descendingArr)
            {
                System.Console.Write(x + " ");
            }
            Console.WriteLine();
            foreach (var x in randomArr)
            {
                System.Console.Write(x + " ");
            }
            Console.WriteLine("\n\nКоличество пересылок в упорядоченном по возрастанию массиве: " + rAsCount);
            Console.WriteLine("Количество пересылок в упорядоченном по убыванию массиве: " + rDesCount);
            Console.WriteLine("Количество пересылок в неупорядоченном массиве: " + rRndCount);
            Console.WriteLine();
            var hAsCount = Sorting.HoareSort(ascendingArr2, 0, n - 1, 0);
            var hDesCount = Sorting.HoareSort(descendingArr2, 0, n - 1, 0);
            var hRndCount = Sorting.HoareSort(randomArr2, 0, n - 1, 0);
            System.Console.WriteLine("\n\nМассивы после быстрой сортировки:\n");
            foreach (var x in ascendingArr)
            {
                System.Console.Write(x + " ");
            }
            Console.WriteLine();
            foreach (var x in descendingArr)
            {
                System.Console.Write(x + " ");
            }
            Console.WriteLine();
            foreach (var x in randomArr)
            {
                System.Console.Write(x + " ");
            }
            Console.WriteLine();
            Console.WriteLine("\nКоличество пересылок в упорядоченном по возрастанию массиве: " + hAsCount);
            Console.WriteLine("Количество пересылок в упорядоченном по убыванию массиве: " + hDesCount);
            Console.WriteLine("Количество пересылок в неупорядоченном массиве: " + hRndCount);
            System.Console.ReadKey();
        }
    }
}
