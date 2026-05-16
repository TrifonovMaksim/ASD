using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace AlgorithmsDataStructures
{
    public class Tests
    {
        public static void AddFront1()
        {
            Deque<int> test = new Deque<int>();
            test.AddFront(1);
            test.AddFront(2);
            int size_old = test.Size();
            int res = test.RemoveFront();
            int size_new = test.Size();
            Console.WriteLine(size_old== 2 && size_new == 1 && res == 2? "Тест AddFront1 пройден" : "Тест AddFront1 не пройден");
        }

        public static void AddFront2()
        {
            Deque<int> test = new Deque<int>();
            test.AddFront(1);
            test.AddFront(2);
            test.AddFront(1);
            test.AddFront(2);
            test.AddFront(1);
            test.AddFront(2);
            test.AddFront(1);
            test.AddFront(2);
            test.AddFront(1);
            test.AddFront(2);
            Console.WriteLine(test.Size() == 10 ? "Тест AddFront2 пройден" : "Тест AddFront2 не пройден");
        }

        public static void RemoveFront1()
        {
            Deque<int> test = new Deque<int>();
            int res = test.RemoveFront();
            Console.WriteLine(res == default(int) ? "Тест RemoveFront1 пройден" : "Тест RemoveFront1 не пройден");
        }

        public static void RemoveFront2()
        {
            Deque<int> test = new Deque<int>();
            test.AddFront(1);
            int res = test.RemoveFront();
            Console.WriteLine(res == 1 && test.Size() == 0 ? "Тест RemoveFront2 пройден" : "Тест RemoveFront2 не пройден");
        }

        public static void AddTail1()
        {
            Deque<int> test = new Deque<int>();
            test.AddTail(1);
            test.AddTail(2);
            int size_old = test.Size();
            int res = test.RemoveTail();
            int size_new = test.Size();
            Console.WriteLine(size_old == 2 && size_new == 1 && res == 2 ? "Тест AddTail1 пройден" : "Тест AddTail1 не пройден");
        }

        public static void AddTail2()
        {
            Deque<int> test = new Deque<int>();
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            Console.WriteLine(test.Size() == 10 ? "Тест AddTail2 пройден" : "Тест AddTail2 не пройден");
        }

        public static void RemoveTail1()
        {
            Deque<int> test = new Deque<int>();
            int res = test.RemoveTail();
            Console.WriteLine(res == default(int) ? "Тест RemoveTail1 пройден" : "Тест RemoveTail1 не пройден");
        }

        public static void RemoveTail2()
        {
            Deque<int> test = new Deque<int>();
            test.AddTail(1);
            int res = test.RemoveTail();
            Console.WriteLine(res == 1 && test.Size() == 0 ? "Тест RemoveTail2 пройден" : "Тест RemoveTail2 не пройден");
        }

        public static void Min1()
        {
            Solution.Deque1 test = new Solution.Deque1();
            test.AddTail(1);
            test.AddTail(2);
            test.AddFront(-1);
            test.AddFront(-7);
            test.AddFront(-11);
            test.AddTail(-20);
            Console.WriteLine(test.Min() == -20? "Тест Min1 пройден" : "Тест Min1 не пройден");
        }

        public static void Min2()
        {
            Solution.Deque1 test = new Solution.Deque1();
            Console.WriteLine(test.Min() == default(int) ? "Тест Min2 пройден" : "Тест Min2 не пройден");
        }

        public static void Min3()
        {
            Solution.Deque1 test = new Solution.Deque1();
            test.AddTail(1);
            test.AddTail(2);
            test.AddFront(-1);
            test.AddFront(-7);
            test.AddFront(-11);
            test.AddTail(-20);
            test.RemoveFront();
            test.RemoveTail();
            test.RemoveFront();
            test.RemoveTail();
            test.AddFront(-199);
            Console.WriteLine(test.Min() == -199 ? "Тест Min3 пройден" : "Тест Min3 не пройден");
        }

        public static void DynAddFront1()
        {
            Solution.Deque_on_DynArray<int> test = new Solution.Deque_on_DynArray<int>();
            test.AddFront(1);
            test.AddFront(2);
            int size_old = test.Size();
            int res = test.RemoveFront();
            int size_new = test.Size();
            Console.WriteLine(size_old == 2 && size_new == 1 && res == 2 ? "Тест DynAddFront1 пройден" : "Тест DynAddFront1 не пройден");
        }

        public static void DynAddFront2()
        {
            Solution.Deque_on_DynArray<int> test = new Solution.Deque_on_DynArray<int>();
            test.AddFront(1);
            test.AddFront(2);
            test.AddFront(1);
            test.AddFront(2);
            test.AddFront(1);
            test.AddFront(2);
            test.AddFront(1);
            test.AddFront(2);
            test.AddFront(1);
            test.AddFront(2);
            test.AddFront(1);
            test.AddFront(2);
            test.AddFront(1);
            test.AddFront(2);
            test.AddFront(1);
            test.AddFront(2);
            test.AddFront(1);
            test.AddFront(2);
            test.AddFront(1);
            test.AddFront(32);
            Console.WriteLine(test.Size() == 20 && test.RemoveFront() == 32 ? "Тест DynAddFront2 пройден" : "Тест DynAddFront2 не пройден");
        }

        public static void DynRemoveFront1()
        {
            Solution.Deque_on_DynArray<int> test = new Solution.Deque_on_DynArray<int>();
            int res = test.RemoveFront();
            Console.WriteLine(res == default(int) ? "Тест DynRemoveFront1 пройден" : "Тест DynRemoveFront1 не пройден");
        }

        public static void DynRemoveFront2()
        {
            Solution.Deque_on_DynArray<int> test = new Solution.Deque_on_DynArray<int>();
            test.AddFront(1);
            int res = test.RemoveFront();
            Console.WriteLine(res == 1 && test.Size() == 0 ? "Тест DynRemoveFront2 пройден" : "Тест DynRemoveFront2 не пройден");
        }

        public static void DynAddTail1()
        {
            Solution.Deque_on_DynArray<int> test = new Solution.Deque_on_DynArray<int>();
            test.AddTail(1);
            test.AddTail(2);
            int size_old = test.Size();
            int res = test.RemoveTail();
            int size_new = test.Size();
            Console.WriteLine(size_old == 2 && size_new == 1 && res == 2 ? "Тест DynAddTail1 пройден" : "Тест DynAddTail1 не пройден");
        }

        public static void DynAddTail2()
        {
            Solution.Deque_on_DynArray<int> test = new Solution.Deque_on_DynArray<int>();
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(231);
            Console.WriteLine(test.Size() == 20 && test.RemoveTail() == 231 ? "Тест DynAddTail2 пройден" : "Тест DynAddTail2 не пройден");
        }

        public static void DynRemoveTail1()
        {
            Solution.Deque_on_DynArray<int> test = new Solution.Deque_on_DynArray<int>();
            int res = test.RemoveTail();
            Console.WriteLine(res == default(int) ? "Тест DynRemoveTail1 пройден" : "Тест DynRemoveTail1 не пройден");
        }

        public static void DynRemoveTail2()
        {
            Solution.Deque_on_DynArray<int> test = new Solution.Deque_on_DynArray<int>();
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(22);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(2);
            test.AddTail(1);
            test.AddTail(231);
            test.RemoveTail();
            test.RemoveTail();
            test.RemoveTail();
            test.RemoveTail();
            test.RemoveTail();
            test.RemoveTail();
            test.RemoveTail();
            test.RemoveTail();
            test.RemoveTail();
            test.RemoveTail();
            int res = test.RemoveTail();
            Console.WriteLine(res == 22 && test.Size() == 9 ? "Тест DynRemoveTail2 пройден" : "Тест DynRemoveTail2 не пройден");
        }


        public static void Main(string[] args)
        {
            AddFront1();
            AddFront2();
            AddTail1();
            AddTail2();
            RemoveFront1();
            RemoveFront2();
            RemoveTail1();
            RemoveTail2();
            Solution.IsPolindrome("абаб");
            Solution.IsPolindrome("боб");
            Solution.IsPolindrome("дед");
            Solution.IsPolindrome("авытавы");
            Min1();
            Min2();
            Min3();
            DynAddFront1();
            DynAddFront2();
            DynAddTail1();
            DynAddTail2();
            DynRemoveFront1();
            DynRemoveFront2();
            DynRemoveTail1();
            DynRemoveTail2();
        }
    }
}