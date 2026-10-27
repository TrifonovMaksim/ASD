using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleGraphAdd<T> : SimpleGraph<T>
    {
        public SimpleGraphAdd(int size) : base(size)
        {
        }

        // Задание 1.Добавьте метод, подсчитывающий общее число треугольников в графе.
        public int NumberOfTrianglesInGraph()
        {
            if (VertexCount < 3) return 0;
            HashSet<string> Triangles = new HashSet<string>();
            for (int i = 0; i < max_vertex; i++)
            {
                if (vertex[i] != null ) VertexTriangleNeighbours(i, Triangles);
            }
            return Triangles.Count;
        }

        public void VertexTriangleNeighbours(int index, HashSet<string> Triangles)
        {
            for (int i = 0; i < max_vertex; i++)
            {
                if (m_adjacency[index, i] != 1) continue;
                for (int j = i + 1; j < max_vertex; j++)
                {
                    if (m_adjacency[index, j] == 1 && m_adjacency[i, j] == 1)
                    {
                        int[] TmpStorage = new int[3] {index, i, j};
                        Array.Sort(TmpStorage);
                        string Triangle = TmpStorage[0] + "-" + TmpStorage[1] + "-" + TmpStorage[2];
                        Triangles.Add(Triangle);
                    }
                }
            }
        }
        /* Треугольником считается случай, когда у вершины, между двумя ее соседями есть ребро.
         * Для этого поочередно берем каждую вершину, и проверяем ее соседей на наличие ребра.
         * Сложность по времени O(n^3), тройной вложенный цикл, идем по вершинам всем, и для каждой вершины идем по соседям,
         * и для каждого соседа идем по соседям.
         * Сложность по памяти O(n), создаем хэшсет для хранения треугольников.
         */

        // Задание 2. Реализуйте метод поиска узлов, не входящих ни в один треугольник в графе, только через интерфейс класса (операции над графом). 
        public override List<Vertex<T>> WeakVertices()
        {
            List<Vertex<T>> ResultVertexList = new List<Vertex<T>>();
            if (VertexCount < 1) return ResultVertexList;
            for (int i = 0; i < max_vertex; i++)
            {
                if (vertex[i] != null && !IsVertexInTriangleInterface(i)) ResultVertexList.Add(vertex[i]);
            }
            return ResultVertexList;
        }

        public bool IsVertexInTriangleInterface(int index)
        {
            for (int i = 0; i < max_vertex; i++)
            {
                if (!IsEdge(index, i)) continue;
                for (int j = i + 1; j < max_vertex; j++)
                {
                    if (IsEdge(index, j) && IsEdge(i, j)) return true;
                }
            }
            return false;
        }
        /* Вся разница с перввым заданием без звезды, что теперь для проверки наличия ребра между вершинами,
         * не напрямую обращаемся к матрице смежности, а через метод IsEdge.
         * Сложность по времени O(n^3), так же тройной вложенный цикл, где проверяем вхождение вершины в треугольник.
         * Сложность по памяти O(n), создаем список вершин.
         */


        // Рекомендации по решению задач задания 10.

        /* Рефлексия по прошлому заданию. 1.Будет ли неориентированный граф связным.
         * Сделал как в эталоне, обошел в глубину из произвольной вершины, затем проверил массив хит,
         * посещенны ли все вершины, если да, то граф связный.
         */

        /*Рефлексия по прошлому заданию. 2. Cамый длинный путь в ориентированном графе с циклами.
         *   В отличие от эталона не запоминал текущий путь, как в эталоне проверял посещена ли вершина,
         *   увеличиввал счетчик пути и запускал рекурсивно дальше обход. Когда доходил до вершины - листа,
         *   сравнивал путь с максимальным, и так по всем путям. 
         */
    }
}
