using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey; 
        public T NodeValue; 
        public BSTNode<T> Parent; 
        public BSTNode<T> LeftChild; 
        public BSTNode<T> RightChild; 

        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    public class BSTFind<T>
    {
        public BSTNode<T> Node;

        public bool NodeHasKey;

        public bool ToLeft;

        public BSTFind()
        {
            Node = null;
        }
    }

    public class BST<T>
    {
        public BSTNode<T> Root; 
        public int counter = 0;

        public BST(BSTNode<T> node)
        {
            Root = node;
            counter++;
        }

        public BSTFind<T> FindNodeByKey(int key)
        {
            BSTFind<T> ResultNode = new BSTFind<T>();
            if (Root == null)
            {
                ResultNode.Node = null;
                return ResultNode;
            }

            BSTNode<T> CurrentNode = Root;
            while (CurrentNode != null)
            {
                if (key == CurrentNode.NodeKey)
                {
                    ResultNode.Node = CurrentNode;
                    ResultNode.NodeHasKey = true;
                    return ResultNode;
                }

                if (key < CurrentNode.NodeKey)
                {
                    if (CurrentNode.LeftChild == null)
                    {
                        ResultNode.Node = CurrentNode;
                        ResultNode.NodeHasKey = false;
                        ResultNode.ToLeft = true;
                        return ResultNode;
                    }
                    CurrentNode = CurrentNode.LeftChild;
                }
                else
                {
                    if (CurrentNode.RightChild == null)
                    {
                        ResultNode.Node = CurrentNode;
                        ResultNode.NodeHasKey = false;
                        ResultNode.ToLeft = false;
                        return ResultNode;
                    }
                    CurrentNode = CurrentNode.RightChild;
                }
            }

            return ResultNode;
        }

        public bool AddKeyValue(int key, T val)
        {
            BSTFind<T> ParentNode = FindNodeByKey(key);
            if (ParentNode.NodeHasKey == true) return false;
            if (ParentNode.Node is null)
            {
                Root = new BSTNode<T>(key, val, null);
                counter++;
                return true;
            }
            BSTNode<T> NodeToAdd = new BSTNode<T>(key, val, ParentNode.Node);
            if (ParentNode.ToLeft == true) ParentNode.Node.LeftChild = NodeToAdd;
            else ParentNode.Node.RightChild = NodeToAdd;
            counter++;
            return true;
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            if (FromNode == null) return null;
            BSTNode<T> CurrentNode = FromNode;
            if (FindMax == true) while (CurrentNode.RightChild != null) CurrentNode = CurrentNode.RightChild;
            else while (CurrentNode.LeftChild != null) CurrentNode = CurrentNode.LeftChild;
            return CurrentNode;
        }

        public bool DeleteNodeByKey(int key)
        {
            BSTFind<T> FindResult = FindNodeByKey(key);
            if (FindResult.Node == null || FindResult.NodeHasKey == false) return false;
            BSTNode<T> NodeToDelete = FindResult.Node;
            bool NoChilds = NodeToDelete.LeftChild == null && NodeToDelete.RightChild == null;
            if (NoChilds)
            {
                if (NodeToDelete == Root)
                {
                    counter--;
                    Root = null;
                    return true;
                }
                if (NodeToDelete.Parent.LeftChild == NodeToDelete) NodeToDelete.Parent.LeftChild = null;
                else NodeToDelete.Parent.RightChild = null;
                counter--;
                return true;
            }
            bool OneChild = NodeToDelete.LeftChild == null && NodeToDelete.RightChild != null || NodeToDelete.LeftChild != null && NodeToDelete.RightChild == null;
            BSTNode<T> ChildToReplace = (NodeToDelete.LeftChild != null) ? NodeToDelete.LeftChild : NodeToDelete.RightChild;
            if (OneChild)
            {
                ChildToReplace.Parent = NodeToDelete.Parent;
                if (NodeToDelete == Root)
                {
                    Root = ChildToReplace;
                    counter--;
                    return true;
                }
                if (NodeToDelete.Parent.LeftChild == NodeToDelete) NodeToDelete.Parent.LeftChild = ChildToReplace;
                else NodeToDelete.Parent.RightChild = ChildToReplace;
                NodeToDelete.Parent = null;
                NodeToDelete.LeftChild = null;
                NodeToDelete.RightChild = null;
                counter--;
                return true;
            }
            else
            {
                ChildToReplace = FinMinMax(NodeToDelete.RightChild, false);
                T ValueToReplace = ChildToReplace.NodeValue;
                int KeyToReplace = ChildToReplace.NodeKey;
                DeleteNodeByKey(ChildToReplace.NodeKey);
                NodeToDelete.NodeValue = ValueToReplace;
                NodeToDelete.NodeKey = KeyToReplace;
                return true;
            }

        }

        public int Count()
        {
            return counter;
        }
    }
}