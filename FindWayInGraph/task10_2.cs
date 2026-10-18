using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleGraphAdd<T> : SimpleGraph<T>
    {
        public SimpleGraphAdd(int size) : base(size)
        {
        }

        // Задание 1. Добавьте метод, проверяющий, будет ли текущий неориентированный граф связным. Используйте для этого DFS.
        public bool IsConnected()
        {
            if (VertexCount == 0 || VertexCount == 1) return true;
            for(int i = 0; i < max_vertex; i++)
            {
                if (vertex[i] != null) vertex[i].Hit = false;
            }
            for (int j = 0;  j < max_vertex; j++)
            {
                if (vertex[j] != null)
                {
                    DoIsConnected(j);
                    break;
                }
            }
            void DoIsConnected(int CurVertex)
            {
                vertex[CurVertex].Hit = true;
                for(int i = 0; i < max_vertex; i++)
                {
                    if (m_adjacency[CurVertex, i] == 1 && vertex[i].Hit == false) DoIsConnected(i);
                }
            }
            bool IsConnected = true;
            for (int k = 0; k < max_vertex; k++)
            {
                if (vertex[k] != null && vertex[k].Hit == false)
                {
                    IsConnected = false;
                    break;
                }
            }
            return IsConnected;
        }
        /* Связный - это значит, что из каждой вершины можно добраться во все другие вершины.
         * Достаточно проверить одну вершину, если из нее есть путь во все, значит и у других есть.
         * Выбираю любую не нулевую вершину, для нее рекурсивно произвожу обход в глубину, затем проверяю,
         * были ли посещенны все остальные вершины, если да то граф связный.
         * Сложность по времени O(n^2), в худшем случае проходим все вершины и все ребра.
         * Сложность по памяти O(1), ничего не создаем.
         */


        // Задание 2. В ориентированном графе найдите длину самого длинного простого пути (пути без повторяющихся вершин). Граф может содержать циклы, и вам нужно игнорировать их при поиске.
        public int LongestSimplePath()
        {
            if (VertexCount == 0 ) return 0;
            int MaxPath = 0;
            int CurPath = 0;
            for (int i = 0; i < max_vertex; i++)
            {
                if (vertex[i] != null)
                {
                    for (int j = 0; j < max_vertex; j++)
                    {
                        if (vertex[j] != null) vertex[j].Hit = false;
                    }
                    CurPath = 0;
                    DoLongestSimplePath(i);
                }
            }
            void DoLongestSimplePath(int CurVertex)
            {
                vertex[CurVertex].Hit = true;
                for (int k = 0; k < max_vertex; k++)
                {
                    if (m_adjacency[CurVertex, k] == 1 && vertex[k].Hit == false)
                    {
                        CurPath++;
                        DoLongestSimplePath(k);
                    }

                }
                MaxPath = Math.Max(MaxPath, CurPath);
                CurPath--;
                vertex[CurVertex].Hit = false;
            }
            return MaxPath;
        }
        /* За длину принимаем количество ребер, из каждой вершины запускаем обход в глубину, 
         * сравнивая и записывая максимальный путь, в итоге его и получим.
         * Сложность по времени O(n^2) обходим граф из каждой вершины и проверяем все ребра.
         * Сложность по памяти O(1), ничего не создаем.
         */

        // Рекомендации по решению задач задания 8.

        /* Рефлексия по прошлому заданию. 2. Направленный граф, представленный матрицей смежности.
         * Отмечание посещенных вершин сделал похожм на эталон, в интернете нашел статью про 
         * 3-ех уровневое отмечание посещения и обработки вершин. Как в эталоне проверяюю, 
         * если вершина в статусе в обработке, значит цикл есть. В отличие от рекомендации,
         * не делал ассиметричной матрицу.
          */

    }
}