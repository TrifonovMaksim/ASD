using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class aBST
    {
        public int?[] Tree;

        public aBST(int depth)
        {
            int tree_size = Convert.ToInt32(Math.Pow(2, depth + 1) - 1);
            Tree = new int?[tree_size];
            for (int i = 0; i < tree_size; i++) Tree[i] = null;
        }

        public int? FindKeyIndex(int key)
        {
            int index = 0;
            while (index < Tree.Length)
            {
                if (Tree[index] == null) return -index;
                if (Tree[index] == key) return index;
                else if (Tree[index] > key) index = index * 2 + 1;
                else index = index * 2 + 2;
            }
            return null; 
        }

        public int AddKey(int key)
        {
            int? InsertIndex = FindKeyIndex(key);   
            if (InsertIndex == null) return -1;
            int ResultIndex = InsertIndex.Value;
            if (ResultIndex == 0 && Tree[ResultIndex] == null)
            {
                Tree[0] = key;  
                return 0;
            }
            else if (ResultIndex < 0)
            {
                Tree[-ResultIndex] = key;
                return -ResultIndex;
            }      
            else return ResultIndex;
        }

    }
}