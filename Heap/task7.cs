using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AlgorithmsDataStructures2
{
    public class Heap
    {

        public int[] HeapArray; 
        public int Count;

        public Heap() { HeapArray = null; }

        public void MakeHeap(int[] a, int depth)
        {
            HeapArray = new int[(int)Math.Pow(2, (double)depth + 1) - 1];
            Count = 0;
            foreach (int key in a) Add(key);
        }

        private void SiftDown(int index)
        {
            int LeftChild = (index * 2) + 1;
            int RightChild = (index * 2) + 2;
            while (LeftChild < Count)
            {
                int MaxChild = LeftChild;
                if (RightChild < Count && HeapArray[RightChild] > HeapArray[LeftChild]) MaxChild = RightChild;
                if (HeapArray[index] >= HeapArray[MaxChild]) return;
                int tmp = HeapArray[index];
                HeapArray[index] = HeapArray[MaxChild];
                HeapArray[MaxChild] = tmp;
                index = MaxChild;
                LeftChild = (index * 2) + 1;
                RightChild = (index * 2) + 2;
            }
        }

        private void SiftUp(int index)
        {
            int Parent = (index - 1) / 2;
            int tmp;
            while (index > 0 && HeapArray[index] > HeapArray[Parent])
            {
                tmp = HeapArray[Parent];
                HeapArray[Parent] = HeapArray[index];
                HeapArray[index] = tmp;
                index = Parent;
                Parent = (index - 1) / 2;
            }
        }

        public int GetMax()
        {
            if (HeapArray == null || Count == 0) return -1;
            int max = HeapArray[0];
            HeapArray[0] = HeapArray[Count - 1];
            Count--;
            SiftDown(0);
            return max;
       
        }

        public bool Add(int key)
        {
            if (HeapArray == null || Count == HeapArray.Length) return false;
            HeapArray[Count] = key;
            SiftUp(Count);
            Count++;
            return true;
        }

        public bool IsHeapRight()
        {
            if (HeapArray == null || Count == 0) return true;
            for (int index = 1; index < Count; index++)
            {
                int parent = (index - 1) / 2;
                if (HeapArray[index] > HeapArray[parent]) return false;
            }
            return true;
        }

    }
}
