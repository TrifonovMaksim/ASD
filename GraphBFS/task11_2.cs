using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AlgorithmsDataStructures2
{
    public class SimpleGraphAdd<T> : SimpleGraph<T>
    {
        public SimpleGraphAdd(int size) : base(size)
            {

            }

        // Задание 2. Используя BFS, найдите два наиболее удалённых друг от друга узла в обычном дереве, которое теперь воспринимаем как граф, и возвращайте это максимальное расстояние.
        public int MaxWayBetweenVertex()
        {
            if (VertexCount == 0  || VertexCount == 1) return 0;
            int MaxWay;
            int RemoteVertex;
            BFSGraph(Array.FindIndex(vertex, v => v != null), out RemoteVertex, out MaxWay);
            BFSGraph(RemoteVertex, out _, out MaxWay);
            return MaxWay;
        }

        private void BFSGraph(int Vertex, out int MaxWayVertex, out int Way)
        {
            for (int i = 0; i < max_vertex; i++)
            {
                if (vertex[i] != null) vertex[i].Hit = false;
            }
            Queue<int> VertexQueue = new Queue<int>();
            VertexQueue.Enqueue(Vertex);
            vertex[Vertex].Hit = true;
            int[] Distance = new int[max_vertex];
            int CurVertexIndex = Vertex;
            while (VertexQueue.Count != 0)
            {
                CurVertexIndex = VertexQueue.Dequeue();
                for (int i = 0; i < max_vertex; i++)
                {
                    if (m_adjacency[CurVertexIndex, i] == 1 && vertex[i].Hit == false)
                    {
                        VertexQueue.Enqueue(i);
                        vertex[i].Hit = true;
                        Distance[i] = Distance[CurVertexIndex] + 1;
                    }
                }
            }
            MaxWayVertex = CurVertexIndex;
            Way = Distance[CurVertexIndex];
        }
        /* Запускаем обход в ширину из любой не нулевой вершины,
         * во время обхода считаем расстояние для каждой вершины.
         * Самая последняя вершина вышедшая из очереди, находится на максимальном расстоянии.
         * Запускаем второй обход из найденой вершины,
         * и получаем максимальное расстояние между самыми отдаленными
         * вершинами в графе.
         * Сложность по времени O(n^2), проходим все вершины графа и их соседей.
         * Сложность по памяти O(n) создаем очередь, массив дистанций для вершин.
         */


        // Задание 3. Добавьте метод, который находит все циклы в текущем (неориентированном) графе с использованием BFS.
        public List<List<int>> FindAllCycles()
        {
            List<List<int>> ResultEdgeList = new List<List<int>>();
            if (VertexCount < 3) return ResultEdgeList;
            for (int i = 0; i < max_vertex; i++)
            {
                if (vertex[i] != null) vertex[i].Hit = false;
            }
            Queue<int> VertexQueue = new Queue<int>();
            int[] Parents = new int[max_vertex]; 
            HashSet<string> CheckEdge = new HashSet<string>();
            for (int j = 0; j < max_vertex; j++) Parents[j] = -1;
            int StartVertex = Array.FindIndex(vertex, v => v != null);
            VertexQueue.Enqueue(StartVertex);
            vertex[StartVertex].Hit = true;
            int CurVertexIndex = StartVertex;
            while (VertexQueue.Count != 0)
            {
                CurVertexIndex = VertexQueue.Dequeue();
                for (int i = 0; i < max_vertex; i++)
                {
                    if (m_adjacency[CurVertexIndex, i] == 1)
                    {
                        if (vertex[i].Hit == true && i != Parents[CurVertexIndex])
                        {
                            if (!HaveEdge(CheckEdge, CurVertexIndex, i))
                            {
                                FindCycle(ResultEdgeList, Parents, CurVertexIndex, i);
                            } 
                        }
                        if (vertex[i].Hit == false)
                        {
                            VertexQueue.Enqueue(i);
                            vertex[i].Hit = true;
                            Parents[i] = CurVertexIndex;
                        }
                       
                    }
                }
            }
            return ResultEdgeList;
        }

        private void FindCycle(List<List<int>> ResEdgeList, int[] Parents, int FirstVertex, int SecondVertex)
        {
            List<int> FirstVertexWayToRoot = new List<int>();
            List<int> SecondVertexWayToRoot = new List<int>();
            int CurVertex = FirstVertex;
            while (Parents[CurVertex] != -1)
            {
                FirstVertexWayToRoot.Add(CurVertex);
                CurVertex = Parents[CurVertex];
            }
            FirstVertexWayToRoot.Add(CurVertex);
            CurVertex = SecondVertex;
            while (Parents[CurVertex] != -1)
            {
                SecondVertexWayToRoot.Add(CurVertex);
                CurVertex = Parents[CurVertex];
            }
            SecondVertexWayToRoot.Add(CurVertex);
            int MaxParentIndex = FindCommonParent(FirstVertexWayToRoot, SecondVertexWayToRoot);
            if (MaxParentIndex == -1) return;
            List<int> Cycle = new List<int>();
            for (int i = FirstVertexWayToRoot.Count - 1; i >= MaxParentIndex; i--) Cycle.Add(FirstVertexWayToRoot[i]);
            for (int i = MaxParentIndex + 1; i < SecondVertexWayToRoot.Count; i++) Cycle.Add(SecondVertexWayToRoot[i]);
            ResEdgeList.Add(Cycle);
        }

        private int FindCommonParent(List<int> FirstWay, List<int> SecondWay)
        {
            FirstWay.Reverse();
            SecondWay.Reverse();
            int MinLength = Math.Min(FirstWay.Count, SecondWay.Count);
            int MaxParentIndex = -1;
            for (int i = 0; i < MinLength; i++)
            {
                if (FirstWay[i] == SecondWay[i]) MaxParentIndex = i;
            }
            return MaxParentIndex;
        }

        private bool HaveEdge(HashSet<string>CheckEdge, int FirstVertex, int SecondVertex)
        {
            string Edge = Math.Min(FirstVertex, SecondVertex) + "-" + Math.Max(FirstVertex, SecondVertex);
            return !CheckEdge.Add(Edge);
        }
        /* Как в прошлом задании обходим граф в ширину,
         * проверяем посещена ли вершина, если посещена и не является родителем текущей,
         * значит есть цикл. Создаем хэштаблицу для быстрой проверки записали ли мы уже цикл 
         * для данного ребра. Находим пути к корню от каждой вершины ребра,
         * Находим еще одно замыкание цикла не в корне и добавляем список вершин в результат.
         * Сложность по времени O(n^2), так-же проходим по всем вершинам и соседям.
         * Сложность по памяти O(n), создаем хэш сет, список результирующий, массив родителей.
         */


        // Рекомендации по решению задач задания 9.

        /* Рефлексия по прошлому заданию. 1. Лес из чётных деревьев, из которого удалено максимально возможное количество рёбер.
         * Как в эталоне для каждого узла делал обход в глубину и считал количество узлов в поддереве. 
         * Не создавал отдельную перменную для счетчика ребер.
         */

        /* Рефлексия по прошлому заданию. 2. Балансировка чётного двоичного дерева.
         * Как в эталоне сортируем дерево, находим середину и рекурсивно строим левое и правое поддерево.
         */

        /* Рефлексия по прошлому заданию. 3. Для любого заданного узла определить общее количество чётных поддеревьев.
         * Сделал как в эталоне, захожу в узел, если узел не лист счетчик уже равен 1, и для каждого ребенка запускаю
         * рекурсивно подсчет узлов. После рекурсии при возвращении к каждому узлу, проверяю четное ли количество узлов,
         * если да то увеличиваю счетчик четных поддеревьев.
         */
    }
}