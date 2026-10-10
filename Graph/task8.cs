using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures2
{
    public class Vertex
    {
        public int Value;
        public Vertex(int val)
        {
            Value = val;
        }
    }

    public class SimpleGraph
    {
        public Vertex[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;

        public int VertexCount = 0;

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int[size, size];
            vertex = new Vertex[size];
        }

        public void AddVertex(int value)
        {
            if (VertexCount == max_vertex) return;
            Vertex NewVertex = new Vertex(value);
            for (int i = 0; i < max_vertex; i++)
            {
                if (vertex[i] == null)
                {
                    vertex[i] = NewVertex;
                    break;
                }
            }
            VertexCount++;
        }

        public void RemoveVertex(int v)
        {
            if (v < 0 || v >= max_vertex || vertex[v] == null) return;
            vertex[v] = null;
            VertexCount--;
            for (int i = 0; i < max_vertex; i++)
            {
                m_adjacency[v,i] = 0;
                m_adjacency[i, v] = 0;
            }
        }

        public bool IsEdge(int v1, int v2)
        {
            if (v1 < 0 || v1 >= max_vertex || vertex[v1] == null) return false;
            if (v2 < 0 || v2 >= max_vertex || vertex[v2] == null) return false;
            if (m_adjacency[v1, v2] == 1) return true;
            return false;
        }

        virtual public void AddEdge(int v1, int v2)
        {
            if (v1 < 0 || v1 >= max_vertex || vertex[v1] == null) return;
            if (v2 < 0 || v2 >= max_vertex || vertex[v2] == null) return;
            m_adjacency[v1, v2] = 1;
            m_adjacency[v2, v1] = 1;
        }

        virtual public void RemoveEdge(int v1, int v2)
        {
            if (v1 < 0 || v1 >= max_vertex || vertex[v1] == null) return;
            if (v2 < 0 || v2 >= max_vertex || vertex[v2] == null) return;
            m_adjacency[v1, v2] = 0;
            m_adjacency[v2, v1] = 0;
        }
    }
}