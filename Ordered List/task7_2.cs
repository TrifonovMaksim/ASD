using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace AlgorithmsDataStructures
{
    public class OrderedList1<T>
    {
        public Node<T> head, tail;
        private bool _ascending;
        public int counter;

        public OrderedList1(bool asc)
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

        // Задание 8. Добавьте метод удаления всех дубликатов из упорядоченного списка.
        public void Delete_Duplicates(T val)
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
                while (head != null && Compare(head.value, val) == 0)
                {
                    head = head.next;
                    if (head != null) head.prev = null;
                    counter--;
                }
                return;
            }
            if (Compare(tail.value, val) == 0)
            {
                while (tail != null && Compare(tail.value, val) == 0)
                {
                    tail = tail.prev;
                    if (tail != null) tail.next = null;
                    counter--;
                }
                return;
            }
            Node<T> node = head;
            for (int i = 0; i < counter; i++)
            {
                // Если работаем по возростанию и следующий элемент больше искомого, заведомо понятно, что искомого элемента в списке нет.
                if (_ascending == true)
                {
                    if (Compare(val, node.value) == -1) return;
                }
                // Если работаем по убыванию и следующий элемент меньше искомого, заведомо понятно, что искомого элемента в списке нет.
                if (_ascending == false)
                {
                    if (Compare(val, node.value) == +1) return;
                }
                if (Compare(val, node.value) == 0)
                {
                    while (node != null && Compare(val, node.value) == 0)
                    {
                        Node<T> tmp = node.next;
                        tmp.prev = node.prev;
                        node.prev.next = tmp;
                        counter--;
                        node = node.next;
                    }
                    return;
                }
                node = node.next;
            }
            Console.WriteLine("Несуществующее значение");
        }
        /* Модифицировал удаление одного элемента так, что при нахождении нужного элемента для удаления, стоим на месте и удаляем узлы, пока значение узла равно нужному.
         * Сложность по времени O(n), так-как в худшем случае можем идти почти до конца списка.
         * Сложность по памяти O(1) ничего не создаем.
         */



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

        // Задание 10. Напишите метод проверки наличия заданного упорядоченного под-списка (параметр метода) в текущем списке.
        public void Check(OrderedList<T> list)
        {
            if (list == null || list.counter == 0)
            {
                Console.WriteLine("Дан пустой список");
                return;
            }
            if (counter == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            if (list.counter > counter)
            {
                Console.WriteLine("Искомый список больше имеющегося");
                return;
            }
            bool flag = false;
            bool shift = false;
            Node<T> node1 = head;
            Node<T> node2 = list.head;
            for (int i = 0; i < counter - list.counter + 1; i++)
            {
                // Если работаем по возростанию и следующий элемент больше искомого, заведомо понятно, что искомого элемента в списке нет.
                if (_ascending == true)
                {
                    if (Compare(node2.value, node1.value) == -1)
                    {
                        Console.WriteLine("Подсписка нет");
                        return;
                    }
                }
                // Если работаем по убыванию и следующий элемент меньше искомого, заведомо понятно, что искомого элемента в списке нет.
                if (_ascending == false)
                {
                    if (Compare(node2.value, node1.value) == +1)
                    {
                        Console.WriteLine("Подсписка нет");
                        return;
                    }
                }
                shift = false;
                if (Compare(node1.value, node2.value) == 0)
                {
                    flag = true;
                    for (int j = 0; j < list.counter; j++)
                    {
                        if (Compare(node1.value, node2.value) != 0)
                        {
                            node2 = list.head;
                            flag = false;
                            break;
                        }
                        node1 = node1.next;
                        node2 = node2.next;
                        shift = true;
                    }
                    if (flag == true)
                    {
                        Console.WriteLine("Подсписок есть");
                        return;
                    }
                }
                if (shift == false) node1 = node1.next;
            }
            Console.WriteLine("Подсписка нет");
        }

        /* Решил сделать так, идем по списку, находим первый элемент как в искомом и запускаем проверку с флагом. И потом в конце, по флагу определяем была ли последовательность или нет.
         * Сложность по времени O(n) проходим по двум спискам.
         * Сложность по памяти O(1) ничего не создаем.
         */


        // Задание 11.  Добавьте метод, который находит наиболее часто встречающееся значение в списке.
        public T Frequency()
        {
            if (counter == 0)
            {
                Console.WriteLine("Список пуст");
                return default(T);
            }
            if (counter == 1)
            {
                return head.value;
            }
            Node<T> node = head;
            int max_frequency = 1;
            int frequency = 0;
            T res = head.value;
            for (int i = 0; i < counter; i++)
            {
                frequency = 0;
                while (node.next != null && Compare(node.next.value, node.value) == 0)
                {
                    frequency++;
                    node = node.next;
                }
                if (frequency > max_frequency)
                {
                    max_frequency = frequency;
                    res = node.value;
                }
                if (node == tail) break;
                node = node.next;
            }
            return res;
        }
        /* Идем по списку и если следующий элемент равен текущему запускаем счетчик  и сохраняем его значение и значение элемента. И если в будущем будет значение, которое повторяется чаще чем сохраненное счетчик обновится.
         * Сложность по времени O(n) проходим один раз по списку.
         * Сложность по памяти O(1) ничего не создаем.
         */
    }
    public class Solution
    {
        // Задание 9. Напишите алгоритм слияния двух упорядоченных списков в один, сохраняя порядок элементов.
        public static OrderedList<T> Merge<T>(OrderedList<T> list1, OrderedList<T> list2, bool asc = true)
        {
            if (list1 == null || list2 == null) return null;
            if (list1.counter == 0 || list2.counter == 0)
            {
                Console.WriteLine("Один из списков пуст");
                return null;
            }
            OrderedList<T> res = new OrderedList<T>(asc);
            Node<T> node1 = list1.head;
            Node<T> node2 = list2.head;
            while (node1 != null && node2 != null)
            {
                if (res.Compare(node1.value, node2.value) == -1 || res.Compare(node1.value, node2.value) == 0)
                {
                    res.Add(node1.value);
                    node1 = node1.next;
                }
                else
                {
                    res.Add(node2.value);
                    node2 = node2.next;
                }
            }
            while (node1 != null)
            {
                res.Add(node1.value);
                node1 = node1.next;
            }
            while (node2 != null)
            {
                res.Add(node2.value);
                node2 = node2.next;
            }
            return res;
        }

        /* Сделал слияние, как в сортировке слиянием, мне кажется достаточно эфективно, проходим по каждому списку один раз и все.
         * Сложность по временти O(n + m) суммарная длина двух списков.
         * Сложность по памяти O(n + m) такая, потому что создаем новый список длиной суммы двух сливаемых списков.
         */
    }

    public class OrderedListIndex<T>
    {
        public List<T> list;
        public bool _ascending;
        public OrderedListIndex(bool asc)
        {
            _ascending = asc;
            list = new List<T>();
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
            if (list.Count == 0)
            {
                list.Add(value);
                return;
            }
            // Вставка если работаем со списком по возростанию
            if (_ascending == true)
            {
                if (Compare(value, list.First()) == -1)
                {
                    list.Insert(0, value);
                    return;
                }
                if (Compare(value, list.Last()) == +1)
                {
                    list.Add(value);
                    return;
                }
                for (int i = 0; i < list.Count(); i++)
                {
                    if (Compare(value, list[i]) == -1 || Compare(value, list[i]) == 0)
                    {
                        list.Insert(i, value);
                        return;
                    }
                }
                return;
            }
            // Вставка если работаем со списком по убыванию
            if (Compare(value, list.First()) == +1)
            {
                list.Insert(0, value);
                return;
            }
            if (Compare(value, list.Last()) == -1)
            {
                list.Add(value);
                return;
            }
            for (int i = 0; i < list.Count(); i++)
            {
                if (Compare(value, list[i]) == +1 || Compare(value, list[i]) == 0)
                {
                    list.Insert(i, value);
                    return;
                }
            }
        }

        // Задание 12. Добавьте в упорядоченный список возможность найти индекс элемента (параметр) в списке, которая должна работать за O(log N).
        public int? Find_Index(T val)
        {
            if (list.Count() == 0) return null;
            if (Compare(list.First(), val) == 0) return 0;
            if (Compare(list.Last(), val) == 0) return list.Count() - 1;
            int min_index = 0;
            int max_index = list.Count() - 1;
            if (_ascending == true)
            {
                while (min_index <= max_index)
                {
                    int middle = (max_index + min_index) / 2;
                    if (Compare(list[middle], val) == 0)
                    {
                        return middle;
                    }
                    if (Compare(list[middle], val) == -1)
                    {
                        min_index = middle + 1;
                        continue;
                    }
                    if (Compare(list[middle], val) == +1)
                    {
                        max_index = middle - 1;
                        continue;
                    }
                }
            }
            if (_ascending == false)
            {
                while (min_index <= max_index)
                {
                    int middle = (max_index + min_index) / 2;
                    if (Compare(list[middle], val) == 0)
                    {
                        return middle;
                    }
                    if (Compare(list[middle], val) == -1)
                    {
                        max_index = middle - 1;
                        continue;
                    }
                    if (Compare(list[middle], val) == +1)
                    {
                        min_index = middle + 1;
                        continue;
                    }
                }
            }
            return null;
        }
        // Реализовал бинарный поиск. Находим середину, проверяем равна ли она искомому, если нет проверям больше она искомого или меньше и исходя из этого меняем границы.
        // Сложность по времени O(LogN).
        // Сложность по памяти O(1) ничего не создаем.


        // Рекомендации по решению задач задания 5.

        /*3. Вращение очереди по кругу на N элементов.
         * Рефлексия по прошлому заданию. Сделал, как в эталонном решении брал с головы и вставлял в хвост n раз.
         * 
         * 
         * 4. Очередь с помощью двух стеков.
         * Рефлексия по прошлому заданию. Сделал, как в эталонном решении, в первый все клал за O(1) и пушил во второй только если он пуст, чтобы не перемешать элементы.
         * 
         * 
         * 5. Обращение всех элементов в очереди в обратном порядке.
         * Рефлексия по прошлому заданию. Тоже сделал, как в эталонном решении, запушил всю очередь в стек затем достал и положил в очередь в обратном порядке.
         * 
         * 
         * 6. Циклическая буферную очередь на базе статического массива фиксированного размера.
         * Рефлексия по прошлому заданию. Сделал почти, как в эталонном решении, только не делал пробел между головой и хвостом, для этого использовал отдельный счетчик.
         */
    }
}