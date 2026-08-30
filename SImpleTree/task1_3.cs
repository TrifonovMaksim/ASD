using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Tests
    {
        public static void AddChild1()
        {
            SimpleTree<int> test = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));
            SimpleTreeNode<int> child = new SimpleTreeNode<int>(2, null);
            test.AddChild(test.Root, child);
            Console.WriteLine(test.Root.Children != null && test.Root.Children.Contains(child)? "Тест AddChild1 пройден" : "Тест AddChild1 не пройден");
        }
        public static void DeleteNode1()
        {
            SimpleTree<int> test = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));
            SimpleTreeNode<int> child = new SimpleTreeNode<int>(2, null);
            SimpleTreeNode<int> child2 = new SimpleTreeNode<int>(3, null);
            test.AddChild(test.Root, child);
            test.AddChild(test.Root, child2);
            test.DeleteNode(child);
            List<SimpleTreeNode<int>> nodes = test.GetAllNodes();
            Console.WriteLine(!nodes.Contains(child) && nodes.Contains(child2) ? "Тест DeleteNode1 пройден" : "Тест DeleteNode1 не пройден");
        }
        public static void FindNodesByValue1()
        {
            SimpleTree<int> test = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));
            SimpleTreeNode<int> child = new SimpleTreeNode<int>(2, null);
            test.AddChild(test.Root, child);
            List<SimpleTreeNode<int>> res = test.FindNodesByValue(2);
            Console.WriteLine(res != null && res.Count == 1 && res[0] == child ? "Тест FindNodesByValue1 пройден" : "Тест FindNodesByValue1 не пройден");
        }
        public static void MoveNode1()
        {
            SimpleTree<int> test = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));
            SimpleTreeNode<int> child1 = new SimpleTreeNode<int>(2, null);
            SimpleTreeNode<int> child2 = new SimpleTreeNode<int>(3, null);
            SimpleTreeNode<int> child3 = new SimpleTreeNode<int>(4, null);
            test.AddChild(test.Root, child1);
            test.AddChild(test.Root, child2);
            test.AddChild(child1, child3);
            test.MoveNode(child3, child2);
            Console.WriteLine(!child1.Children.Contains(child3) && child2.Children.Contains(child3)? "Тест MoveNode1 пройден" : "Тест MoveNode1 не пройден");
        }
       public static void Count1()
        {
            SimpleTree<int> test = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));
            SimpleTreeNode<int> child1 = new SimpleTreeNode<int>(2, null);
            SimpleTreeNode<int> child2 = new SimpleTreeNode<int>(3, null);
            SimpleTreeNode<int> child3 = new SimpleTreeNode<int>(4, null);
            test.AddChild(test.Root, child1);
            test.AddChild(test.Root, child2);
            test.AddChild(child2, child3);
            Console.WriteLine(test.Count() == 4 ? "Тест Count1 пройден" : "Тест Count1 не пройден");
        }
        public static void LeafCount1()
        {
            SimpleTree<int> test = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));
            SimpleTreeNode<int> child1 = new SimpleTreeNode<int>(2, null);
            SimpleTreeNode<int> child2 = new SimpleTreeNode<int>(3, null);
            SimpleTreeNode<int> child3 = new SimpleTreeNode<int>(4, null);
            test.AddChild(test.Root, child1);
            test.AddChild(test.Root, child2);
            test.AddChild(child2, child3);
            Console.WriteLine(test.LeafCount() == 2 ? "Тест LeafCount1 пройден" : "Тест LeafCount1 не пройден");
        }

        public static void NodesSetLevel1()
        {
            SimpleTreeLevel<int> test = new SimpleTreeLevel<int>(new SimpleTreeNodeLevel<int>(1, null));
            SimpleTreeNodeLevel<int> child1 = new SimpleTreeNodeLevel<int>(2, null);
            SimpleTreeNodeLevel<int> child2 = new SimpleTreeNodeLevel<int>(3, null);
            SimpleTreeNodeLevel<int> child3 = new SimpleTreeNodeLevel<int>(4, null);
            test.AddChild(test.Root, child1);
            test.AddChild(test.Root, child2);
            test.AddChild(child1, child3);
            test.NodesSetLevel();
            Console.WriteLine(test.Root.Level == 0 && child1.Level == 1 && child2.Level == 1 && child3.Level == 2 ? "Тест NodesSetLevel1 пройден" : "Тест NodesSetLevel1 не пройден");
        }

        public static void Main(string[] args)
        {
            AddChild1();
            DeleteNode1();
            FindNodesByValue1();
            MoveNode1();
            Count1();
            LeafCount1();
            NodesSetLevel1();
        }
    }
}