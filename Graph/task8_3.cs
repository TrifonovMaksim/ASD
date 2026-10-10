using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures2
{
    public class Tests
    {
        public static void IsEdge()
        {
            SimpleGraph test = new SimpleGraph(5);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddVertex(5);
            test.AddEdge(1, 2);
            Console.WriteLine(test.IsEdge(1, 2) && !test.IsEdge(2, 3) ? "Тест IsEdge пройден" : "Тест IsEdge не пройден");
        }
        public static void AddVertex()
        {
            SimpleGraph test = new SimpleGraph(5);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddEdge(0, 1);
            test.AddVertex(3);
            test.AddEdge(1, 2);
            test.AddVertex(4);
            test.AddEdge(2, 3);
            test.AddVertex(5);
            Console.WriteLine(test.IsEdge(0, 1) && test.IsEdge(1, 2) && test.IsEdge(2, 3) && !test.IsEdge(3, 4) ? "Тест AddVertex пройден" : "Тест AddVertex не пройден");
        }

        public static void AddEdge()
        {
            SimpleGraph test = new SimpleGraph(5);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddVertex(5);
            bool IsConnection = test.IsEdge(1, 2);
            test.AddEdge(1, 2);
            Console.WriteLine(!IsConnection && test.IsEdge(1, 2) ? "Тест AddEdge пройден" : "Тест AddEdge не пройден");
        }

        public static void RemoveEdge()
        {
            SimpleGraph test = new SimpleGraph(5);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddEdge(0, 1);
            test.AddVertex(3);
            test.AddEdge(1, 2);
            test.AddVertex(4);
            test.AddEdge(2, 3);
            test.AddVertex(5);
            bool IsConnection = test.IsEdge(1, 2);
            test.RemoveEdge(1, 2);
            Console.WriteLine(IsConnection && !test.IsEdge(1, 2) ? "Тест RemoveEdge пройден" : "Тест RemoveEdge не пройден");
        }

        public static void RemoveVertex()
        {
            SimpleGraph test = new SimpleGraph(5);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddEdge(0, 1);
            test.AddVertex(3);
            test.AddEdge(1, 2);
            test.AddVertex(4);
            test.AddEdge(2, 3);
            test.AddVertex(5);
            bool IsConnection1 = test.IsEdge(1, 2);
            bool IsConnection2 = test.IsEdge(2, 3);
            test.RemoveVertex(2);
            Console.WriteLine(IsConnection1 && IsConnection2 && !test.IsEdge(1, 2) && !test.IsEdge(2, 3) ? "Тест RemoveVertex пройден" : "Тест RemoveVertex не пройден");
        }

        public static void IsCycled1()
        {
            SimpleGraphAdd test = new SimpleGraphAdd(5);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddEdge(0, 1);
            test.AddVertex(3);
            test.AddEdge(1, 2);
            test.AddVertex(4);
            test.AddEdge(2, 1);
            test.AddVertex(5);
            Console.WriteLine(test.IsCycled() ? "Тест IsCycled1 пройден" : "Тест IsCycled1 не пройден");
        }

        public static void IsCycled2()
        {
            SimpleGraphAdd test = new SimpleGraphAdd(5);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddEdge(1, 2);
            test.AddVertex(3);
            test.AddEdge(2, 3);
            test.AddVertex(4);
            test.AddEdge(3, 4);
            test.AddVertex(5);
            Console.WriteLine(!test.IsCycled() ? "Тест IsCycled2 пройден" : "Тест IsCycled2 не пройден");
        }

        public static void Main(string[] args)
        {
            IsEdge();
            AddVertex();
            AddEdge();
            RemoveEdge();
            RemoveVertex();
            IsCycled1();
            IsCycled2();
        }
    }
}