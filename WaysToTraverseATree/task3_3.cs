using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace AlgorithmsDataStructures2
{
    public class Tests
    {

        public static void WideAllNodes1()
        {
            BST<int> test = new BST<int>(new BSTNode<int>(4, 4, null));
            test.AddKeyValue(2, 2);
            test.AddKeyValue(3, 3);
            test.AddKeyValue(5, 5);
            test.AddKeyValue(6, 6);
            List<BSTNode<int>> res = test.WideAllNodes();
            Console.WriteLine(res != null && res.Count == 5 && res[1].NodeKey == 2 && res[4].NodeKey == 6 ? "Тест WideAllNodes1 пройден" : "Тест WideAllNodes1 не пройден");
        }



        public static void DeepAllNodes1()
        {
            BST<int> test = new BST<int>(new BSTNode<int>(4, 4, null));
            test.AddKeyValue(2, 2);
            test.AddKeyValue(3, 3);
            test.AddKeyValue(5, 5);
            test.AddKeyValue(6, 6);
            List<BSTNode<int>> testinorder = test.DeepAllNodes(0);
            List<BSTNode<int>> testpostorder = test.DeepAllNodes(1);
            List<BSTNode<int>> testpreorder = test.DeepAllNodes(2);
            Console.WriteLine(testinorder != null && testinorder[0].NodeKey == 2 && testpostorder[0].NodeKey == 3 && testpreorder[0].NodeKey == 4 ? "Тест DeepAllNodes1 пройден" : "Тест DeepAllNodes1 не пройден");
        }


        public static void InvertTree1()
        {
            Solution<int> test = new Solution<int>(new BSTNode<int>(4, 4, null));
            test.AddKeyValue(2, 2);
            test.AddKeyValue(3, 3);
            test.AddKeyValue(5, 5);
            test.AddKeyValue(6, 6);
            test.InvertTree(test);
            Console.WriteLine(test.Root.LeftChild.NodeKey == 5 && test.Root.RightChild.NodeKey == 2 ? "Тест InvertTree1 пройден" : "Тест InvertTree1 не пройден");
        }

        public static void MaxSumLevel1()
        {
            Solution<int> test = new Solution<int>(new BSTNode<int>(4, 4, null));
            test.AddKeyValue(2, 2);
            test.AddKeyValue(3, 3);
            test.AddKeyValue(5, 5);
            test.AddKeyValue(6, 6);
            Console.WriteLine(test.MaxSumLevel() == 2 ? "Тест MaxSumLevel1 пройден" : "Тест MaxSumLevel1 не пройден");
        }


        public static void RecoveryTree1()
        {
            Solution<int> test = new Solution<int>(new BSTNode<int>(4, 4, null));
            test.AddKeyValue(2, 2);
            test.AddKeyValue(3, 3);
            test.AddKeyValue(5, 5);
            test.AddKeyValue(6, 6);
            List<BSTNode<int>> preOrder = test.DeepAllNodes(2);
            List<BSTNode<int>> inOrder = test.DeepAllNodes(0);
            BST<int> res = test.RecoveryTree(preOrder, inOrder);
            Console.WriteLine(res.Root.NodeKey == 4 && res.Root.LeftChild.NodeKey == 2 && res.Root.RightChild.NodeKey == 5 ? "Тест RecoveryTree1 пройден" : "Тест RecoveryTree1 не пройден");
        }

        public static void Main(string[] args)
        {
            WideAllNodes1();
            DeepAllNodes1();
            InvertTree1();
            MaxSumLevel1();
            RecoveryTree1();
        }
    }
}