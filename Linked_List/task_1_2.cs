using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Xml;

namespace AlgorithmsDataStructures
{
    public class Solution
    {
        public static LinkedList LinkedListsSum(LinkedList q, LinkedList w)
        {
            LinkedList res_list = new LinkedList();
            
            if (q.Count() != w.Count()) return res_list;
            Node qnode = q.head;
            Node wnode = w.head;
            while (qnode != null && wnode != null)
            {
                res_list.AddInTail(new Node(qnode.value + wnode.value));
                qnode = qnode.next;
                wnode = wnode.next;
            }
            return res_list;
        }
    }
}

/*
Задание 8. Сумма двух списков.
Сложность по времени: Для каждого count O(n), и проход по узлу в каждом списке тоже O(n), получается по времени сложность O(3n) что сокращается до O(n).
Сложность по памяти: Создаем новый список, поэтому O(n).
По заданию, я понял, что нужно пройти паралельно по двум спискам и сумму значений пары, добавлять в новый список. Сначала я хотел измерив длину одного списка, сделать через for, но потом понял, что через i счетчик, я не буду двигаться по списку, так как надо идти по ссылкам на каждом шагу, я не могу обратиться по индексу просто.
*/