using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AlgorithmsDataStructures2
{
    public class Tests
    {
        public static void BreadthFirstSearch1()
        {
            SimpleGraph<int> test = new SimpleGraph<int>(5);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddEdge(0, 1);
            test.AddEdge(1, 2);
            test.AddEdge(2, 3);
            List<Vertex<int>> res = test.BreadthFirstSearch(0, 3);
            Console.WriteLine(res != null && res.Count == 4 && res[0].Value == 1 && res[3].Value == 4 ? "Тест BreadthFirstSearch1 пройден" : "Тест BreadthFirstSearch1 не пройден");
        }

        public static void BreadthFirstSearch2()
        {
            SimpleGraph<int> test = new SimpleGraph<int>(5);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddVertex(5);
            test.AddEdge(0, 1);
            test.AddEdge(1, 2);
            test.AddEdge(2, 3);
            test.AddEdge(0, 4);
            test.AddEdge(4, 3);
            List<Vertex<int>> res = test.BreadthFirstSearch(0, 3);
            Console.WriteLine(res != null && res.Count == 3 && res[0].Value == 1 && res[2].Value == 4 ? "Тест BreadthFirstSearch2 пройден" : "Тест BreadthFirstSearch2 не пройден");
        }


        public static void MaxWayBetweenVertex1()
        {
            SimpleGraphAdd<int> test = new SimpleGraphAdd<int>(5);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddVertex(5);
            test.AddEdge(0, 1);
            test.AddEdge(1, 2);
            test.AddEdge(1, 3);
            test.AddEdge(3, 4);
            Console.WriteLine(test.MaxWayBetweenVertex() == 3 ? "Тест MaxWayBetweenVertex1 пройден" : "Тест MaxWayBetweenVertex1 не пройден");
        }

        public static void MaxWayBetweenVertex2()
        {
            SimpleGraphAdd<int> test = new SimpleGraphAdd<int>(5);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddVertex(5);
            test.AddEdge(0, 1);
            test.AddEdge(1, 2);
            test.AddEdge(2, 3);
            test.AddEdge(3, 4);
            Console.WriteLine(test.MaxWayBetweenVertex() == 4 ? "Тест MaxWayBetweenVertex2 пройден" : "Тест MaxWayBetweenVertex2 не пройден");
        }
      
        public static void FindAllCycles1()
        {
            SimpleGraphAdd<int> test = new SimpleGraphAdd<int>(3);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddEdge(0, 1);
            test.AddEdge(0, 2);
            test.AddEdge(1, 2);
            List<List<int>> res = test.FindAllCycles();
            Console.WriteLine(res != null && res.Count == 1 && res[0].Count == 3 ? "Тест FindAllCycles1 пройден" : "Тест FindAllCycles1 не пройден");
        }

        public static void Main(string[] args)
        {
            BreadthFirstSearch1();
            BreadthFirstSearch2(); 
            MaxWayBetweenVertex1();
            MaxWayBetweenVertex2();
            FindAllCycles1();
        }

     
    }
}