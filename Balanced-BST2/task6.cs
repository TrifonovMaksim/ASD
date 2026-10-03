using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey;
        public BSTNode Parent; 
        public BSTNode LeftChild; 
        public BSTNode RightChild; 
        public int Level; 

        public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }


    public class BalancedBST
    {
        public BSTNode Root; 

        public BalancedBST()
        {
            Root = null;
        }

        public void GenerateTree(int[] a)
        {
            if (a.Length == 0) return;
            Array.Sort(a);
            Root = DoGenerateTree(a, 0, 0, a.Length - 1, null);
        }

        private BSTNode DoGenerateTree(int[] Array, int level, int Left, int Right, BSTNode Parent)
        {
            if (Left > Right) return null;
            int median = (Left + Right) / 2;
            BSTNode NewNode = new BSTNode(Array[median], Parent) {Level = level};
            NewNode.LeftChild = DoGenerateTree(Array, level + 1, Left, median - 1, NewNode);
            NewNode.RightChild = DoGenerateTree(Array, level + 1, median + 1, Right, NewNode);                                                                                          
            return NewNode;
        }

        //Задание 3. Добавьте метод проверки, действительно ли дерево получилось сбалансированным, что определяется тремя правилами.
        public bool IsBalanced(BSTNode root_node)
        {
            if (root_node == null) return true;
            int LeftHeight = DoIsBalanced(root_node.LeftChild, root_node.Level);
            int RightHeight = DoIsBalanced(root_node.RightChild, root_node.Level);
            if (Math.Abs(LeftHeight - RightHeight) > 1) return false;
            return IsBalanced(root_node.LeftChild) && IsBalanced(root_node.RightChild);
        }

        private int DoIsBalanced(BSTNode Node, int ParentLevel)
        {
            if (Node == null) return ParentLevel;
            int leftMax = DoIsBalanced(Node.LeftChild, Node.Level); 
            int rightMax = DoIsBalanced(Node.RightChild, Node.Level);
            return Math.Max(leftMax, rightMax);
        }

        /*  Спускаемся вниз по каждому узлу и проверяем уровни его левой и правой ветки.
         *  Если разнциа больше 1, значит дерево не сбалансированно.
         *  Сложность по времени O(n^2), спускаемся до листьев с каждого узла.
         *  Сложность по памяти O(1), ничего не создаем.
         */

    }
}