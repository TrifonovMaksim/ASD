using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeAdd<T> : SimpleTree<T>
    {
        public SimpleTreeAdd(SimpleTreeNode<T> root) : base(root)
        {
        }

        // Задание 2.Добавьте метод, который сбалансирует чётное двоичное дерево.
        public void DoBalanceTree()
        {
            List<SimpleTreeNode<T>> NodesValues = new List<SimpleTreeNode<T>>();
            NodesValues = GetAllNodes();
            NodesValues.Sort((a, b) => Comparer<T>.Default.Compare(a.NodeValue, b.NodeValue));
            MakeBalanceTree(0, NodesValues.Count - 1, null);
            void MakeBalanceTree(int left, int right, SimpleTreeNode<T> Parent)
            {
                if (left > right) return;
                int mid = left + (right - left) / 2;
                SimpleTreeNode<T> NewNode = NodesValues[mid];
                NewNode.Parent = Parent;
                NewNode.Children = null;
                if (Parent == null) Root = NewNode;
                if (Parent != null)
                {
                    if (Parent.Children == null) Parent.Children = new List<SimpleTreeNode<T>>();
                    Parent.Children.Add(NewNode);
                }
                MakeBalanceTree(left, mid - 1, NewNode);
                MakeBalanceTree(mid + 1, right, NewNode);
            }
        }
        /* Как и в прошлых заданиях, собрал все узлы, отсортировал, затем заного,
         * рекурсивно построил отбалансированное дерево.
         * Сложность по времени O(nlogn), из-за сортировки.
         * Сложность по памяти O(n) создаем список для узлов.
         */


        // Задание 3. Добавьте метод, который для любого заданного подузла текущего дерева определит общее количество чётных поддеревьев.
        public int EvenTreesCount(SimpleTreeNode<T> Node)
        {
            int Counter = 0;
            int DoEvenTreesCount(SimpleTreeNode<T> node)
            {
                if (node == null) return 0;
                int CurrentSubSum = 1;
                if (node.Children != null) foreach(SimpleTreeNode<T> Child in node.Children)
                {
                    CurrentSubSum += DoEvenTreesCount(Child);
                }
                if (CurrentSubSum % 2 == 0)
                {
                    Counter++;
                }
                return CurrentSubSum;
            }
            DoEvenTreesCount(Node);
            return Counter;
        }
        /* Рекурсивно поднимаюсь с листьев, считая количество узлов, если набирается четное,
         * то засчитываю одно поддерево и иду дальше.
         * Сложность по времени O(n), в худшем случае заданным узлом будет корень.
         * Сложность по памяти O(1), ничего не создаем.
         */

    }


    // Рекомендации по решению задач задания 7.

    /* Рефлексия по прошлому заданию. 4. Поиск максимального элемента в заданном диапазоне значений.
     * Как сказано в эталоне, перебирал все элементы начиная с корня, если корень больше минимального
     * значения дивапазона, дальше искать смысла нет.
      */

    /* Рефлексия по прошлому заданию. 5. Предикативный поиск.
     * Как в рекоминадции, предположил, что благодаря корню можно сразу отсекать неподходящие поддеревья.
     * Если попадаем в подходящий узел провверяем потомков.
      */


    /* Рефлексия по прошлому заданию. 6. Объединение текущей кучи с кучей-параметром.
     * В отличие от эталона не делал копию изначальной кучи, хотя правильнее было бы ее
     * сохранить.
     */
}