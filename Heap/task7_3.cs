using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AlgorithmsDataStructures2
{
    public class Tests
    {
        public static void MakeHeap1()
        {
            int[] arr = new int[] {1, 4, 8, 2, 0, 9, 5};
            Heap test = new Heap();
            test.MakeHeap(arr, 2);
            Console.WriteLine(test.HeapArray != null && test.Count == 7 && test.HeapArray[0] == 9 ? "Тест MakeHeap1 пройден" : "Тест MakeHeap1 не пройден");
        }

        public static void MakeHeap2()
        {
            int[] arr = new int[] { };
            Heap test = new Heap();
            test.MakeHeap(arr, 2);
            Console.WriteLine(test.HeapArray != null && test.Count == 0 ? "Тест MakeHeap2 пройден" : "Тест MakeHeap2 не пройден");
        }

        public static void Add1()
        {
            int[] arr = new int[] {1, 3, 5};
            Heap test = new Heap();
            test.MakeHeap(arr, 2);
            Console.WriteLine(test.Add(10) && test.Count == 4 && test.HeapArray[0] == 10 ? "Тест Add1 пройден" : "Тест Add1 не пройден");
        }

        public static void Add2()
        {
            int[] arr = new int[] { 1, 3, 5 };
            Heap test = new Heap();
            test.MakeHeap(arr, 1);
            Console.WriteLine(!test.Add(10) && test.Count == 3 ? "Тест Add2 пройден" : "Тест Add2 не пройден");
        }

        public static void GetMax1()
        {
            int[] arr = new int[] { 1, 3, 5, 9};
            Heap test = new Heap();
            test.MakeHeap(arr, 2);
            Console.WriteLine(test.GetMax() == 9 && test.Count == 3 ? "Тест GetMax1 пройден" : "Тест GetMax1 не пройден");
        }

        public static void GetMax2()
        {
            int[] arr = new int[] {};
            Heap test = new Heap();
            test.MakeHeap(arr, 2);
            Console.WriteLine(test.GetMax() == -1 && test.Count == 0 ? "Тест GetMax2 пройден" : "Тест GetMax2 не пройден");
        }

        public static void IsHeapRight1()
        {
            int[] arr = new int[] {1, 4, 8, 2, 0};
            Heap test = new Heap();
            test.MakeHeap(arr, 2);
            Console.WriteLine(test.IsHeapRight() ? "Тест IsHeapRight1 пройден" : "Тест IsHeapRight1 не пройден");
        }

        public static void IsHeapRight2()
        {
            int[] arr = new int[] { 1, 4, 8};
            Heap test = new Heap();
            test.MakeHeap(arr, 2);
            test.HeapArray[1] = 100;
            Console.WriteLine(!test.IsHeapRight() ? "Тест IsHeapRight2 пройден" : "Тест IsHeapRight2 не пройден");
        }

        public static void FindMaxInRange1()
        {
            int[] arr = new int[] { 1, 4, 8, 2, 0, 9};
            HeapAdd test = new HeapAdd();
            test.MakeHeap(arr, 2);
            Console.WriteLine(test.FindMaxInRange(0, 11) == 9 ? "Тест FindMaxInRange1 пройден" : "Тест FindMaxInRange1 не пройден");
        }

        public static void FindMaxInRange2()
        {
            int[] arr = new int[] { 1, 4, 8, 2};
            HeapAdd test = new HeapAdd();
            test.MakeHeap(arr, 2);
            Console.WriteLine(test.FindMaxInRange(10, 11) == default(int) ? "Тест FindMaxInRange2 пройден" : "Тест FindMaxInRange2 не пройден");
        }

        public static void UnionTwoHeaps1()
        {
            int[] arr1 = new int[] { 1, 4, 8};
            HeapAdd test1 = new HeapAdd();
            test1.MakeHeap(arr1, 2);
            int[] arr2 = new int[] { 5, 8, 9};
            HeapAdd test2 = new HeapAdd();
            test2.MakeHeap(arr2, 1);
            test1.UnionTwoHeaps(test2);
            Console.WriteLine(test1.Count == 6 && test1.IsHeapRight() && test1.HeapArray[0] == 9 ? "Тест UnionTwoHeaps1 пройден" : "Тест UnionTwoHeaps1 не пройден");
        }
        public static void Main(string[] args)
        {
            MakeHeap1();
            MakeHeap2();
            Add1();
            Add2();
            GetMax1();
            GetMax2();
            IsHeapRight1();
            IsHeapRight2();
            FindMaxInRange1();
            FindMaxInRange2();
            UnionTwoHeaps1();
        }
    }
}