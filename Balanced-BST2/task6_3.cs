using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AlgorithmsDataStructures2
{
    public class Tests
    {
        public static void GenerateTree1()
        {
            int[] arr = new int[] {1, 4, 8, 2, 0, 9, 5};
            BalancedBST test = new BalancedBST();
            test.GenerateTree(arr);
            Console.WriteLine(test.Root != null && test.Root.NodeKey == 4 && test.Root.LeftChild.NodeKey == 1 && test.Root.RightChild.NodeKey == 8 ? "Тест GenerateTree1 пройден" : "Тест GenerateTree1 не пройден");
        }

        public static void IsBalanced1()
        {
            int[] arr = new int[] {1, 4, 8, 2, 0, 9, 5};
            BalancedBST test = new BalancedBST();
            test.GenerateTree(arr);
            Console.WriteLine(test.IsBalanced(test.Root) ? "Тест IsBalanced1 пройден" : "Тест IsBalanced1 не пройден");
        }

        public static void IsBalanced2()
        {
            BalancedBST test = new BalancedBST();
            test.Root = new BSTNode(1, null) {Level = 0};
            test.Root.RightChild = new BSTNode(2, test.Root) {Level = 1};
            test.Root.RightChild.RightChild = new BSTNode(3, test.Root.RightChild) {Level = 2};
            Console.WriteLine(!test.IsBalanced(test.Root) ? "Тест IsBalanced2 пройден" : "Тест IsBalanced2 не пройден");
        }

        public static void IsTreeRight1()
        {
            int[] arr = new int[] {1, 4, 8, 2, 0, 9, 5};
            BalancedBSTAdd test = new BalancedBSTAdd();
            test.GenerateTree(arr);
            Console.WriteLine(test.IsTreeRight() ? "Тест IsTreeRight1 пройден" : "Тест IsTreeRight1 не пройден");
        }

        public static void IsTreeRight2()
        {
            BalancedBSTAdd test = new BalancedBSTAdd();
            test.Root = new BSTNode(10, null) {Level = 0};
            test.Root.LeftChild = new BSTNode(5, test.Root) {Level = 1};
            test.Root.RightChild = new BSTNode(15, test.Root) {Level = 1};
            test.Root.RightChild.LeftChild = new BSTNode(6, test.Root.RightChild) {Level = 2};
            Console.WriteLine(!test.IsTreeRight() ? "Тест IsTreeRight2 пройден" : "Тест IsTreeRight2 не пройден");
        }

        public static void Main(string[] args)
        {
            GenerateTree1();
            IsBalanced1();
            IsBalanced2();
            IsTreeRight1();
            IsTreeRight2();
        }
    }
}