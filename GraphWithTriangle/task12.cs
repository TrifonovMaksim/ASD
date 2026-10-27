using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Vertex<T>
    {
        public bool Hit;
        public T Value;
        public Vertex(T val)
        {
            Value = val;
            Hit = false;
        }
    }

    public class SimpleGraph<T>
    {
        public Vertex<T>[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;

        public int VertexCount = 0;

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int[size, size];
            vertex = new Vertex<T>[size];
        }


        public virtual List<Vertex<T>> WeakVertices()
        {
            List<Vertex<T>> ResultVertexList = new List<Vertex<T>>();
            if (VertexCount < 1) return ResultVertexList;
            for(int i = 0; i < max_vertex; i++)
            {
                if (vertex[i] != null && !IsVertexInTriangle(i)) ResultVertexList.Add(vertex[i]);
            }
            return ResultVertexList;
        }

        public bool IsVertexInTriangle(int index)
        {
            for (int i = 0; i < max_vertex; i++)
            {
                if (m_adjacency[index, i] != 1) continue;
                for (int j = i + 1; j < max_vertex; j++)
                {
                    if (m_adjacency[index, j] == 1 && m_adjacency[i, j] == 1) return true;
                }
            }
            return false;
        }
        public List<Vertex<T>> BreadthFirstSearch(int VFrom, int VTo)
        {
            List<Vertex<T>> ResultVertexList = new List<Vertex<T>>();
            if (VFrom >= max_vertex || VFrom < 0 || VTo >= max_vertex || VTo < 0 || VTo == VFrom || vertex[VFrom] == null || vertex[VTo] == null) return ResultVertexList;
            for (int i = 0; i < max_vertex; i++)
            {
                if (vertex[i] != null) vertex[i].Hit = false;
            }
            int[] Parents = new int[max_vertex];
            for (int j = 0; j < max_vertex; j++) Parents[j] = -1;
            Queue<int> VertexQueue = new Queue<int>();
            VertexQueue.Enqueue(VFrom);
            vertex[VFrom].Hit = true;
            while (VertexQueue.Count != 0)
            {
                int CurVertexIndex = VertexQueue.Dequeue();
                if (CurVertexIndex == VTo)
                {
                    MakeWay(ResultVertexList, Parents, VFrom, VTo);
                    return ResultVertexList;
                }
                for (int i = 0; i < max_vertex; i++)
                {
                    if (m_adjacency[CurVertexIndex, i] == 1 && vertex[i].Hit == false)
                    {
                        VertexQueue.Enqueue(i);
                        vertex[i].Hit = true;
                        Parents[i] = CurVertexIndex;
                    }
                }
            }
            return ResultVertexList;
        }

        private void MakeWay(List<Vertex<T>> ResultVertexList, int[] Parents, int VFrom, int VTo)
        {
            int WayVertexIndex = VTo;
            while (WayVertexIndex != VFrom)
            {
                ResultVertexList.Add(vertex[WayVertexIndex]);
                WayVertexIndex = Parents[WayVertexIndex];
            }
            ResultVertexList.Add(vertex[VFrom]);
            ResultVertexList.Reverse();
        }

        public List<Vertex<T>> DepthFirstSearch(int VFrom, int VTo)
        {
            List<Vertex<T>> ResultVertexList = new List<Vertex<T>>();
            if (VFrom >= max_vertex || VFrom < 0 || VTo >= max_vertex || VTo < 0 || VTo == VFrom || VertexCount == 0 || vertex[VFrom] == null || vertex[VTo] == null) return ResultVertexList;
            Stack<int> VertexStack = new Stack<int>();
            VertexStack.Clear();
            for (int i = 0; i < max_vertex; i++)
            {
                if (vertex[i] != null) vertex[i].Hit = false;
            }
            if (m_adjacency[VFrom, VTo] == 1)
            {
                ResultVertexList.Add(vertex[VFrom]);
                ResultVertexList.Add(vertex[VTo]);
                return ResultVertexList;
            }
            DoDepthFirstSearch(VFrom, VTo);
            bool DoDepthFirstSearch(int From, int To)
            {
                vertex[From].Hit = true;
                VertexStack.Push(From);
                for (int i = 0; i < max_vertex; i++)
                {
                    if (m_adjacency[From, i] == 1 && vertex[i].Hit == false)
                    {
                        if (i == To)
                        {
                            VertexStack.Push(To);
                            int TmpCount = VertexStack.Count;
                            for (int j = 0; j < TmpCount; j++)
                            {
                                ResultVertexList.Add(vertex[VertexStack.Pop()]);
                            }
                            return true;
                        }
                        if (DoDepthFirstSearch(i, To)) return true;
                    }
                }
                VertexStack.Pop();
                if (VertexStack.Count == 0) return false;
                return false;
            }
            ResultVertexList.Reverse();
            return ResultVertexList;
        }


        public void AddVertex(T value)
        {
            if (VertexCount == max_vertex) return;
            Vertex<T> NewVertex = new Vertex<T>(value);
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
                m_adjacency[v, i] = 0;
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