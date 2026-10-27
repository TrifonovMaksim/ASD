using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{

    public class Tests
    {
        public static void WeakVertices1()
        {
            SimpleGraph<int> test = new SimpleGraph<int>(9);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddVertex(5);
            test.AddVertex(6);
            test.AddVertex(7);
            test.AddVertex(8);
            test.AddVertex(9);
            test.AddEdge(0, 1);
            test.AddEdge(0, 2);
            test.AddEdge(1, 2);
            test.AddEdge(1, 3);
            test.AddEdge(2, 3);
            test.AddEdge(0, 4);
            test.AddEdge(2, 5);
            test.AddEdge(4, 5);
            test.AddEdge(5, 7);
            test.AddEdge(5, 6);
            test.AddEdge(6, 7);
            test.AddEdge(7, 8);
            List<Vertex<int>> res = test.WeakVertices();
            Console.WriteLine(res != null && res.Count == 2 && res[0].Value == 5 && res[1].Value == 9 ? "Тест WeakVertices1 пройден" : "Тест WeakVertices1 не пройден");
        }

        public static void WeakVertices2()
        {
            SimpleGraph<int> test = new SimpleGraph<int>(9);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddVertex(5);
            test.AddVertex(6);
            test.AddVertex(7);
            test.AddVertex(8);
            test.AddVertex(9);
            test.AddEdge(0, 1);
            test.AddEdge(0, 2);
            test.AddEdge(1, 2);
            test.AddEdge(1, 3);
            test.AddEdge(2, 3);
            test.AddEdge(0, 4);
            test.AddEdge(2, 5);
            test.AddEdge(4, 5);
            test.AddEdge(5, 7);
            test.AddEdge(5, 6);
            test.AddEdge(6, 7);
            test.AddEdge(7, 8);
            test.AddEdge(8, 5);
            List<Vertex<int>> res = test.WeakVertices();
            Console.WriteLine(res != null && res.Count == 1 && res[0].Value == 5 ? "Тест WeakVertices2 пройден" : "Тест WeakVertices2 не пройден");
        }

        public static void WeakVertices3()
        {

            SimpleGraph<int> test = new SimpleGraph<int>(4);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddVertex(5);
            test.AddEdge(0, 1);
            test.AddEdge(0, 2);
            test.AddEdge(1, 2);
            test.AddEdge(1, 3);
            test.AddEdge(2, 3);
            List<Vertex<int>> res = test.WeakVertices();
            Console.WriteLine(res != null && res.Count == 0 ? "Тест WeakVertices3 пройден" : "Тест WeakVertices3 не пройден");
        }


        public static void NumberOfTrianglesInGraph1()
        {
            SimpleGraphAdd<int> test = new SimpleGraphAdd<int>(9);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddVertex(5);
            test.AddVertex(6);
            test.AddVertex(7);
            test.AddVertex(8);
            test.AddVertex(9);
            test.AddEdge(0, 1);
            test.AddEdge(0, 2);
            test.AddEdge(1, 2);
            test.AddEdge(1, 3);
            test.AddEdge(2, 3);
            test.AddEdge(0, 4);
            test.AddEdge(2, 5);
            test.AddEdge(4, 5);
            test.AddEdge(5, 7);
            test.AddEdge(5, 6);
            test.AddEdge(6, 7);
            test.AddEdge(7, 8);
            Console.WriteLine(test.NumberOfTrianglesInGraph() == 3 ? "Тест NumberOfTrianglesInGraph1 пройден" : "Тест NumberOfTrianglesInGraph1 не пройден");
        }

        public static void NumberOfTrianglesInGraph2()
        {
            SimpleGraphAdd<int> test = new SimpleGraphAdd<int>(9);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddVertex(5);
            test.AddVertex(6);
            test.AddVertex(7);
            test.AddVertex(8);
            test.AddVertex(9);
            test.AddEdge(0, 1);
            test.AddEdge(0, 2);
            test.AddEdge(1, 2);
            test.AddEdge(1, 3);
            test.AddEdge(2, 3);
            test.AddEdge(0, 4);
            test.AddEdge(2, 5);
            test.AddEdge(4, 5);
            test.AddEdge(5, 7);
            test.AddEdge(5, 6);
            test.AddEdge(6, 7);
            test.AddEdge(7, 8);
            test.AddEdge(8, 5);
            Console.WriteLine(test.NumberOfTrianglesInGraph() == 4 ? "Тест NumberOfTrianglesInGraph2 пройден" : "Тест NumberOfTrianglesInGraph2 не пройден");
        }

        public static void NumberOfTrianglesInGraph3()
        {
            SimpleGraphAdd<int> test = new SimpleGraphAdd<int>(6);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddVertex(5);
            test.AddVertex(6);
            test.AddEdge(0, 1);
            test.AddEdge(1, 2);
            test.AddEdge(2, 3);
            test.AddEdge(3, 4);
            test.AddEdge(4, 5);
            Console.WriteLine(test.NumberOfTrianglesInGraph() == 0 ? "Тест NumberOfTrianglesInGraph3 пройден" : "Тест NumberOfTrianglesInGraph3 не пройден");
        }

        public static void WeakVerticesAdd1()
        {
            SimpleGraphAdd<int> test = new SimpleGraphAdd<int>(9);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddVertex(5);
            test.AddVertex(6);
            test.AddVertex(7);
            test.AddVertex(8);
            test.AddVertex(9);
            test.AddEdge(0, 1);
            test.AddEdge(0, 2);
            test.AddEdge(1, 2);
            test.AddEdge(1, 3);
            test.AddEdge(2, 3);
            test.AddEdge(0, 4);
            test.AddEdge(2, 5);
            test.AddEdge(4, 5);
            test.AddEdge(5, 7);
            test.AddEdge(5, 6);
            test.AddEdge(6, 7);
            test.AddEdge(7, 8);
            List<Vertex<int>> res = test.WeakVertices();
            Console.WriteLine(res != null && res.Count == 2 && res[0].Value == 5 && res[1].Value == 9 ? "Тест WeakVerticesAdd1 пройден" : "Тест WeakVerticesAdd1 не пройден");
        }

        public static void WeakVerticesAdd2()
        {
            SimpleGraphAdd<int> test = new SimpleGraphAdd<int>(9);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddVertex(5);
            test.AddVertex(6);
            test.AddVertex(7);
            test.AddVertex(8);
            test.AddVertex(9);
            test.AddEdge(0, 1);
            test.AddEdge(0, 2);
            test.AddEdge(1, 2);
            test.AddEdge(1, 3);
            test.AddEdge(2, 3);
            test.AddEdge(0, 4);
            test.AddEdge(2, 5);
            test.AddEdge(4, 5);
            test.AddEdge(5, 7);
            test.AddEdge(5, 6);
            test.AddEdge(6, 7);
            test.AddEdge(7, 8);
            test.AddEdge(8, 5);
            List<Vertex<int>> res = test.WeakVertices();
            Console.WriteLine(res != null && res.Count == 1 && res[0].Value == 5 ? "Тест WeakVerticesAdd2 пройден" : "Тест WeakVerticesAdd2 не пройден");
        }

        public static void WeakVerticesAdd3()
        {

            SimpleGraphAdd<int> test = new SimpleGraphAdd<int>(4);
            test.AddVertex(1);
            test.AddVertex(2);
            test.AddVertex(3);
            test.AddVertex(4);
            test.AddVertex(5);
            test.AddEdge(0, 1);
            test.AddEdge(0, 2);
            test.AddEdge(1, 2);
            test.AddEdge(1, 3);
            test.AddEdge(2, 3);
            List<Vertex<int>> res = test.WeakVertices();
            Console.WriteLine(res != null && res.Count == 0 ? "Тест WeakVerticesAdd3 пройден" : "Тест WeakVerticesAdd3 не пройден");
        }

        public static void Main(string[] args)
        {
            WeakVertices1();
            WeakVertices2();
            WeakVertices3();
            NumberOfTrianglesInGraph1();
            NumberOfTrianglesInGraph2();
            NumberOfTrianglesInGraph3();
            WeakVerticesAdd1();
            WeakVerticesAdd2();
            WeakVerticesAdd3();
        }


    }
}