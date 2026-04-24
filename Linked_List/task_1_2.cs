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
