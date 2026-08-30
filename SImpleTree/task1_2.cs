using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNodeLevel<T> : SimpleTreeNode<T>
    {
        public int Level;
        public new SimpleTreeNodeLevel<T> Parent;
        public new List<SimpleTreeNodeLevel<T>> Children;
        public SimpleTreeNodeLevel(T val, SimpleTreeNodeLevel<T> parent) : base(val, parent)
        {
            Level = default(int);
        }
    }

    public class SimpleTreeLevel<T>
    {
        public SimpleTreeNodeLevel<T> Root;

        public SimpleTreeLevel(SimpleTreeNodeLevel<T> root)
        {
            Root = root;
        }

        public void AddChild(SimpleTreeNodeLevel<T> ParentNode, SimpleTreeNodeLevel<T> NewChild)
        {
            if (NewChild is null || ParentNode is null) return;
            if (ParentNode.Children is null) ParentNode.Children = new List<SimpleTreeNodeLevel<T>>();
            ParentNode.Children.Add(NewChild);
            NewChild.Parent = ParentNode;
        }

        public void DeleteNode(SimpleTreeNodeLevel<T> NodeToDelete)
        {
            if (NodeToDelete is null) return;
            if (NodeToDelete == Root)
            {
                Root = null;
                return;
            }
            NodeToDelete.Parent.Children.Remove(NodeToDelete);
            NodeToDelete.Parent = null;
        }

        public List<SimpleTreeNodeLevel<T>> GetAllNodes()
        {
            if (Root is null) return null;
            List<SimpleTreeNodeLevel<T>> ListOfNodes = new List<SimpleTreeNodeLevel<T>>();
            void DoGetAllNodes(SimpleTreeNodeLevel<T> node)
            {
                if (node is null) return;
                ListOfNodes.Add(node);
                if (node.Children != null) foreach (SimpleTreeNodeLevel<T> child in node.Children) DoGetAllNodes(child);
            }
            DoGetAllNodes(Root);
            return ListOfNodes;
        }


        public List<SimpleTreeNodeLevel<T>> FindNodesByValue(T val)
        {
            List<SimpleTreeNodeLevel<T>> NodesEqualValue = GetAllNodes();
            List<SimpleTreeNodeLevel<T>> ResEqualNodes = new List<SimpleTreeNodeLevel<T>>();
            foreach (SimpleTreeNodeLevel<T> node in NodesEqualValue)
            {
                if (node.NodeValue.Equals(val)) ResEqualNodes.Add(node);
            }
            return ResEqualNodes;
        }

        public void MoveNode(SimpleTreeNodeLevel<T> OriginalNode, SimpleTreeNodeLevel<T> NewParent)
        {
            if (OriginalNode is null || NewParent is null) return;
            DeleteNode(OriginalNode);
            AddChild(NewParent, OriginalNode);
        }

        public int Count()
        {
            List<SimpleTreeNodeLevel<T>> AllNodes = GetAllNodes();
            return AllNodes.Count;
        }

        public int LeafCount()
        {
            List<SimpleTreeNodeLevel<T>> AllNodes = GetAllNodes();
            int counter = 0;
            foreach (SimpleTreeNodeLevel<T> node in AllNodes)
            {
                if (node.Children is null) counter++;
            }
            return counter;
        }

        // Задание 1. Напишите метод, который перебирает всё дерево и прописывает каждому узлу его уровень.                                                                                                                                                                                                                                                                      
        public void NodesSetLevel()
        {                                                                                                   
            int lvl = 0;
            DoNodesSetLevel(Root, lvl);
            void DoNodesSetLevel(SimpleTreeNodeLevel<T> node, int level)
            {
                if (node is null) return;
                node.Level = level;
                if (node.Children != null) foreach (SimpleTreeNodeLevel<T> nod in node.Children) DoNodesSetLevel(nod, level + 1);
            }
        }
        /* Сделал проход вглубь, по всем узлам, при проходе расставляя уровни.
         * Сложность по времени O(n), проходим все узлы.
         * Сложность по памяти O(1), ничего не создаем для хранения.
         */
    }
    // Задание 2. Придумайте, как лучше организовать поддержку уровня узлов без анализа всего дерева.
    /* Думаю проще всего было бы, просто при добавлении и удалении узлов, сразу прописывать уровни и все.
     */
}
