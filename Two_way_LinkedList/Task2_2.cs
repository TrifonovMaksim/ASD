using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Permissions;
using System.Xml;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
        }

        public Node Find(int _value)
        {
            if (head == null) return null;
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    return node;
                }
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            if (head == null) return nodes;
            while (node != null)
            {
                if (node.value == _value) nodes.Add(node);
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            if (head == null) return false;
            Node node = head;
            if (node.value == _value && Count() == 1)
            {
                head = null;
                tail = null;
                return true;
            }
            while (node != null)
            {
                if (node.value == _value)
                {
                    if (node == head)
                    {
                        head = head.next;
                        head.prev = null;
                        return true;
                    }
                    if (node == tail)
                    {
                        tail = tail.prev;
                        tail.next = null;
                        return true;
                    }
                    node.prev.next = node.next;
                    node.next.prev = node.prev;
                    return true;
                }
                node = node.next;
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            if (head == null) return;
            Node node = head;
            if (node.value == _value && Count() == 1)
            {
                head = null;
                tail = null;
                return;
            }
            while (node != null)
            {
                if (node.value == _value)
                {
                    if (node == head)
                    {
                        head = head.next;
                        head.prev = null;
                        node = head;
                        continue;
                    }
                    if (node == tail)
                    {
                        tail = tail.prev;
                        tail.next = null;
                        return;
                    }
                    node.prev.next = node.next;
                    node.next.prev = node.prev;
                    node = node.next;
                    continue;
                }
                node = node.next;
            }
            return;
        }

        public void Clear()
        {
            head = tail = null;
        }

        public int Count()
        {
            Node node = head;
            int counter = 0;
            while (node != null)
            {
                counter++;
                node = node.next;
            }
            return counter;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeToInsert == null) return;
            _nodeToInsert.prev = _nodeToInsert.next = null;
            if (_nodeAfter == null)
            {
                if (head != null)
                {
                    head.prev = _nodeToInsert;
                    _nodeToInsert.next = head;
                    head = _nodeToInsert;
                    return;
                }
                else
                {
                    head = tail = _nodeToInsert;
                    return;
                }
            }
            Node node = head;
            if (_nodeAfter == tail)
            {
                tail.next = _nodeToInsert;
                _nodeToInsert.prev = tail;
                tail = _nodeToInsert;
                return;
            }
            while (node != null)
            {
                if (node == _nodeAfter)
                {
                    _nodeToInsert.next = node.next;
                    _nodeToInsert.prev = node;
                    node.next.prev = _nodeToInsert;
                    node.next = _nodeToInsert;
                    return;
                }
                node = node.next;
            }

        }
        public void InsertFirst(Node _nodeToInsert)
        {
            if (_nodeToInsert == null) return;
            _nodeToInsert.prev = _nodeToInsert.next = null;
            if (head != null)
            {
                head.prev = _nodeToInsert;
                _nodeToInsert.next = head;
                head = _nodeToInsert;
                return;
            }
            else
            {
                head = tail = _nodeToInsert;
                return;
            }
        }

        // Задание 9 Добавьте метод, который "переворачивает" порядок элементов в связном списке, меняя его на противоположный.
        public void Reverse()
        {
            if (head == null || head == tail) return;
            Node node = tail;
            Node tmp = null;
            node.next = node.prev;
            node.prev = null;
            tail = head;
            head = node;
            node = node.next;
            while (node != null)
            {
                tmp = node.next;
                node.next = node.prev;
                node.prev = tmp;
                node = node.next;
            }
        }
        /*Решил сделать через хвост, начал с конца идти и менял свзяи. 
         По сложности, O(n) проход по списку. Итоговая сложность O(n).
         По памяти, O(1) так как ничего не создаем.
         */

        // Задание 10 Добавьте булев метод, который сообщает, имеются ли циклы (замкнутые на себя по кругу) внутри списка.
        public bool IsCycled()
        {
            if (head == null) return false;
            Node slow_pointer = head;
            Node fast_pointer = head.next;

            while (slow_pointer != null && fast_pointer != null && fast_pointer.next != null)
            {
                if (slow_pointer == fast_pointer) return true;
                slow_pointer = slow_pointer.next;
                fast_pointer = fast_pointer.next.next;
            }
            return false;
        }
        /*Сначала хотел просто сделать через счетчик, как то связать время прохода с длинной и если вдруг проход по списку идет дольше чем надо, значит зацикленно, но в нынешней реализации не получится, так как у нас счетчик проходит весь список и если он зациклен, то и счетчик зациклится. Но можно счетчик умнее реализовать через поле класса, и при прибавлении или удалении элементов его изменять, тогда он независимо от зацикливания будет показывать правду.
         * В интернете посмотрел, что идея реализации в двух указателях медленном и быстром, так и сделал.
         * По сложности O(n) один проход.
         * По памяти, O(1) так как ничего не создаем.
         */

        // Задание 11 Добавьте метод, сортирующий список.
        public void Sort()
        {
            if (head == null || head == tail) return;
            LinkedList2 tmp_linked_list = new LinkedList2();
            while (head != null)
            {
                Node min_node = head;
                Node node = head.next;
                while (node != null)
                {
                    if (min_node.value > node.value) min_node = node;
                    node = node.next;
                }
                tmp_linked_list.AddInTail(new Node(min_node.value));
                Remove(min_node.value);
            }
            this.head = tmp_linked_list.head;
            this.tail = tmp_linked_list.tail;
        }
        /*Можно было сделать и сортировку на месте, но тогда было бы легко запутаться со связями, было бы много краевых случаев с хвостом и головой. Поэтому решил сделать через новый список.
         * По сложности O(n^2) так как, для всех элементов проходим список заново сравнивая, по сути вложенный цикл.
         * По памяти O(n) так как создали нвоый список такой же длины.
         */


        // Задание 12 Добавьте метод, объединяющий два списка в третий. Эти списки предварительно надо отсортировать, и выдать результирующий список, в котором все элементы также будут упорядочены (для результирующего списка использовать метод сортировки не разрешается).
        public LinkedList2 CompareTwoLists(LinkedList2 list1, LinkedList2 list2)
        {
            LinkedList2 res_list = new LinkedList2();
            list1.Sort();
            list2.Sort();
            Node node1 = list1.head;
            Node node2 = list2.head;
            while (node1 != null && node2 != null)
            {
                if (node1.value < node2.value)
                {
                    res_list.AddInTail(new Node(node1.value));
                    node1 = node1.next;
                }
                else
                {
                    res_list.AddInTail(new Node(node2.value));
                    node2 = node2.next;
                }
            }
            while (node1 != null)
            {
                res_list.AddInTail(new Node(node1.value));
                node1 = node1.next;
            }
            while (node2 != null)
            {
                res_list.AddInTail(new Node(node2.value));
                node2 = node2.next;
            }
            return res_list;
        }
        /*  Сначала отсортировал 2 списка, потом просто идя 2 казателями по списками добавлял наименьшие значения по очереди. После того, как один из списков кончается я добавляю все оставшиеся значения из другого.
         *  По сложности, сортировка 2 списков это O(n^2) каждый и еще проход по спискам, для добавления элементов в новый. Итоговая O(2n^2 + 2n) или примерно O(n^2).
         *  По памяти, длина нового списка O(2n) или O(n).
         */
    }
}

