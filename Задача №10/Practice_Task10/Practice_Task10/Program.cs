using System;
using System.Linq;

namespace _10
{
    class Node
    {
        public int Value;
        public int Id;

        public Node(int id, int value)
        {
            Value = value;
            Id = id;
        }

        public static bool operator !=(Node n1, Node n2)
        {
            return !(n1 == n2);
        }

        public static bool operator ==(Node n1, Node n2)
        {
            return n1.Id == n2.Id;
        }
    }

    class Edge
    {
        public Node from;
        public Node to;

        public Edge(Node from, Node to)
        {
            this.from = from;
            this.to = to;
        }

        public Node AnotherNode(Node node)
        {
            return from == node ? from : to;
        }

        public override string ToString()
        {
            return $"({from.Id}, {from.Value})-->({to.Id}, {to.Value})";
        }
    }
    class Program
    {
        static void Tightening(int value, params Edge[] edges)
        {
            var flag = false;
            var graph = edges.ToList();
            Node node = null;
            foreach (var edge in edges)
            {
                if (edge.from.Value != value && edge.to.Value != value) continue;
                if (!flag)
                {
                    flag = true;
                    node = edge.from.Value == value ? edge.from : edge.to;
                    continue;
                }
                graph.Remove(edge);
                if (edge.@from == node && edge.to.Value == value || edge.to == node && edge.@from.Value == value) continue;
                if (edge.@from == node)
                {
                    var newEdge = new Edge(node, edge.to);
                    graph.Add(newEdge);
                }
                else
                {
                    var newEdge = new Edge(edge.@from, node);
                    graph.Add(newEdge);
                }
            }
            if (flag)
            {
                Console.WriteLine("Финальный граф, по ребрам");
                foreach (var edge in graph)
                {
                    Console.WriteLine(edge.ToString());
                }
            }
            else Console.WriteLine("Вершин с заданым значением не найдено");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение, по которому стягивать граф");
            var n = int.Parse(Console.ReadLine());
            var v1 = new Node(1, 0);
            var v2 = new Node(2, 6);
            var v3 = new Node(3, 7);
            var v4 = new Node(4, 7);
            var v5 = new Node(5, 7);
            Tightening(n,
                new Edge(v1, v2),
                new Edge(v3, v1),
                new Edge(v1, v4),
                new Edge(v4, v3),
                new Edge(v5, v3),
                new Edge(v2, v5));
            Console.ReadKey();
        }
    }
}
