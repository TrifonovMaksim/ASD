using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Tests
    {
        static void Test_Insert1()
        {
            DynArray<int> test = new DynArray<int>();
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            int capacity_prev = test.capacity;
            test.Insert(10, 1);
            Console.WriteLine(capacity_prev == test.capacity? "Тест Test_Insert1 пройден" : "Тест Test_Insert1 не пройден");
        }

        static void Test_Insert2()
        {
            DynArray<int> test = new DynArray<int>();
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            int capacity_prev = test.capacity;
            test.Insert(10, 1);
            Console.WriteLine(capacity_prev != test.capacity ? "Тест Test_Insert2 пройден" : "Тест Test_Insert2 не пройден");
        }

        static void Test_Insert3()
        {
            DynArray<int> test = new DynArray<int>();
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            try
            {
                test.Insert(1, -10);
                Console.WriteLine("Тест Test_Insert3 не пройден");
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Тест Test_Insert3 пройден");
            }
        }

        static void Test_Remove1()
        {
            DynArray<int> test = new DynArray<int>();
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            int capacity_prev = test.capacity;
            test.Remove(1);
            Console.WriteLine(capacity_prev == test.capacity ? "Тест Test_Remove1 пройден" : "Тест Test_Remove1 не пройден");
        }

        static void Test_Remove2()
        {
            DynArray<int> test = new DynArray<int>();
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            test.Remove(1);
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            int capacity_prev = test.capacity;
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            Console.WriteLine(capacity_prev != test.capacity ? "Тест Test_Remove2 пройден" : "Тест Test_Remove2 не пройден");
        }
        static void Test_Removet3()
        {
            DynArray<int> test = new DynArray<int>();
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            try
            {
                test.Remove(-1);
                Console.WriteLine("Тест Test_Removet3 не пройден");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Тест Test_Removet3 пройден");
            }
        }

        static void Bank_Test_Insert1()
        {
            BankDynArray<int> test = new BankDynArray<int>();
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            int capacity_prev = test.capacity;
            test.Insert(10, 1);
            Console.WriteLine(capacity_prev == test.capacity ? "Тест Bank_Test_Insert1 пройден" : "Тест Bank_Test_Insert1 не пройден");
        }

        static void Bank_Test_Insert2()
        {
            BankDynArray<int> test = new BankDynArray<int>();
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            int capacity_prev = test.capacity;
            test.Insert(10, 1);
            Console.WriteLine(capacity_prev != test.capacity ? "Тест Bank_Test_Insert2 пройден" : "Тест Bank_Test_Insert2 не пройден");
        }

        static void Bank_Test_Insert3()
        {
            BankDynArray<int> test = new BankDynArray<int>();
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            try
            {
                test.Insert(1, -10);
                Console.WriteLine("Тест Bank_Test_Insert3 не пройден");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Тест Bank_Test_Insert3 пройден");
            }
        }

        static void Bank_Test_Remove1()
        {
            BankDynArray<int> test = new BankDynArray<int>();
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            int capacity_prev = test.capacity;
            test.Remove(1);
            Console.WriteLine(capacity_prev == test.capacity ? "Тест Bank_Test_Remove1 пройден" : "Тест Bank_Test_Remove1 не пройден");
        }

        static void Bank_Test_Remove2()
        {
            BankDynArray<int> test = new BankDynArray<int>();
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            test.Remove(1);
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            int capacity_prev = test.capacity;
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            test.Remove(1);
            Console.WriteLine(capacity_prev != test.capacity ? "Тест Bank_Test_Remove2 пройден" : "Тест Bank_Test_Remove2 не пройден");
        }
        static void Bank_Test_Removet3()
        {
            BankDynArray<int> test = new BankDynArray<int>();
            test.Append(1);
            test.Append(2);
            test.Append(3);
            test.Append(4);
            test.Append(5);
            try
            {
                test.Remove(-1);
                Console.WriteLine("Тест Bank_Test_Removet3 не пройден");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Тест Bank_Test_Removet3 пройден");
            }
        }
        static void Multi_Test_GetItem1()
        {
            MultiDynArray<int> test = new MultiDynArray<int>(3, 3);
            test.Append(10, new int[]{0});
            test.Append(20, new int[]{0});
            Console.WriteLine(test.GetItem(new int[]{0}, 1) == 20 ? "Тест Multi_Test_GetItem1 пройден" : "Тест Multi_Test_GetItem1 не пройден");
        }

        static void Multi_Test_GetItem2()
        {
            MultiDynArray<int> test = new MultiDynArray<int>(3, 3);
            try
            {
                test.GetItem(new int[]{0}, 10);
                Console.WriteLine("Тест Multi_Test_GetItem2 не пройден");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Тест Multi_Test_GetItem2 пройден");
            }
        }

        static void Multi_Test_Insert1()
        {
            MultiDynArray<int> test = new MultiDynArray<int>(3, 3);
            test.Append(1, new int[]{0});
            test.Append(2, new int[]{0});
            test.Insert(99, new int[]{0}, 1);
            Console.WriteLine(test.GetItem(new int[]{0}, 1) == 99 ? "Тест Multi_Test_Insert1 пройден" : "Тест Multi_Test_Insert1 не пройден");
        }

        static void Multi_Test_Insert2()
        {
            MultiDynArray<int> test = new MultiDynArray<int>(3, 3);
            test.Append(1, new int[]{0});
            try
            {
                test.Insert(1, new int[]{0}, -10);
                Console.WriteLine("Тест Multi_Test_Insert2 не пройден");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Тест Multi_Test_Insert2 пройден");
            }
        }

        static void Multi_Test_Remove1()
        {
            MultiDynArray<int> test = new MultiDynArray<int>(3, 3);
            test.Append(1, new int[]{0});
            test.Append(2, new int[]{0});
            test.Append(3, new int[]{0});
            test.Remove(new int[]{0}, 1);
            Console.WriteLine(test.GetItem(new int[]{0}, 1) == 3 ? "Тест Multi_Test_Remove1 пройден" : "Тест Multi_Test_Remove1 не пройден");
        }

        static void Multi_Test_Remove2()
        {
            MultiDynArray<int> test = new MultiDynArray<int>(3, 3);
            test.Append(1, new int[]{0});
            try
            {
                test.Remove(new int[]{0}, -1);
                Console.WriteLine("Тест Multi_Test_Remove2 не пройден");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Тест Multi_Test_Remove2 пройден");
            }
        }
        static void Main(string[] args)
        {
            Test_Insert1();
            Test_Insert2();
            Test_Insert3();
            Test_Remove1();
            Test_Remove2();
            Test_Removet3();
            Bank_Test_Insert1();
            Bank_Test_Insert2();
            Bank_Test_Insert3();
            Bank_Test_Remove1();
            Bank_Test_Remove2();
            Bank_Test_Removet3();
            Multi_Test_GetItem1();
            Multi_Test_GetItem2();
            Multi_Test_Insert1();
            Multi_Test_Insert2();
            Multi_Test_Remove1();
            Multi_Test_Remove2();
        }
    }
}
