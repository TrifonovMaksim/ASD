using Binary_Simple_Tree;
using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Tests
    {
       public static void FindNodeByKey1()
        {
            BSTAdd<int> test = new BSTAdd<int>(new BSTNode<int>(1, 1, null));
            test.AddKeyValue(2, 2);
            test.AddKeyValue(3, 3);
            Console.WriteLine(test.FindNodeByKey(2).NodeHasKey ? "Тест FindNodeByKey1 пройден" : "Тест FindNodeByKey1 не пройден");
        }

        public static void FindNodeByKey2()
        {
            BSTAdd<int> test = new BSTAdd<int>(new BSTNode<int>(1, 1, null));
            test.AddKeyValue(2, 2);
            BSTFind<int> res = test.FindNodeByKey(0);
            Console.WriteLine(!res.NodeHasKey && res.Node.NodeKey == 1 && res.ToLeft ? "Тест FindNodeByKey2 пройден" : "Тест FindNodeByKey2 не пройден");
        }

        public static void FindNodeByKey3()
        {
            BSTAdd<int> test = new BSTAdd<int>(new BSTNode<int>(1, 1, null));
            test.AddKeyValue(2, 2);
            BSTFind<int> res = test.FindNodeByKey(7);
            Console.WriteLine(!res.NodeHasKey && res.Node.NodeKey == 2 && !res.ToLeft ? "Тест FindNodeByKey3 пройден" : "Тест FindNodeByKey3 не пройден");
        }

        public static void AddKeyValue1()
        {
            BSTAdd<int> test = new BSTAdd<int>(new BSTNode<int>(1, 1, null));
            bool res = test.AddKeyValue(2, 2);
            Console.WriteLine(res && test.FindNodeByKey(2).NodeHasKey ? "Тест AddKeyValue1 пройден" : "Тест AddKeyValue1 не пройден");
        }

        public static void AddKeyValue2()
        {
            BSTAdd<int> test = new BSTAdd<int>(new BSTNode<int>(1, 1, null));
            test.AddKeyValue(2, 2);
            bool res = test.AddKeyValue(2, 22);
            Console.WriteLine(!res && test.Count() == 2 ? "Тест AddKeyValue2 пройден" : "Тест AddKeyValue2 не пройден");
        }

        public static void FinMinMax1()
        {
            BSTAdd<int> test = new BSTAdd<int>(new BSTNode<int>(1, 1, null));
            test.AddKeyValue(2, 2);
            test.AddKeyValue(3, 3);
            Console.WriteLine(test.FinMinMax(test.Root, true).NodeKey == 3 ? "Тест FinMinMax1 пройден" : "Тест FinMinMax1 не пройден");
        }

        public static void FinMinMax2()
        {
            BSTAdd<int> test = new BSTAdd<int>(new BSTNode<int>(1, 1, null));
            test.AddKeyValue(2, 2);
            test.AddKeyValue(3, 3);
            test.AddKeyValue(4, 4);
            BSTNode<int> test1 = test.FindNodeByKey(2).Node;
            Console.WriteLine(test.FinMinMax(test1, true).NodeKey == 4 ? "Тест FinMinMax2 пройден" : "Тест FinMinMax2 не пройден");
        }

        public static void FinMinMax3()
        {
            BSTAdd<int> test = new BSTAdd<int>(new BSTNode<int>(1, 1, null));
            test.AddKeyValue(2, 2);
            test.AddKeyValue(3, 3);
            Console.WriteLine(test.FinMinMax(test.Root, false).NodeKey == 1 ? "Тест FinMinMax1 пройден" : "Тест FinMinMax1 не пройден");
        }

        public static void FinMinMax4()
        {
            BSTAdd<int> test = new BSTAdd<int>(new BSTNode<int>(1, 1, null));
            test.AddKeyValue(2, 2);
            test.AddKeyValue(3, 3);
            test.AddKeyValue(4, 4);
            BSTNode<int> test1 = test.FindNodeByKey(2).Node;
            Console.WriteLine(test.FinMinMax(test1, false).NodeKey == 2 ? "Тест FinMinMax2 пройден" : "Тест FinMinMax2 не пройден");
        }

        public static void DeleteNodeByKey1()
        {
            BSTAdd<int> test = new BSTAdd<int>(new BSTNode<int>(1, 1, null));
            test.AddKeyValue(2, val: 2);
            bool IsHaveChild = test.Root.RightChild.NodeValue == 2;
            Console.WriteLine(test.DeleteNodeByKey(2) && IsHaveChild && !test.FindNodeByKey(2).NodeHasKey ? "Тест DeleteNodeByKey1 пройден" : "Тест DeleteNodeByKey1 не пройден");
        }

        public static void IsTreeEqual1()
        {
            BSTAdd<int> test1 = new BSTAdd<int>(new BSTNode<int>(1, 1, null));
            test1.AddKeyValue(2, 2);
            test1.AddKeyValue(3, 3);
            test1.AddKeyValue(4, 4);
            BSTAdd<int> test2 = new BSTAdd<int>(new BSTNode<int>(1, 1, null));
            test2.AddKeyValue(2, 2);
            test2.AddKeyValue(3, 3);
            test2.AddKeyValue(4, 4);
            Console.WriteLine(test1.IsTreeEqual(test2) ? "Тест IsTreeEqual1 пройден" : "Тест IsTreeEqual1 не пройден");
        }

        public static void WaysWithLength1()
        {
            BSTAdd<int> test = new BSTAdd<int>(new BSTNode<int>(1, 1, null));
            test.AddKeyValue(0, 0);
            test.AddKeyValue(2, 2);
            List<List<BSTNode<int>>> res = test.WaysWithLength(1);
            Console.WriteLine(res != null && res.Count == 2 ? "Тест WaysWithLength1 пройден" : "Тест WaysWithLength1 не пройден");
        }

        public static void WaysWithMaxLength1()
        {
            BSTAdd<int> test = new BSTAdd<int>(new BSTNode<int>(1, 1, null));
            test.AddKeyValue(0, 0);
            test.AddKeyValue(2, 2);
            List<List<BSTNode<int>>> res = test.WaysWithMaxLength();
            Console.WriteLine(res != null && res.Count == 1 && res[0][1].NodeKey == 2 ? "Тест WaysWithMaxLength1 пройден" : "Тест WaysWithMaxLength1 не пройден");
        }

        public static void IsTreeSymetric1()
        {
            BSTAdd<int> test = new BSTAdd<int>(new BSTNode<int>(1, 1, null));
            test.Root.LeftChild = new BSTNode<int>(2, 2, test.Root);
            test.Root.RightChild = new BSTNode<int>(2, 2, test.Root);
            Console.WriteLine(test.IsTreeSymetric() ? "Тест IsTreeSymetric1 пройден" : "Тест IsTreeSymetric1 не пройден");
        }
        public static void Main(string[] args)
        {
            FindNodeByKey1();
            FindNodeByKey2();
            FindNodeByKey3();
            AddKeyValue1();
            AddKeyValue2();
            FinMinMax1();
            FinMinMax2();
            FinMinMax3();
            FinMinMax4();
            DeleteNodeByKey1();
            IsTreeEqual1();
            WaysWithLength1();
            WaysWithMaxLength1();
            IsTreeSymetric1();
        }
    }
}