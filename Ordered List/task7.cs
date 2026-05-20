using System;
using System.Collections.Generic;
using System.Xml.Linq;


namespace AlgorithmsDataStructures
{

    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;
        public int counter;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
            counter = 0;    
        }

        public int Compare(T v1, T v2)
        {
            int result = 0;
            if (typeof(T) == typeof(String))
            {
                // версия для лексикографического сравнения строк
                string a = ((string)((object)v1)).Trim();
                string b = ((string)((object)v2)).Trim();
                int res = a.CompareTo(b);
                if (res > 0) result = 1;
                if (res < 0) result = -1;
            }
            else
            {
                // универсальное сравнение
                IComparable a = (IComparable)((object)v1);
                IComparable b = (IComparable)((object)v2);
                int res = a.CompareTo(b);
                if (res > 0) result = 1;
                if (res < 0) result = -1;
            }

            return result;
            // -1 если v1 < v2
            // 0 если v1 == v2
            // +1 если v1 > v2
        }

        public void Add(T value)
        { 
            // автоматическая вставка value 
            // в нужную позицию
            if (value == null) throw new ArgumentNullException("Пустое значение");
            Node<T> new_node = new Node<T>(value);
            new_node.next = new_node.prev = null;
            if (head == null)
            {
                head = new_node;
                tail = head;
                counter++;
                return;
            }
            // Вставка если работаем со списком по возростанию
            if (_ascending == true)
            {
                if (Compare(new_node.value, head.value) == -1)
                {
                    Add_before_head(new_node);
                    return;
                }
                if (Compare(new_node.value, tail.value) == +1)
                {
                    Add_after_tail(new_node);
                    return;
                }
                Node<T> node = head;
                for (int i = 0; i < counter; i++)
                {
                    if (Compare(new_node.value, node.value) == -1 || Compare(new_node.value, node.value) == 0)
                    {
                        Add_between(new_node, node);
                        return;
                    }
                    node = node.next;
                }
                return;
            }
            // Вставка если работаем со списком по убыванию
            if (Compare(new_node.value, head.value) == +1)
            {
                Add_before_head(new_node);
                return;
            }
            if (Compare(new_node.value, tail.value) == -1)
            {
                Add_after_tail(new_node);
                return;
            }
            Node<T> node_1 = head;
            for (int i = 0; i < counter; i++)
            {
                if (Compare(new_node.value, node_1.value) == +1 || Compare(new_node.value, node_1.value) == 0)
                {
                    Add_between(new_node, node_1);
                    return;
                }
                node_1 = node_1.next;
            }
        }
        private void Add_before_head(Node<T> new_node)
        {
            new_node.next = head;
            head.prev = new_node;
            head = new_node;
            counter++;
            return;
        }
        private void Add_after_tail(Node<T> new_node)
        {
            tail.next = new_node;
            new_node.prev = tail;
            tail = new_node;
            counter++;
            return;
        }

        private void Add_between(Node<T> new_node, Node<T> node)
        {
            if (node.prev == null)
            {
                Add_before_head(new_node);
                return;
            }
            new_node.next = node;
            new_node.prev = node.prev;
            node.prev.next = new_node;
            node.prev = new_node;
            counter++;
            return;
        }

        // Задание 6. Переделайте функцию поиска с учётом признака упорядоченности и возможности раннего прерывания поиска.
        public Node<T> Find(T val)
        {
            if (counter == 0) return null;
            if (Compare(head.value, val) == 0) return head;
            if (Compare(tail.value, val) == 0) return tail;
            Node<T> node = head;
            for (int i = 0; i < counter; i++)
            {
                // Если работаем по возростанию и следующий элемент больше искомого, заведомо понятно, что искомого элемента в списке нет.
                if (_ascending == true)
                {
                    if (Compare(val, node.value) == -1) return null;
                }
                // Если работаем по убыванию и следующий элемент меньше искомого, заведомо понятно, что искомого элемента в списке нет.
                if (_ascending == false)
                {
                    if (Compare(val, node.value) == +1) return null;
                }
                if (Compare(val, node.value) == 0)
                {
                    return node;
                }
                node = node.next;
            }
            return null; 
        }
        // Сложность после модификации, не сильно изменилась, ведь в худшем случае мы все равно проходим по всем элементам списка.

        public void Delete(T val)
        {
            if (counter == 0)
            {
                Console.WriteLine("Список пустой");
                return;
            }
            if (Compare(head.value, val) == 0)
            {
                if (counter == 1)
                {
                    head = tail = null;
                    counter--;
                    return;
                }
                head = head.next;
                head.prev = null;
                counter--;
                return;
            }
            if (Compare(tail.value, val) == 0)
            {
                tail = tail.prev;
                tail.next = null;
                counter--;
                return;
            }
            Node<T> node = head;
            for (int i = 0; i < counter; i++)
            {
                if (Compare(val, node.value) == 0)
                {
                    Node<T> tmp = node.next;
                    tmp.prev = node.prev;
                    node.prev.next = tmp;
                    counter--;
                    return;
                }
                    node = node.next;
            }
            Console.WriteLine("Несуществующее значение");
        }

        public void Clear(bool asc)
        {
            _ascending = asc;
            head = tail = null;
            counter = 0;
        }

        public int Count()
        {
            return counter; // здесь будет ваш код подсчёта количества элементов в списке
        }

        public List<Node<T>> GetAll() // выдать все элементы упорядоченного 
                               // списка в виде стандартного списка
        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while (node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
        }
    }

}