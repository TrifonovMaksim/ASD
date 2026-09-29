using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures2
{
    public class Tests
    {
        public static void GenerateBBSTArray()
        {
            int[] arr = new int[] {1, 4, 8, 2, 0, 9, 5};
            int[] res = BalancedBST.GenerateBBSTArray(arr);
            Console.WriteLine(res != null && res.Length == 7 && res[0] == 4 && res[1] == 1 && res[2] == 8  ? "Тест GenerateBBSTArray пройден" : "Тест GenerateBBSTArray не пройден");
        }

        public static void DeleteNodeFromBBST1()
        {
            int[] arr = new int[] {1, 4, 8, 2, 0, 9, 5};
            arr = BalancedBST.GenerateBBSTArray(arr);
            int[] res = BalancedBSTAdd.DeleteNodeFromBBST(arr, 4);
            Console.WriteLine(res != null && res.Length == 7 && !res.Contains(4) && res[0] == 2 ? "Тест DeleteNodeFromBBST1 пройден" : "Тест DeleteNodeFromBBST1 не пройден");
        }

        public static void DeleteNodeFromBBST2()
        {
            int[] arr = new int[] {1, 4, 8, 2, 0, 9, 5};
            arr = BalancedBST.GenerateBBSTArray(arr);
            int[] res = BalancedBSTAdd.DeleteNodeFromBBST(arr, 1000);
            Console.WriteLine(res != null && res.Length == 7 && res.SequenceEqual(arr) ? "Тест DeleteNodeFromBBST2 пройден" : "Тест DeleteNodeFromBBST2 не пройден");
        }

        public static void Main(string[] args)
        {
            GenerateBBSTArray();
            DeleteNodeFromBBST1();
            DeleteNodeFromBBST2();
        }
    }
}