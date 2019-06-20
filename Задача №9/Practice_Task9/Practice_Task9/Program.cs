using System;

namespace _9
{
    class Element
    {
        public Element next;
        public int value;
        public Element prev;

        public Element(int value)
        {
            this.value = value;
        }
    }

    class CycleLinkedList
    {
        public int Count = 0;
        public Element first;
        public Element last;
        public Element lastPos;

        public void Add(int value)
        {
            Count++;
            var e = new Element(value);
            if (Count == 1)
            {
                first = e;
                last = e;
                if (value > 0) lastPos = e;
                return;
            }
            if (e.value > 0)
            {
                if (lastPos == null)
                {
                    e.next = first;
                    first = e;
                }
                else
                {
                    e.next = lastPos.next;
                    e.prev = lastPos;
                    lastPos.next = e;
                }
                lastPos = e;
                if (lastPos.next == null) last = e;
            }
            if (e.value == 0)
            {
                if (lastPos == null)
                {
                    e.next = first;
                    first = e;
                }
                else
                {
                    if (lastPos == last) last = e;
                    e.next = lastPos.next;
                    e.prev = lastPos;
                    lastPos.next = e;
                }
            }
            if (e.value < 0)
            {
                e.prev = last;
                last.next = e;
                last = e;
            }
        }

        public Element Find(int value)
        {
            var cur = first;
            if (cur.value == value) return cur;
            for (int i = 1; i < Count; i++)
            {
                cur = cur.next;
                if (cur.value == value) return cur;
            }
            return null;
        }

        public void Remove(Element e)
        {
            e.prev = e.next;
            Count--;
        }

        public override string ToString()
        {
            var cur = first;
            var result = cur.value + " ";
            for (int i = 1; i < Count; i++)
            {
                cur = cur.next;
                result += cur.value + " ";
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int N;
            bool ok;
            var list = new CycleLinkedList();
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
            Console.WriteLine("Вводите числа");
            for (int i = 0; i < N; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine("Список:");
            Console.WriteLine(list.ToString());
            Console.ReadLine();
        }
    }
}
