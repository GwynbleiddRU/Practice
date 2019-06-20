using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    class Edge
    {
        public readonly int v1, v2;

        public Edge(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }

    class Program
    {
        static int EnterInt()
        {
            int number;
            bool ok = false;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out number);
                if (!ok)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Введите целое число: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            } while (!ok);
            return number;
        }

        static List<string> catalogCycles;
        static List<Edge> E;

        static void Main(string[] args)
        {
            catalogCycles = new List<string>();
            Console.WriteLine("Введите размерность матрицы:");
            Console.WriteLine("Количество строк (вершин в графе):");
            int m = EnterInt();
            Console.WriteLine("Количество столбцов (рёбер в графе):");
            var n = EnterInt();
            Console.WriteLine("Введите матрицу инцидентности построчно, разделяя столбцы пробелом");
            var matrix = new string[m][];
            for (var i = 0; i < m; i++)
                matrix[i] = Console.ReadLine().Split(' ');
            E = new List<Edge>();
            for (int j = 0; j < n; j++)
            {
                int v1 = -1, v2 = -1;
                for (int i = 0; i < m; i++)
                {
                    if (matrix[i][j] != "1") continue;
                    if (v1 == -1) v1 = i;
                    else v2 = i;
                }
                E.Add(new Edge(v1, v2));
            }
            int[] color = new int[m];
            for (int i = 0; i < m; i++)
            {
                for (int k = 0; k < m; k++)
                    color[k] = 1;
                List<int> cycle = new List<int>();
                cycle.Add(i + 1);
                DFScycle(i, i, E, color, -1, cycle);
            }
            Console.WriteLine("Введите K");
            var K = int.Parse(Console.ReadLine());
            bool flag = false;
            foreach (var cycle in catalogCycles)
            {
                var edges = cycle.Split('-');
                if (edges.Length != K + 1) continue;
                Console.WriteLine("Цикл с длиной К: " + cycle);
                flag = true;
                break;
            }
            if (!flag) Console.WriteLine("Циклов с длиной К не существует в заданном графе");
            Console.ReadKey();
        }
        private static void DFScycle(int u, int endV, List<Edge> E, int[] color, int unavailableEdge, List<int> cycle)
        {
            if (u != endV)
                color[u] = 2;
            else if (cycle.Count >= 2)
            {
                cycle.Reverse();
                string s = cycle[0].ToString();
                for (int i = 1; i < cycle.Count; i++)
                    s += "-" + cycle[i].ToString();
                bool flag = false;
                for (int i = 0; i < catalogCycles.Count; i++)
                    if (catalogCycles[i].ToString() == s)
                    {
                        flag = true;
                        break;
                    }
                if (!flag)
                {
                    cycle.Reverse();
                    s = cycle[0].ToString();
                    for (int i = 1; i < cycle.Count; i++)
                        s += "-" + cycle[i].ToString();
                    catalogCycles.Add(s);
                }
                return;
            }
            for (int w = 0; w < E.Count; w++)
            {
                if (w == unavailableEdge)
                    continue;
                if (color[E[w].v2] == 1 && E[w].v1 == u)
                {
                    List<int> cycleNEW = new List<int>(cycle);
                    cycleNEW.Add(E[w].v2 + 1);
                    DFScycle(E[w].v2, endV, E, color, w, cycleNEW);
                    color[E[w].v2] = 1;
                }
                else if (color[E[w].v1] == 1 && E[w].v2 == u)
                {
                    List<int> cycleNEW = new List<int>(cycle);
                    cycleNEW.Add(E[w].v1 + 1);
                    DFScycle(E[w].v1, endV, E, color, w, cycleNEW);
                    color[E[w].v1] = 1;
                }
            }
        }
    }
}
