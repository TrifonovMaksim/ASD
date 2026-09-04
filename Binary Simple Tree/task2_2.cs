using AlgorithmsDataStructures2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Simple_Tree
{
    public class BSTAdd<T> : BST<T> 
    {
        public BSTAdd(BSTNode<T> node) : base(node)
        {
        }

        // Задание 1. Добавьте метод, проверяющий, идентично ли текущее дерево дереву-параметру.
        public bool IsTreeEqual(BST<T> ParamTree)
        {
            if (ParamTree == null) return false;
            if (Count() != ParamTree.Count()) return false;
            return DoIsTreeEqual(Root, ParamTree.Root);
        }

        public bool DoIsTreeEqual(BSTNode<T> node1, BSTNode<T> node2)
        {
            if (node1 == null && node2 == null) return true;
            if (node1 == null || node2 == null) return false;
            if (node1.NodeKey != node2.NodeKey) return false;
            if (!node1.NodeValue.Equals(node2.NodeValue)) return false;
            return DoIsTreeEqual(node1.LeftChild, node2.LeftChild) && DoIsTreeEqual(node1.RightChild, node2.RightChild);
        }
        /* 
         * Сделал через два метода, основной - интерфейс и вспомогательный. Идем по двум деревьям одновременно и сравниваем узлы.
         * Если есть несовпадение с условиями, то сразу возвращаем false. Когда рекурсия доходит до листьев, значит деревья равны.
         * Сложность по времени O(n) проходим по всему дереву.
         * Сложность по памяти O(1) ничего не создаем.
         */


        // Задание 2. Добавьте метод, который нахождит все пути от корня к листьям, длина которых равна заданной величине.
        public List<List<BSTNode<T>>> WaysWithLength(int length)
        {
            if (Root == null) return null;
            List<List<BSTNode<T>>> ResultList = new List<List<BSTNode<T>>>();
            List<BSTNode<T>> Path = new List<BSTNode<T>>();
            DoWaysWithLength(Root, length, ResultList, Path);
            return ResultList;
        }

        public void DoWaysWithLength(BSTNode<T> Node, int length, List<List<BSTNode<T>>> ResultList, List<BSTNode<T>> Path)
        {
            if (Node == null) return;
            Path.Add(Node);
            if (Node.LeftChild == null && Node.RightChild == null)
            {
                if(Path.Count  -1 == length) ResultList.Add(new List<BSTNode<T>>(Path));
            }
            DoWaysWithLength(Node.LeftChild, length, ResultList, Path);
            DoWaysWithLength(Node.RightChild, length, ResultList, Path);
            Path.RemoveAt(Path.Count - 1);
        }

        /* 
         * Рекурсивно идем по каждой ветке и сравниваем ее длину с заданной.
         * Сложность по времени O(n) проходим по всему дереву.
         * Сложность по памяти O(2n) Создаем список для узлов пути и список списков путей.
         */

        // Задание 3. Добавьте метод, который находит все пути от корня к листьям, чтобы сумма значений узлов на этом пути была максимальной.
        public List<List<BSTNode<T>>> WaysWithMaxLength()
        {
            if (Root == null) return null;
            List<List<BSTNode<T>>> ResultList = new List<List<BSTNode<T>>>();
            List<BSTNode<T>> Path = new List<BSTNode<T>>();
            int MaxSumOfValues = default(int);
            DoWaysWithMaxLength(Root, ref MaxSumOfValues, ResultList, Path);
            return ResultList;
        }

        public void DoWaysWithMaxLength(BSTNode<T> Node, ref int MaxSumOfValues, List<List<BSTNode<T>>> ResultList, List<BSTNode<T>> Path)
        {
            if (Node == null) return;
            Path.Add(Node);
            if (Node.LeftChild == null && Node.RightChild == null)
            {
                int PathSumOfValues = SumOfValues(Path);
                if (PathSumOfValues > MaxSumOfValues)
                {
                    MaxSumOfValues = SumOfValues(Path);
                    ResultList.Clear();
                    ResultList.Add(new List<BSTNode<T>>(Path));
                }
                else if (PathSumOfValues == MaxSumOfValues) ResultList.Add(new List<BSTNode<T>>(Path));
            }
            DoWaysWithMaxLength(Node.LeftChild, ref MaxSumOfValues, ResultList, Path);
            DoWaysWithMaxLength(Node.RightChild, ref MaxSumOfValues, ResultList, Path);
            Path.RemoveAt(Path.Count - 1);
        }

        private int SumOfValues(List<BSTNode<T>> Path)
        {
            int ResultSumOfValues = 0;
            foreach (BSTNode<T> Node in Path)
            {
                ResultSumOfValues += Node.NodeKey;
            }
            return ResultSumOfValues;
        }
        /* 
         * Рекурсивно идем по каждой ветке и сравниваем ее длину с максимальной, если длина больше, обновляем максимум и удаляем предыдущие пути.
         * Сложность по времени O(n) проходим по всему дереву.
         * Сложность по памяти O(2n) Создаем список для узлов пути и список списков путей.
         */

        // Задание 4. Добавьте метод проверки, симметрично ли дерево относительно своего корня.

        public bool IsTreeSymetric()
        {
            if (Root == null) return true;
            return DoIsTreeSymetric(Root.LeftChild, Root.RightChild);
        }

        public bool DoIsTreeSymetric(BSTNode<T> LeftNode, BSTNode<T> RightNode)
        {
            if (LeftNode == null && RightNode == null) return true;
            if (LeftNode == null || RightNode == null) return false;
            if (!LeftNode.NodeValue.Equals(RightNode.NodeValue) || LeftNode.NodeKey != RightNode.NodeKey) return false;
            return DoIsTreeSymetric(LeftNode.LeftChild, RightNode.RightChild) && DoIsTreeSymetric(LeftNode.RightChild, RightNode.LeftChild);
        }
        /* 
        * Идем по двум половинам дерева одновременно, сравниваем значения узлов, если узлы не равны по какому то из признаков сразу выдаем false.
        * Если доходим до листьев, значит дерево симметрично.
        * Сложность по времени O(n) проходим по всему дереву.
        * Сложность по памяти O(1) Создаем список для узлов пути и список списков путей.
        */
    }
}
