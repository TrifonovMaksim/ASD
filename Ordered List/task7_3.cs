using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace AlgorithmsDataStructures
{
    public class Tests
    {
        public static void Add1()
        {
            OrderedList<int> test = new OrderedList<int>(true);
            test.Add(1);
            test.Add(5);
            test.Add(2);
            test.Add(10);
            test.Add(-1);
            test.Add(3);
            test.Add(4);
            test.Add(6);
            var res = test.GetAll();
            int[] res_arr = new int[res.Count];
            for (int i = 0; i < res.Count; i++) res_arr[i] = res[i].value;
            int[] original = {-1, 1, 2, 3, 4, 5, 6, 10};
            bool flag = true;
            for(int i = 0; i < original.Length; i++)
            {
                if (original[i] != res_arr[i]) flag = false;
            }
            Console.WriteLine(flag ? "Тест Add1 пройден" : "Тест Add1 не пройден");
        }

        public static void Add2()
        {
            OrderedList<int> test = new OrderedList<int>(false);
            test.Add(1);
            test.Add(5);
            test.Add(2);
            test.Add(10);
            test.Add(-1);
            test.Add(3);
            test.Add(4);
            test.Add(6);
            var res = test.GetAll();
            int[] res_arr = new int[res.Count];
            for (int i = 0; i < res.Count; i++) res_arr[i] = res[i].value;
            int[] original = {10, 6, 5, 4, 3, 2, 1, -1};
            bool flag = true;
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] != res_arr[i]) flag = false;
            }
            Console.WriteLine(flag ? "Тест Add2 пройден" : "Тест Add2 не пройден");
        }

        public static void Add3()
        {
            OrderedList<int> test = new OrderedList<int>(true);
            test.Add(6);
            var res = test.GetAll();
            int[] res_arr = new int[res.Count];
            for (int i = 0; i < res.Count; i++) res_arr[i] = res[i].value;
            int[] original = {6};
            bool flag = true;
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] != res_arr[i]) flag = false;
            }
            Console.WriteLine(flag ? "Тест Add3 пройден" : "Тест Add3 не пройден");
        }

        public static void Delete1()
        {
            OrderedList<int> test = new OrderedList<int>(true);
            test.Add(1);
            test.Add(5);
            test.Add(2);
            test.Add(10);
            test.Add(-1);
            test.Add(3);
            test.Add(4);
            test.Add(6);
            test.Delete(3);
            var res = test.GetAll();
            int[] res_arr = new int[res.Count];
            for (int i = 0; i < res.Count; i++) res_arr[i] = res[i].value;
            int[] original = { -1, 1, 2, 4, 5, 6, 10 };
            bool flag = true;
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] != res_arr[i]) flag = false;
            }
            Console.WriteLine(flag ? "Тест Delete1 пройден" : "Тест Delete1 не пройден");
        }

        public static void Delete2()
        {
            OrderedList<int> test = new OrderedList<int>(false);
            test.Add(1);
            test.Add(5);
            test.Add(2);
            test.Add(10);
            test.Add(-1);
            test.Add(3);
            test.Add(4);
            test.Add(6);
            test.Delete(10);
            var res = test.GetAll();
            int[] res_arr = new int[res.Count];
            for (int i = 0; i < res.Count; i++) res_arr[i] = res[i].value;
            int[] original = { 6, 5, 4, 3, 2, 1, -1 };
            bool flag = true;
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] != res_arr[i]) flag = false;
            }
            Console.WriteLine(flag ? "Тест Delete2 пройден" : "Тест Delete2 не пройден");
        }

        public static void Delete3()
        {
            OrderedList<int> test = new OrderedList<int>(true);
            test.Delete(1);
        }

        public static void Delete4()
        {
            OrderedList<int> test = new OrderedList<int>(false);
            test.Add(1);
            test.Add(5);
            test.Add(2);
            test.Add(10);
            test.Add(-1);
            test.Add(3);
            test.Add(4);
            test.Add(6);
            test.Delete(11);
        }

        public static void Find1()
        {
            OrderedList<int> test = new OrderedList<int>(true);
            test.Add(1);
            test.Add(5);
            test.Add(2);
            test.Add(10);
            test.Add(-1);
            test.Add(3);
            test.Add(4);
            test.Add(6);
            Console.WriteLine(test.Find(5).value == 5 ? "Тест Find1 пройден" : "Тест Find1 не пройден");
        }

        public static void Find2()
        {
            OrderedList<int> test = new OrderedList<int>(false);
            test.Add(1);
            test.Add(5);
            test.Add(2);
            test.Add(10);
            test.Add(-1);
            test.Add(3);
            test.Add(4);
            test.Add(6);
            Console.WriteLine(test.Find(3).value == 3 ? "Тест Find2 пройден" : "Тест Find2 не пройден");
        }

        public static void Find3()
        {
            OrderedList<int> test = new OrderedList<int>(true);
            test.Add(6);
          
            Console.WriteLine(test.Find(3) == null ? "Тест Find3 пройден" : "Тест Find3 не пройден");
        }

        public static void Delete_Duplicates1()
        {
            OrderedList1<int> test = new OrderedList1<int>(true);
            test.Add(1);
            test.Add(1);
            test.Add(1);
            test.Add(1);
            test.Delete_Duplicates(1);
            Console.WriteLine(test.counter == 0 ? "Тест Delete_Duplicates1 пройден" : "Тест Delete_Duplicates1 не пройден");
        }

        public static void Delete_Duplicates2()
        {
            OrderedList1<int> test = new OrderedList1<int>(false);
            test.Add(1);
            test.Add(1);
            test.Add(1);
            test.Add(1);
            test.Delete_Duplicates(1);
            Console.WriteLine(test.counter == 0 ? "Тест Delete_Duplicates2 пройден" : "Тест Delete_Duplicates2 не пройден");
        }

        public static void Delete_Duplicates3()
        {
            OrderedList1<int> test = new OrderedList1<int>(false);
            test.Add(1);
            test.Delete_Duplicates(1);
            Console.WriteLine(test.counter == 0 ? "Тест Delete_Duplicates3 пройден" : "Тест Delete_Duplicates3 не пройден");
        }

        public static void Delete_Duplicates4()
        {
            OrderedList1<int> test = new OrderedList1<int>(false);
            test.Delete_Duplicates(1);
        }

        public static void Merge1()
        {
            OrderedList<int> test1 = new OrderedList<int>(false);
            OrderedList<int> test2 = new OrderedList<int>(false);
            test1.Add(1);
            test1.Add(5);
            test1.Add(2);
            test1.Add(10);
            test1.Add(-1);
            test2.Add(3);
            test2.Add(4);
            test2.Add(6);
            var res = Solution.Merge(test1, test2, false);
            var result = res.GetAll();
            int[] res_arr = new int[result.Count];
            for (int i = 0; i < result.Count; i++) res_arr[i] = result[i].value;
            int[] original = { 10, 6, 5, 4, 3, 2, 1, -1 };
            bool flag = true;
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] != res_arr[i]) flag = false;
            }
            Console.WriteLine(flag ? "Тест Merge1 пройден" : "Тест Merge1 не пройден");
        }

        public static void Merge2()
        {
            OrderedList<int> test1 = new OrderedList<int>(true);
            OrderedList<int> test2 = new OrderedList<int>(true);
            test1.Add(1);
            test1.Add(5);
            test1.Add(2);
            test1.Add(10);
            test1.Add(-1);
            test2.Add(3);
            test2.Add(4);
            test2.Add(6);
            var res = Solution.Merge(test1, test2, true);
            var result = res.GetAll();
            int[] res_arr = new int[result.Count];
            for (int i = 0; i < result.Count; i++) res_arr[i] = result[i].value;
            int[] original = { -1, 1, 2, 3, 4, 5, 6, 10 };
            bool flag = true;
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] != res_arr[i]) flag = false;
            }
            Console.WriteLine(flag ? "Тест Merge2 пройден" : "Тест Merge2 не пройден");
        }

        public static void Merge3()
        {
            OrderedList<int> test1 = new OrderedList<int>(true);
            OrderedList<int> test2 = new OrderedList<int>(true);
            test1.Add(1);
            test1.Add(5);
            test1.Add(2);
            test1.Add(10);
            test1.Add(-1);
            var res = Solution.Merge(test1, test2, true);
            Console.WriteLine(res == null ? "Тест Merge3 пройден" : "Тест Merge3 не пройден");
        }

        public static void Merge4()
        {
            OrderedList<int> test1 = new OrderedList<int>(true);
            OrderedList<int> test2 = null;
            test1.Add(1);
            test1.Add(5);
            test1.Add(2);
            test1.Add(10);
            test1.Add(-1);
            var res = Solution.Merge(test1, test2, true);
            Console.WriteLine(res == null ? "Тест Merge3 пройден" : "Тест Merge3 не пройден");
        }

        public static void Check1()
        {
            OrderedList1<int> test1 = new OrderedList1<int>(true);
            OrderedList<int> test2 = new OrderedList<int>(true);
            test1.Add(1);
            test1.Add(5);
            test1.Add(2);
            test1.Add(10);
            test1.Add(-1);
            test1.Add(3);
            test1.Add(4);
            test1.Add(6);
            test2.Add(3);
            test2.Add(4);
            test2.Add(5);
            test1.Check(test2);
            // test1 = {-1, 1, 2, 3, 4, 5, 6, 10}
            // test2 = {3, 4, 5}
            // Подсписок входит
        }

        public static void Check2()
        {
            OrderedList1<int> test1 = new OrderedList1<int>(true);
            OrderedList<int> test2 = new OrderedList<int>(true);
            test1.Add(1);
            test1.Add(2);
            test1.Add(3);
            test1.Add(4);
            test1.Add(5);
            test2.Add(1);
            test2.Add(2);
            test2.Add(3);
            test1.Check(test2);
            // test1 = {1, 2, 3, 4, 5}
            // test2 = {1, 2, 3}
            // Подсписок входит
        }

        public static void Check3()
        {
            OrderedList1<int> test1 = new OrderedList1<int>(true);
            OrderedList<int> test2 = new OrderedList<int>(true);
            test1.Add(1);
            test1.Add(2);
            test1.Add(3);
            test1.Add(4);
            test1.Add(5);
            test2.Add(1);
            test2.Add(3);
            test2.Add(5);
            test1.Check(test2);
            // test1 = {1, 2, 3, 4, 5}
            // test2 = {1, 3, 5}
            // Не входит
        }

        public static void Check4()
        {
            OrderedList1<int> test1 = new OrderedList1<int>(true);
            OrderedList<int> test2 = new OrderedList<int>(true);
            test1.Add(1);
            test1.Add(2);
            test1.Add(3);
            test1.Add(4);
            test1.Add(5);
            test2.Add(1);
            test2.Add(3);
            test2.Add(5);
            test2.Add(1);
            test2.Add(3);
            test2.Add(5);
            test1.Check(test2);
            // test2 больше чем test1
        }

        public static void Check5()
        {
            OrderedList1<int> test1 = new OrderedList1<int>(false);
            OrderedList<int> test2 = new OrderedList<int>(false);
            test1.Add(1);
            test1.Add(2);
            test1.Add(3);
            test1.Add(4);
            test1.Add(5);
            test2.Add(1);
            test2.Add(2);
            test2.Add(3);
            test1.Check(test2);
            // test1 = {5, 4, 3, 2, 1}
            // test2 = {3, 2, 1}
            // Подсписок входит
        }

        public static void Check6()
        {
            OrderedList1<int> test1 = new OrderedList1<int>(false);
            OrderedList<int> test2 = new OrderedList<int>(false);
            test1.Add(1);
            test1.Add(2);
            test1.Add(3);
            test1.Add(4);
            test1.Add(5);
            test2.Add(1);
            test2.Add(3);
            test2.Add(5);
            test1.Check(test2);
            // test1 = {5, 4, 3, 2, 1}
            // test2 = {5, 3, 1}
            // Не входит
        }

        public static void Frequency1()
        {
            OrderedList1<int> test = new OrderedList1<int>(true);
            test.Add(1);
            test.Add(5);
            test.Add(6);
            test.Add(2);
            test.Add(6);
            test.Add(10);
            test.Add(-1);
            test.Add(3);
            test.Add(4);
            test.Add(6);
            test.Add(6);
            test.Add(6);
            Console.WriteLine(test.Frequency() == 6 ? "Тест Frequency1 пройден" : "Тест Frequency1 не пройден");
        }

        public static void Frequency2()
        {
            OrderedList1<int> test = new OrderedList1<int>(false);
            test.Add(1);
            test.Add(5);
            test.Add(6);
            test.Add(2);
            test.Add(6);
            test.Add(10);
            test.Add(-1);
            test.Add(3);
            test.Add(4);
            test.Add(6);
            test.Add(6);
            test.Add(6);
            test.Add(4);
            test.Add(4);
            test.Add(4);
            test.Add(4);

            Console.WriteLine(test.Frequency() == 6 ? "Тест Frequency2 пройден" : "Тест Frequency2 не пройден");
        }

        public static void Frequency3()
        {
            OrderedList1<int> test = new OrderedList1<int>(true);
            test.Frequency();
        }
        
        public static void Frequency4()
        {
            OrderedList1<int> test = new OrderedList1<int>(true);
            test.Add(1);
            Console.WriteLine(test.Frequency() == 1 ? "Тест Frequency4 пройден" : "Тест Frequency4 не пройден");
        }

        public static void FindIndex1()
        {
            OrderedListIndex<int> test = new OrderedListIndex<int>(true);
            test.Add(1);
            test.Add(5);
            test.Add(6);
            test.Add(2);
            test.Add(6);
            test.Add(10);
            test.Add(-1);
            test.Add(3);
            test.Add(4);
            test.Add(6);
            test.Add(6);
            test.Add(6);
            test.Add(4);
            test.Add(4);
            test.Add(4);
            test.Add(4);
            Console.WriteLine(test.Find_Index(2) == 2 ? "Тест FindIndex1 пройден" : "Тест FindIndex1 не пройден");
        }

        public static void FindIndex2()
        {
            OrderedListIndex<int> test = new OrderedListIndex<int>(false);
            test.Add(1);
            test.Add(5);
            test.Add(6);
            test.Add(2);
            test.Add(6);
            test.Add(10);
            test.Add(-1);
            test.Add(3);
            test.Add(4);
            test.Add(6);
            test.Add(6);
            test.Add(6);
            test.Add(4);
            test.Add(4);
            test.Add(4);
            test.Add(4);
            Console.WriteLine(test.Find_Index(2) == 13 ? "Тест FindIndex2 пройден" : "Тест FindIndex2 не пройден");
        }

        public static void FindIndex3()
        {
            OrderedListIndex<int> test = new OrderedListIndex<int>(false);

            Console.WriteLine(test.Find_Index(1) == null ? "Тест FindIndex3 пройден" : "Тест FindIndex3 не пройден");
        }

        public static void Main(string[] args)
        {
            Add1();
            Add2();
            Add3();
            Delete1();
            Delete2();
            Delete3();
            Delete4();
            Find1();
            Find2();
            Find3();
            Delete_Duplicates1();
            Delete_Duplicates2();
            Delete_Duplicates3();
            Delete_Duplicates4();
            Merge1();
            Merge2();
            Merge3();
            Merge4();
            Check1();
            Check2();
            Check3();
            Check4();
            Check5();
            Check6();
            Frequency1();
            Frequency2();
            Frequency3();
            Frequency4();
            FindIndex1();
            FindIndex2();
            FindIndex3();
        }
    }
}