using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AlgorithmsDataStructures2
{
    public class BalancedBSTAdd : BalancedBST
    {
        public BalancedBSTAdd() 
        { 
        }

        // Задание 2.Добавьте метод проверки, действительно ли дерево получилось правильным.
        public bool IsTreeRight()
        {
            if (Root == null) return true;
            return DoIsTreeRight(Root, null, null);
        }

        private bool DoIsTreeRight(BSTNode Node, int? MinKeyValue, int? MaxKeyValue)
        {
            if (Node == null) return true;
            if (MinKeyValue != null && Node.NodeKey <= MinKeyValue) return false;
            if (MaxKeyValue != null && Node.NodeKey >= MaxKeyValue) return false;
            bool IsRightSubtreeRight = DoIsTreeRight(Node.LeftChild, MinKeyValue, Node.NodeKey);
            bool IsLeftSubtreeRight = DoIsTreeRight(Node.RightChild, Node.NodeKey, MaxKeyValue);
            if (IsLeftSubtreeRight && IsRightSubtreeRight) return true;
            return false;
        }
        /* Спускаюсь по веткам дерева. По правилам все узлы левого поддерева должны быть не больше корня,
         * а все узлы правого поддерева должны быть больше корня, поэтому запоминаем границы между которыми должен быть узел и 
         * спускаемся по ветке.
         * Сложность по времени O(n), проходим по всем узлам.
         * Сложность по памяти O(1), ничего не создаем.
         */
    }

    // Рекомендации по решению задач задания 4.

    /* Рефлексия по прошлому заданию. 2. Поиск наименьшего общего предка (LCA).
     * В отличие от эталона, шел от обоих узлов вверх, сравнивая их, и исходя из сравнений,
     * выбирал, по какоиу из них надо подняться к родителю, пока они не сойдутся - тоесть это общий предок.
     * У меня нет таких проверок, что поддеревья что то не возвращают, так как в любом случае если узлы существуют изначально,
     * значит у них точно есть общий предок - корень. У меня не было разделения на 2 поддерева, сделал проще.
     */

    /* Рефлексия по прошлому заданию. 3. Оптимизированный метод обхода дерева в ширину.
     * Сделал не как в эталоне. Надо было сделать такой же обход, как и при ссылочном дереве,
     * через очередь, но используя индексы массива. Я подумал, что раз это уже бинарное дерево в массиве,
     * оно уже упорядочено лежит в нем, значит надо просто скопировать)
     */


}