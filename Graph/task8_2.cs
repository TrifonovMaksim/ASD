using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures2
{
    public class SimpleGraphAdd : SimpleGraph
    {
        public SimpleGraphAdd(int size) : base(size)
        { }
        public override void AddEdge(int v1, int v2)
        {
            if (v1 < 0 || v1 >= max_vertex || vertex[v1] == null) return;
            if (v2 < 0 || v2 >= max_vertex || vertex[v2] == null) return;
            m_adjacency[v1, v2] = 1;
        }

        public override void RemoveEdge(int v1, int v2)
        {
            if (v1 < 0 || v1 >= max_vertex || vertex[v1] == null) return;
            if (v2 < 0 || v2 >= max_vertex || vertex[v2] == null) return;
            m_adjacency[v1, v2] = 0;
        }

        // Задание 2. Реализуйте направленный граф, представленный матрицей смежности, и добавьте метод проверки, будет ли он циклическим.
        public bool IsCycled()
        {
            if(VertexCount  == 0) return false;
            int[] VertexStatus = new int[max_vertex];
            for (int i = 0; i < max_vertex; i++)
            {
                if (vertex[i] == null || VertexStatus[i] == 2) continue;
                if (DoIsCycled(i, VertexStatus)) return true;
            }
            return false;
        }

        public bool DoIsCycled(int v, int[] VertexStatus)
        {
            VertexStatus[v] = 1;
            for (int i = 0; i < max_vertex; i++)
            {
                if (m_adjacency[v,i] == 1)
                {
                    if (VertexStatus[i] == 1) return true;
                    if (VertexStatus[i] == 0)
                    {
                        if (DoIsCycled(i, VertexStatus)) return true;
                    }
                }
            }
            VertexStatus[v] = 2;
            return false;
        }
        /* Для реализации классическим методом, требуется дополнительный массив,
         * в котором мы указываем статусы обхода вершин. Идем по массиву с вершинами,
         * проверям все пути из них, если находим вершину в которой уже были, значит есть цикл.
         * Сложность по памяти O(n), создаем массив размером с количествво ввершин.
         * Сложность по времени O(n^2), обходим через матрицу смежности.
         */
    }

    // Рекомендации по решению задач задания 6.

    /* Рефлексия по прошлому заданию. 2. Проверка, правильно ли распределены значения в двоичном дереве .
     * Сделал точно как в эталоне, спускался от корня и сравнивал значения узлов.
      */

    /* Рефлексия по прошлому заданию. 3. Проверка, сбалансировано ли двоичное дерево .
     * Сделал как в эталоне, тоже спускался от корня, и сравнивал рекурсивно длину левого и правого поддерева.
      */

}
