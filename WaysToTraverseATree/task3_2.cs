using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace AlgorithmsDataStructures2
{
    public class Solution<T> : BST<T>
    {
        public Solution(BSTNode<T> node) : base(node)
        {
        }

        // Задание 3. Реализуйте алгоритм инвертирования дерева: надо сделать так, чтобы слева от главного узла были значения больше него, а справа — меньше.
        public BST<T> InvertTree(BST<T> Tree)
        {
            if (Tree.Root == null) return null;
            Queue<BSTNode<T>> NodesQueue = new Queue<BSTNode<T>>();
            NodesQueue.Enqueue(Tree.Root);
            while (NodesQueue.Count > 0)
            {
                BSTNode<T> Node = NodesQueue.Dequeue();
                BSTNode<T> TempNode = Node.LeftChild;
                Node.LeftChild = Node.RightChild;
                Node.RightChild = TempNode;
                if (Node.LeftChild != null) NodesQueue.Enqueue(Node.LeftChild);
                if (Node.RightChild != null) NodesQueue.Enqueue(Node.RightChild);
            }
            return Tree;
        }
        /* Сделал через обход в ширину, добавляем в очередь детей и меняем их местами.
         * Сложность по времени O(n), проходим по всему дереву.
         * Сложность по памяти O(n), создаем очередь для узлов.
         */

        // Задание 4. Добавьте метод, который находит уровень в текущем дереве, сумма значений узлов на котором максимальна. Подумайте, как оптимизировать решение, чтобы производительность была достаточной даже для больших деревьев.
        public int MaxSumLevel()
        {
            if (Root == null) return default(int);
            int MaxSum = Root.NodeKey;
            int CurrentLevel = 0;
            int MaxLevel = 0;
            Queue<BSTNode<T>> NodesQueue = new Queue<BSTNode<T>>();
            NodesQueue.Enqueue(Root);
            while (NodesQueue.Count > 0)
            {
                int QueueSize = NodesQueue.Count;
                int CurrentSum = 0;
                for (int i = 0; i < QueueSize; i++)
                {
                    BSTNode<T> Node = NodesQueue.Dequeue();
                    CurrentSum += Node.NodeKey;
                    if (Node.LeftChild != null) NodesQueue.Enqueue(Node.LeftChild);
                    if (Node.RightChild != null) NodesQueue.Enqueue(Node.RightChild);
                }
                if (CurrentSum > MaxSum)
                {
                    MaxLevel = CurrentLevel;
                    MaxSum = CurrentSum;
                }
                CurrentLevel++;
            }
            return MaxLevel;
        }
        /* Сделал так-же через обходв в ширину, следим за уровнем и суммой значений.
         * Сложность по времени O(n), проходим по всему дереву.
         * Сложность по памяти O(n), создаем очередь для узлов.
         */


        // Задание 5.Учитывая результаты обхода дерева в префиксном и инфиксном порядке, разработайте функцию для восстановления оригинального дерева.
        public BST<T> RecoveryTree(List<BSTNode<T>> PreOrder, List<BSTNode<T>> InOrder)
        {
            if (PreOrder.Count == 0 || InOrder.Count == 0) return null;
            BST<T> Tree = new BST<T>(null);
            Tree.Root = DoRecoveryTree(PreOrder, InOrder);
            return Tree;

        }
        BSTNode<T> DoRecoveryTree(List<BSTNode<T>> PreOrder, List<BSTNode<T>> InOrder)
        {
            if (PreOrder.Count == 0 || InOrder.Count == 0) return null;
            BSTNode<T> NewRoot = PreOrder[0];
            int InOrderIdx = InOrder.IndexOf(NewRoot);
            List<BSTNode<T>> InOrderLeft = InOrder.GetRange(0, InOrderIdx);
            List<BSTNode<T>> InOrderRight = InOrder.GetRange(InOrderIdx + 1, InOrder.Count - InOrderIdx - 1);
            List<BSTNode<T>> PreOrderLeft = PreOrder.GetRange(1, InOrderLeft.Count);
            List<BSTNode<T>> PreOrderRight = PreOrder.GetRange(InOrderLeft.Count + 1, PreOrder.Count - InOrderLeft.Count - 1);
            NewRoot.LeftChild = DoRecoveryTree(PreOrderLeft, InOrderLeft);
            NewRoot.RightChild = DoRecoveryTree(PreOrderRight, InOrderRight);
            return NewRoot;
        }
        /* Cделал с помощью доп.функции, рекурсивно восстанавливаем сначала левую половину, затем правую.
         * Сложность по времени O(n), рекурсивно спускаемся и поднимаемся по дереву.
         * Сложность по памяти O(n), создаем много промежуточных списков.
         * Нам нужно оба обхода, потому что из префиксного мы точно можем узнать корень, но потом мы не можем точно разделить левую и правую частьь в нем. 
         * А со знанием корня в инфиксном мы можем разделить на левое поддерево и правое.
         */
    }
    
}