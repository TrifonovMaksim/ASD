using aAlgorithmsDataStructures;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace AlgorithmsDataStructures
{
    public class Tests
    {
        static void Find_1()
        {
            LinkedList2 test = new LinkedList2();
            Console.WriteLine(test.Find(1) == null ? "Тест Find_1 пройден" : "Тест Find_1 не пройден");
        }

        static void Find_2()
        {
            LinkedList2 test = new LinkedList2();
            Node node = new Node(1);
            test.AddInTail(node);

            Console.WriteLine(test.Find(1) == node ? "Тест Find_2 пройден" : "Тест Find_2 не пройден");
        }

        static void Find_3()
        {
            LinkedList2 test = new LinkedList2();
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
            Node node = new Node(32);

            Console.WriteLine(test.Find(32) == node ? "Тест Find_3 пройден" : "Тест Find_3 не пройден");
        }

        static void FindAll_1()
        {
            LinkedList2 test = new LinkedList2();
            Console.WriteLine(test.FindAll(1).Count == 0 ? "Тест FindAll_1 пройден" : "Тест FindAll_1 не пройден");
        }

        static void FindAll_2()
        {
            LinkedList2 test = new LinkedList2();
            test.AddInTail(new Node(1));
            Console.WriteLine(test.FindAll(1).Count == 1 ? "Тест FindAll_2 пройден" : "Тест FindAll_2 не пройден");
        }

        static void FindAll_3()
        {
            LinkedList2 test = new LinkedList2();
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

        static void Remove_1()
        {
            LinkedList2 test = new LinkedList2();
            Console.WriteLine(test.Remove(1) == false ? "Тест Remove_1 пройден" : "Тест Remove_1 не пройден");
        }

        static void Remove_2()
        {
            LinkedList2 test = new LinkedList2();
            test.AddInTail(new Node(1));
            Console.WriteLine(test.Remove(1) == true ? "Тест Remove_2 пройден" : "Тест Remove_2 не пройден");
        }

        static void Remove_3()
        {
            LinkedList2 test = new LinkedList2();
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
            LinkedList2 test = new LinkedList2();
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
            LinkedList2 test = new LinkedList2();
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
            LinkedList2 test = new LinkedList2();
            test.RemoveAll(1);
            Console.WriteLine(test.Count() == 0 ? "Тест Remove_all1 пройден" : "Тест Remove_all1 не пройден");
        }

        static void Remove_all2()
        {
            LinkedList2 test = new LinkedList2();
            test.AddInTail(new Node(1));
            test.RemoveAll(1);
            Console.WriteLine(test.Count() == 0 ? "Тест Remove_all2 пройден" : "Тест Remove_all2 не пройден");
        }

        static void Remove_all3()
        {
            LinkedList2 test = new LinkedList2();
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
            LinkedList2 test = new LinkedList2();
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

        static void Insert_After_1()
        {
            LinkedList2 test = new LinkedList2();
            test.InsertAfter(new Node(1), new Node(2));
            Console.WriteLine(test.Count() == 0 ? "Тест Insert_After_1 пройден" : "Тест Insert_After_1 не пройден");
        }

        static void Insert_After_2()
        {
            LinkedList2 test = new LinkedList2();
            Node node = new Node(1);
            test.AddInTail(node);
            test.InsertAfter(node, new Node(2));
            Console.WriteLine(test.Count() == 2 ? "Тест Insert_After_2 пройден" : "Тест Insert_After_2 не пройден");
        }

        static void Insert_After_3()
        {
            LinkedList2 test = new LinkedList2();
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
            Console.WriteLine(test.head.next.value == 21 ? "Тест Insert_After_3 пройден" : "Тест Insert_After_3 не пройден");
        }

        static void InsertFirst_1()
        {
            LinkedList2 test = new LinkedList2();
            Node node = new Node(1);
            test.AddInTail(node);
            test.AddInTail(new Node(21));
            Node test_node = new Node(22);
            test.InsertFirst(test_node);
            Console.WriteLine(test.head.value == 22 ? "Тест InsertFirst_1 пройден" : "Тест InsertFirst_1 не пройден");
        }

        static void InsertFirst_2()
        {
            LinkedList2 test = new LinkedList2();
            Node test_node = new Node(22);
            test.InsertFirst(test_node);
            Console.WriteLine(test.head.value == 22 ? "Тест InsertFirst_2 пройден" : "Тест InsertFirst_2 не пройден");
        }

        static void Clear_1()
        {
            LinkedList2 test = new LinkedList2();
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
            test.Clear();
            Console.WriteLine(test.head == null ? "Тест Clear_1 пройден" : "Тест Clear_1 не пройден");
        }

        static void Clear_2()
        {
            LinkedList2 test = new LinkedList2();
            test.Clear();
            Console.WriteLine(test.head == null ? "Тест Clear_2 пройден" : "Тест Clear_2 не пройден");

        }

        static void Reverse()
        {
            LinkedList2 test = new LinkedList2();
            test.AddInTail(new Node(1));
            test.AddInTail(new Node(2));
            test.AddInTail(new Node(3));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(5));
            test.Reverse();
            Console.WriteLine(test.head.value == 5 && test.tail.value == 1 ? "Тест Reverse пройден" : "Тест Reverse не пройден");
        }

            static void IsCycled_1()
        {
            LinkedList2 test = new LinkedList2();
            test.AddInTail(new Node(1));
            test.AddInTail(new Node(2));
            test.AddInTail(new Node(3));
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(5));
            Console.WriteLine(test.IsCycled() == false ? "Тест IsCycled_1 пройден" : "Тест IsCycled_1 не пройден");
        }

        static void IsCycled_2()
        {
            LinkedList2 test = new LinkedList2();
            Console.WriteLine(test.IsCycled() == false ? "Тест IsCycled_1 пройден" : "Тест IsCycled_1 не пройден");
        }



        static void Sort()
        {
            LinkedList2 test = new LinkedList2();
            test.AddInTail(new Node(4));
            test.AddInTail(new Node(3));
            test.AddInTail(new Node(2));
            test.AddInTail(new Node(5));
            test.AddInTail(new Node(1));
            test.Sort();
            Console.WriteLine(test.head.value == 1 && test.tail.value == 5 ? "Тест Sort_1 пройден" : "Тест Sort_1 не пройден");
        }

        static void CompareTwoLists()
        {
            LinkedList2 list1 = new LinkedList2();
            LinkedList2 list2 = new LinkedList2();
            list1.AddInTail(new Node(3));
            list1.AddInTail(new Node(1));
            list2.AddInTail(new Node(4));
            list2.AddInTail(new Node(2));
            LinkedList2 test = list1.CompareTwoLists(list1, list2);
            Console.WriteLine(test.head.value == 1 && test.tail.value == 4 ? "Тест CompareTwoLists_1 пройден" : "Тест CompareTwoLists_1 не пройден");
        }

        static void Main(string[] args)
        {
            Find_1();
            Find_2();
            Find_3();
            FindAll_1();
            FindAll_2();
            FindAll_3();
            Remove_1();
            Remove_2();
            Remove_3();
            Remove_4();
            Remove_5();
            Remove_all1();
            Remove_all2();
            Remove_all3();
            Remove_all4();
            Insert_After_1();
            Insert_After_2();
            Insert_After_3();
            InsertFirst_1();
            InsertFirst_2();
            Clear_1();
            Clear_2();
            Reverse();
            IsCycled_1();
            IsCycled_2();
            Sort();
            CompareTwoLists();
        }
    }
}