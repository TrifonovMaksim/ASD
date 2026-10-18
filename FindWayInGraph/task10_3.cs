using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Tests
    {
        public static void DepthFirstSearch1()
        {
            SimpleGraph<int> test = new SimpleGraph<int>(5);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddEdge(0, 1);
            test.AddEdge(1, 2);
            test.AddEdge(2, 3);
            List<Vertex<int>> res = test.DepthFirstSearch(0, 3);
            Console.WriteLine(res != null && res.Count == 4 && res[0].Value == 1 && res[3].Value == 4 ? "Тест DepthFirstSearch1 пройден" : "Тест DepthFirstSearch1 не пройден");
        }
        public static void DepthFirstSearch2()
        {
            SimpleGraph<int> test = new SimpleGraph<int>(5);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddEdge(0, 1);
            test.AddEdge(1, 2);
            test.AddEdge(2, 3);
            List<Vertex<int>> res = test.DepthFirstSearch(3, 4);
            Console.WriteLine(res != null && res.Count == 0 ? "Тест DepthFirstSearch2 пройден" : "Тест DepthFirstSearch2 не пройден");
        }

        public static void IsConnected1()
        {
            SimpleGraphAdd<int> test = new SimpleGraphAdd<int>(4);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddEdge(0, 1);
            test.AddEdge(1, 2);
            test.AddEdge(2, 3);
            Console.WriteLine(test.IsConnected() ? "Тест IsConnected1 пройден" : "Тест IsConnected1 не пройден");
        }

        public static void IsConnected2()
        {
            SimpleGraphAdd<int> test = new SimpleGraphAdd<int>(4);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddEdge(0, 1);
            test.AddEdge(2, 3);
            Console.WriteLine(!test.IsConnected() ? "Тест IsConnected2 пройден" : "Тест IsConnected2 не пройден");
        }

        public static void LongestSimplePath1()
        {
            SimpleGraphAdd<int> test = new SimpleGraphAdd<int>(4);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddEdge(0, 1);
            test.AddEdge(1, 2);
            test.AddEdge(2, 3);
            test.m_adjacency[1, 0] = 0;
            test.m_adjacency[2, 1] = 0;
            test.m_adjacency[3, 2] = 0;
            Console.WriteLine(test.LongestSimplePath() == 3 ? "Тест LongestSimplePath1 пройден" : "Тест LongestSimplePath1 не пройден");
        }

        public static void LongestSimplePath2()
        {
            SimpleGraphAdd<int> test = new SimpleGraphAdd<int>(4);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddEdge(0, 1);
            test.AddEdge(0, 2);
            test.AddEdge(0, 3);
            Console.WriteLine(test.LongestSimplePath() == 2 ? "Тест LongestSimplePath2 пройден" : "Тест LongestSimplePath2 не пройден");
        }
        public static void Main(string[] args)
        {
            DepthFirstSearch1();
            DepthFirstSearch2();
            IsConnected1();
            IsConnected2();
            LongestSimplePath1();
            LongestSimplePath2();
        }
    }
}