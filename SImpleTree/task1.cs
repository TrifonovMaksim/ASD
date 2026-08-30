using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue;
        public SimpleTreeNode<T> Parent;
        public List<SimpleTreeNode<T>> Children;

        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = null;
        }
    }

    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root;

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }

        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            if (NewChild is null || ParentNode is null) return;
            if (ParentNode.Children is null) ParentNode.Children = new List<SimpleTreeNode<T>>();
            ParentNode.Children.Add(NewChild);
            NewChild.Parent = ParentNode;
        }

        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)
        {
            if (NodeToDelete is null) return;
            if (NodeToDelete == Root)
            {
                Root = null;
                return;
            }
            if (NodeToDelete.Parent != null && NodeToDelete.Parent.Children != null)
            {
                NodeToDelete.Parent.Children.Remove(NodeToDelete);
                if (NodeToDelete.Parent.Children.Count == 0) NodeToDelete.Parent.Children = null;
            }       
            NodeToDelete.Parent = null;
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            if (Root is null) return null;
            List<SimpleTreeNode<T>> ListOfNodes = new List<SimpleTreeNode<T>>();
            void DoGetAllNodes(SimpleTreeNode<T> node)
            {
                if (node is null) return;
                ListOfNodes.Add(node);
                if (node.Children != null) foreach (SimpleTreeNode<T> child in node.Children) DoGetAllNodes(child);
            }
            DoGetAllNodes(Root);
            return ListOfNodes;
        }


        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            List<SimpleTreeNode<T>> NodesEqualValue = GetAllNodes();
            List<SimpleTreeNode<T>> ResEqualNodes = new List<SimpleTreeNode<T>>();
            foreach (SimpleTreeNode<T> node in NodesEqualValue)
            {
                if (node.NodeValue.Equals(val)) ResEqualNodes.Add(node);
            }
            return ResEqualNodes;
        }

        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            if (OriginalNode is null || NewParent is null) return;
            DeleteNode(OriginalNode);
            AddChild(NewParent, OriginalNode);
        }

        public int Count()
        {
            List<SimpleTreeNode<T>> AllNodes = GetAllNodes();
            return AllNodes.Count;
        }

        public int LeafCount()
        {
            List<SimpleTreeNode<T>> AllNodes = GetAllNodes();
            int counter = 0;
            foreach (SimpleTreeNode<T> node in AllNodes)
            {
                if (node.Children is null) counter++;
            }
            return counter;
        }

    }

}