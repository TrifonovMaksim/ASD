using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AlgorithmsDataStructures2
{
    public class Tests
    {
        public static void EvenTrees()
        {
            SimpleTreeNode<int> testroot = new SimpleTreeNode<int>(1, null);
            SimpleTree<int> test = new SimpleTree<int>(testroot);
            SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(2, null);
            SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(3, null);
            SimpleTreeNode<int> node6 = new SimpleTreeNode<int>(6, null);
            SimpleTreeNode<int> node5 = new SimpleTreeNode<int>(5, null);
            SimpleTreeNode<int> node7 = new SimpleTreeNode<int>(7, null);
            SimpleTreeNode<int> node4 = new SimpleTreeNode<int>(4, null);
            SimpleTreeNode<int> node8 = new SimpleTreeNode<int>(8, null);
            SimpleTreeNode<int> node9 = new SimpleTreeNode<int>(9, null);
            SimpleTreeNode<int> node10 = new SimpleTreeNode<int>(10, null);
            test.AddChild(test.Root, node6);
            test.AddChild(test.Root, node3);
            test.AddChild(test.Root, node2);
            test.AddChild(node6, node8);
            test.AddChild(node8, node10);
            test.AddChild(node8, node9);
            test.AddChild(node3, node4);
            test.AddChild(node2, node7);
            test.AddChild(node2, node5);
            List<int> result = test.EvenTrees();
            Console.WriteLine(result[0] == 1 && result[1] == 6 && result[2] == 1 && result[3] == 3 ? "Тест EvenTrees пройден" : "Тест EvenTrees не пройден");
        }

        public static void DoBalanceTree()
        {
            SimpleTreeNode<int> testroot = new SimpleTreeNode<int>(1, null);
            SimpleTreeAdd<int> test = new SimpleTreeAdd<int>(testroot);
            SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(2, null);
            SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(3, null);
            SimpleTreeNode<int> node6 = new SimpleTreeNode<int>(6, null);
            SimpleTreeNode<int> node5 = new SimpleTreeNode<int>(5, null);
            SimpleTreeNode<int> node7 = new SimpleTreeNode<int>(7, null);
            SimpleTreeNode<int> node4 = new SimpleTreeNode<int>(4, null);
            SimpleTreeNode<int> node8 = new SimpleTreeNode<int>(8, null);
            SimpleTreeNode<int> node9 = new SimpleTreeNode<int>(9, null);
            SimpleTreeNode<int> node10 = new SimpleTreeNode<int>(10, null);
            test.AddChild(test.Root, node6);
            test.AddChild(test.Root, node3);
            test.AddChild(test.Root, node2);
            test.AddChild(node6, node8);
            test.AddChild(node8, node10);
            test.AddChild(node8, node9);
            test.AddChild(node3, node4);
            test.AddChild(node2, node7);
            test.AddChild(node2, node5);
            test.DoBalanceTree();
            Console.WriteLine(test.Root.NodeValue == 5 && test.Root.Children[0].NodeValue == 2 && test.Root.Children[1].NodeValue == 8 ? "Тест DoBalanceTree пройден" : "Тест DoBalanceTree не пройден");
        }

        public static void EvenTreesCount()
        {
            SimpleTreeNode<int> testroot = new SimpleTreeNode<int>(1, null);
            SimpleTreeAdd<int> test = new SimpleTreeAdd<int>(testroot);
            SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(2, null);
            SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(3, null);
            SimpleTreeNode<int> node6 = new SimpleTreeNode<int>(6, null);
            SimpleTreeNode<int> node5 = new SimpleTreeNode<int>(5, null);
            SimpleTreeNode<int> node7 = new SimpleTreeNode<int>(7, null);
            SimpleTreeNode<int> node4 = new SimpleTreeNode<int>(4, null);
            SimpleTreeNode<int> node8 = new SimpleTreeNode<int>(8, null);
            SimpleTreeNode<int> node9 = new SimpleTreeNode<int>(9, null);
            SimpleTreeNode<int> node10 = new SimpleTreeNode<int>(10, null);
            test.AddChild(test.Root, node6);
            test.AddChild(test.Root, node3);
            test.AddChild(test.Root, node2);
            test.AddChild(node6, node8);
            test.AddChild(node8, node10);
            test.AddChild(node8, node9);
            test.AddChild(node3, node4);
            test.AddChild(node2, node7);
            test.AddChild(node2, node5);
            int res = test.EvenTreesCount(test.Root);
            Console.WriteLine(res == 3 ? "Тест EvenTreesCount пройден" : "Тест EvenTreesCount не пройден");
        }
        public static void Main(string[] args)
        {
            EvenTrees();
            DoBalanceTree();
            EvenTreesCount();
        }
    }
}