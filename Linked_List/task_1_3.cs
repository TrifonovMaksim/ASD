using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace AlgorithmsDataStructures
{
    public class Tests
    {
        static void Remove_1()
        {
            LinkedList test = new LinkedList();
            Console.WriteLine(test.Remove(1) == false ? "Тест Remove_1 пройден" : "Тест Remove_1 не пройден");
        }

        static void Remove_2()
        {
            LinkedList test = new LinkedList();
            test.AddInTail(new Node(1));
            Console.WriteLine(test.Remove(1) == true ? "Тест Remove_2 пройден" : "Тест Remove_2 не пройден");
        }

        static void Remove_3()
        {
            LinkedList test = new LinkedList();
            test.AddInTail(new Node(1));
            test.AddInTail(new Node(2));
            test.AddInTail(new Node(3));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(5));
            test.AddInTail(new Node(6));
            test.AddInTail(new Node(7));

            Console.WriteLine(test.Remove(4) == true ? "Тест Remove_3 пройден" : "Тест Remove_3 не пройден");
        }

        static void Remove_4()
        {
            LinkedList test = new LinkedList();
            test.AddInTail(new Node(1));
            test.AddInTail(new Node(2));
            test.AddInTail(new Node(3));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(5));
            test.AddInTail(new Node(6));
            test.AddInTail(new Node(7));

            Console.WriteLine(test.Remove(10) == false ? "Тест Remove_4 пройден" : "Тест Remove_4 не пройден");
        }

        static void Remove_5()
        {
            LinkedList test = new LinkedList();
            test.AddInTail(new Node(1));
            test.AddInTail(new Node(2));
            test.AddInTail(new Node(3));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(5));
            test.AddInTail(new Node(6));
            test.AddInTail(new Node(7));
            test.AddInTail(new Node(8));
            test.AddInTail(new Node(9));
            test.AddInTail(new Node(11));
            test.AddInTail(new Node(22));
            test.AddInTail(new Node(33));
            test.AddInTail(new Node(44));
            test.AddInTail(new Node(55));
            test.AddInTail(new Node(66));
            test.AddInTail(new Node(77));
            test.AddInTail(new Node(88));
            test.AddInTail(new Node(99));
            test.AddInTail(new Node(12));
            test.AddInTail(new Node(82));
            test.AddInTail(new Node(38));
            test.AddInTail(new Node(84));
            test.AddInTail(new Node(58));
            test.AddInTail(new Node(86));
            test.AddInTail(new Node(78));
            test.AddInTail(new Node(08));
            test.AddInTail(new Node(90));

            Console.WriteLine(test.Remove(4) == true ? "Тест Remove_5 пройден" : "Тест Remove_5 не пройден");
        }


        static void Remove_all1()
        {
            LinkedList test = new LinkedList();
            test.RemoveAll(1);
            Console.WriteLine(test.Count() == 0 ? "Тест Remove_all1 пройден" : "Тест Remove_all1 не пройден");
        }

        static void Remove_all2()
        {
            LinkedList test = new LinkedList();
            test.AddInTail(new Node(1));
            test.RemoveAll(1);
            Console.WriteLine(test.Count() == 0 ? "Тест Remove_all2 пройден" : "Тест Remove_all2 не пройден");
        }

        static void Remove_all3()
        {
            LinkedList test = new LinkedList();
            test.AddInTail(new Node(1));
            test.AddInTail(new Node(2));
            test.AddInTail(new Node(3));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));
            test.RemoveAll(4);

            Console.WriteLine(test.Count() == 3 ? "Тест Remove_all3 пройден" : "Тест Remove_all3 не пройден");
        }

        static void Remove_all4()
        {
            LinkedList test = new LinkedList();
            test.AddInTail(new Node(1));
            test.AddInTail(new Node(2));
            test.AddInTail(new Node(3));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(5));
            test.AddInTail(new Node(6));
            test.AddInTail(new Node(7));
            test.AddInTail(new Node(8));
            test.AddInTail(new Node(9));
            test.AddInTail(new Node(11));
            test.AddInTail(new Node(22));
            test.AddInTail(new Node(33));
            test.AddInTail(new Node(44));
            test.AddInTail(new Node(55));
            test.AddInTail(new Node(66));
            test.AddInTail(new Node(77));
            test.AddInTail(new Node(88));
            test.AddInTail(new Node(99));
            test.AddInTail(new Node(12));
            test.AddInTail(new Node(82));
            test.AddInTail(new Node(38));
            test.AddInTail(new Node(84));
            test.AddInTail(new Node(58));
            test.AddInTail(new Node(86));
            test.AddInTail(new Node(78));
            test.AddInTail(new Node(08));
            test.AddInTail(new Node(90));
            test.RemoveAll(1);

            Console.WriteLine(test.Count() == 26 ? "Тест Remove_all4 пройден" : "Тест Remove_all4 не пройден");
        }

        
        static void Clear1()
        {
            LinkedList test = new LinkedList();
            test.Clear();
            Console.WriteLine(test.Count() == 0 ? "Тест Clear1 пройден" : "Тест Clear1 не пройден");
        }

        static void Clear2()
        {
            LinkedList test = new LinkedList();
            test.AddInTail(new Node(1));
            test.Clear();
            Console.WriteLine(test.Count() == 0 ? "Тест Clear2 пройден" : "Тест Clear2 не пройден");
        }

        static void Clear3()
        {
            LinkedList test = new LinkedList();
            test.AddInTail(new Node(1));
            test.AddInTail(new Node(2));
            test.AddInTail(new Node(3));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(5));
            test.AddInTail(new Node(6));
            test.AddInTail(new Node(7));
            test.AddInTail(new Node(8));
            test.AddInTail(new Node(9));
            test.AddInTail(new Node(11));
            test.AddInTail(new Node(22));
            test.AddInTail(new Node(33));
            test.AddInTail(new Node(44));
            test.AddInTail(new Node(55));
            test.AddInTail(new Node(66));
            test.AddInTail(new Node(77));
            test.AddInTail(new Node(88));
            test.AddInTail(new Node(99));
            test.AddInTail(new Node(12));
            test.AddInTail(new Node(82));
            test.AddInTail(new Node(38));
            test.AddInTail(new Node(84));
            test.AddInTail(new Node(58));
            test.AddInTail(new Node(86));
            test.AddInTail(new Node(78));
            test.AddInTail(new Node(08));
            test.AddInTail(new Node(90));
            test.Clear();

            Console.WriteLine(test.Count() == 0 ? "Тест Clear3 пройден" : "Тест Clear3 не пройден");
        }

        static void FindAll_1()
        {
            LinkedList test = new LinkedList();
            Console.WriteLine(test.FindAll(1).Count == 0 ? "Тест FindAll_1 пройден" : "Тест FindAll_1 не пройден");
        }

        static void FindAll_2()
        {
            LinkedList test = new LinkedList();
            test.AddInTail(new Node(1));
            Console.WriteLine(test.FindAll(1).Count == 1 ? "Тест FindAll_2 пройден" : "Тест FindAll_2 не пройден");
        }

        static void FindAll_3()
        {
            LinkedList test = new LinkedList();
            test.AddInTail(new Node(1));
            test.AddInTail(new Node(2));
            test.AddInTail(new Node(3));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(5));
            test.AddInTail(new Node(6));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(7));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));

            Console.WriteLine(test.FindAll(4).Count == 8 ? "Тест FindAll_3 пройден" : "Тест FindAll_3 не пройден");
        }

        static void Count_1()
        {
            LinkedList test = new LinkedList();
            Console.WriteLine(test.Count() == 0 ? "Тест Count_1 пройден" : "Тест Count_1 не пройден");
        }

        static void Count_2()
        {
            LinkedList test = new LinkedList();
            test.AddInTail(new Node(1));
            Console.WriteLine(test.Count() == 1 ? "Тест Count_2 пройден" : "Тест Count_2 не пройден");
        }

        static void Count_3()
        {
            LinkedList test = new LinkedList();
            test.AddInTail(new Node(1));
            test.AddInTail(new Node(1));
            test.AddInTail(new Node(2));
            test.AddInTail(new Node(3));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(5));
            test.AddInTail(new Node(6));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(7));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));
            Console.WriteLine(test.Count() == 15 ? "Тест Count_3 пройден" : "Тест Count_3 не пройден");
        }

        static void Insert_After_1()
        {
            LinkedList test = new LinkedList();
            test.InsertAfter(new Node(1), new Node(2));
            Console.WriteLine(test.Count() == 0 ? "Тест Insert_After_1 пройден" : "Тест Insert_After_1 не пройден");
        }

        static void Insert_After_2()
        {
            LinkedList test = new LinkedList();
            Node node = new Node(1);
            test.AddInTail(node);
            test.InsertAfter(node, new Node(2));
            Console.WriteLine(test.Count() == 2 ? "Тест Insert_After_2 пройден" : "Тест Insert_After_2 не пройден");
        }

        static void Insert_After_3()
        {
            LinkedList test = new LinkedList();
            Node node = new Node(1);
            test.AddInTail(node);
            test.AddInTail(new Node(1));
            test.AddInTail(new Node(2));
            test.AddInTail(new Node(3));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(5));
            test.AddInTail(new Node(6));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(7));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(4));
            test.InsertAfter(node, new Node(21));
            Console.WriteLine(test.Count() == 16 ? "Тест Insert_After_3 пройден" : "Тест Insert_After_3 не пройден");
        }

        static void ListSum1()
        {
            LinkedList test1 = new LinkedList();
            LinkedList test2 = new LinkedList();
            Console.WriteLine(Solution.LinkedListsSum(test1, test2).Count() == 0  ? "Тест ListSum1 пройден" : "Тест ListSum1 не пройден");
        }
        static void ListSum2()
        {
            LinkedList test1 = new LinkedList();
            LinkedList test2 = new LinkedList();
            test1.AddInTail(new Node(1));
            test2.AddInTail(new Node(1));
            Console.WriteLine(Solution.LinkedListsSum(test1, test2).Count() == 1 ? "Тест ListSum2 пройден" : "Тест ListSum2 не пройден");
        }

        static void ListSum3()
        {
            LinkedList test1 = new LinkedList();
            LinkedList test2 = new LinkedList();
            test1.AddInTail(new Node(1));
            Console.WriteLine(Solution.LinkedListsSum(test1, test2).Count() == 0 ? "Тест ListSum3 пройден" : "Тест ListSum3 не пройден");
        }

        static void ListSum4()
        {
            LinkedList test1 = new LinkedList();
            LinkedList test2 = new LinkedList();
            test1.AddInTail(new Node(1));
            test1.AddInTail(new Node(1));
            test1.AddInTail(new Node(2));
            test1.AddInTail(new Node(3));
            test1.AddInTail(new Node(4));
            test1.AddInTail(new Node(5));
            test1.AddInTail(new Node(6));
            test1.AddInTail(new Node(4));
            test1.AddInTail(new Node(7));
            test1.AddInTail(new Node(4));
            test1.AddInTail(new Node(4));
            test1.AddInTail(new Node(4));
            test1.AddInTail(new Node(4));
            test1.AddInTail(new Node(4));
            test1.AddInTail(new Node(4));
            test2.AddInTail(new Node(1));
            test2.AddInTail(new Node(1));
            test2.AddInTail(new Node(2));
            test2.AddInTail(new Node(3));
            test2.AddInTail(new Node(4));
            test2.AddInTail(new Node(5));
            test2.AddInTail(new Node(6));
            test2.AddInTail(new Node(4));
            test2.AddInTail(new Node(7));
            test2.AddInTail(new Node(4));
            test2.AddInTail(new Node(4));
            test2.AddInTail(new Node(4));
            test2.AddInTail(new Node(4));
            test2.AddInTail(new Node(4));
            test2.AddInTail(new Node(4));
            Console.WriteLine(Solution.LinkedListsSum(test1, test2).Count() == 15 ? "Тест ListSum4 пройден" : "Тест ListSum4 не пройден");
        }

    static void Main(string[] args)
        {
            Remove_1();
            Remove_2();
            Remove_3();
            Remove_4();
            Remove_5();
            Remove_all1();
            Remove_all2();
            Remove_all3();
            Remove_all4();
            Clear1();
            Clear2();
            Clear3();
            FindAll_1();
            FindAll_2();
            FindAll_3();
            Count_1();
            Count_2();
            Count_3();
            Insert_After_1();
            Insert_After_2();
            Insert_After_3();
            ListSum1();
            ListSum2();
            ListSum3();
            ListSum4();
        }
    }
}
