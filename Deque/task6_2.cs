using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace AlgorithmsDataStructures
{
    public class Solution
    {
        // Задание 4. Напишите функцию, которая с помощью Deque проверяет, является ли некоторая строка палиндромом.
        public static void IsPolindrome(string str)
        {
            Deque<char> deque = new Deque<char>();
            foreach (char c in str) deque.AddTail(c);
            int deque_size = deque.Size();
            for (int i = 0; i < deque_size / 2; i++)
            {
                char a = deque.RemoveFront();
                char b = deque.RemoveTail();
                if (a != b)
                {
                    Console.WriteLine("Строка не является палиндромом");
                    return;
                }
            }
            Console.WriteLine("Строка является палиндромом");
        }
        /* Идем одновременно по голове и хвосту и сравниваем символы. Достаточно пройти пол длины слова, потому что если палиндром, то до середины все символы будут равны между собой. Если количество символов не четное, 
         * то это так же не играет роль, в палиндроме средний символ, будет равен сам себе.
         * Сложность по времени O(n) 2 раза проходим по строке.
         * Сложность по памяти O(n) создаем один двусвязный список.
         */


        // Задание 5. Напишите метод, который возвращает минимальный элемент деки за O(1).
        public class Deque1
        {
            public LinkedList<int> deque;
            public LinkedList<int> deque_for_min;
            public int size;
            public Deque1()
            {
                // инициализация внутреннего хранилища
                deque = new LinkedList<int>();
                deque_for_min = new LinkedList<int>();
                size = 0;
            }

            public void AddFront(int item)
            {
                // добавление в голову
                if (item == null) throw new ArgumentNullException("item");
                deque.AddFirst(item);
                size++;
                if (deque_for_min.Count == 0 || deque_for_min.Last.Value >= item) deque_for_min.AddLast(item);
            }

            public void AddTail(int item)
            {
                // добавление в хвост
                if (item == null) throw new ArgumentNullException("item");
                deque.AddLast(item);
                size++;
                if (deque_for_min.Count == 0 || deque_for_min.Last.Value >= item) deque_for_min.AddLast(item);
            }

            public int RemoveFront()
            {
                // удаление из головы
                if (size == 0) return default(int);
                int res = deque.First.Value;
                deque.RemoveFirst();
                size--;
                if (deque_for_min.Last.Value == res) deque_for_min.RemoveLast();
                return res;
            }

            public int RemoveTail()
            {
                // удаление из хвоста
                if (size == 0) return default(int);
                int res = deque.Last.Value;
                deque.RemoveLast();
                size--;
                if (deque_for_min.Last.Value == res) deque_for_min.RemoveLast();
                return res;
            }

            public int Size()
            {
                return size;
            }

            public int Min()
            {
                if (size == 0) return default(int);
                return deque_for_min.Last.Value;
            }

        }
        /* Для решения данного задания, переделал класс. Сделал, как в позапрошлом занятии со стеками, работал со вторым двусвязным списком, как со стеком и при добавлении и удалении из основного списка,
         * так же следил за вторым списком для минимумов, там отслеживал, чтобы корректно удалялись и прибавлялись элементы. В итоге на вершине стека, на основе двусвязного списка, у нас находится минимальный элемент за O(1).
         * Сложность по времени O(1).
         * Сложность по памяти, в худшем случае O(n), если в список будут добавлять элементы с каждым разом меньшие, чем предыдущие.
         */


        // Задание 6.  Реализуйте двустороннюю очередь с помощью динамического массива. Методы добавления и удаления элементов с обоих концов деки должны работать за амортизированное время o(1).
        public class Deque_on_DynArray<T>
        {
            public T[] array;
            public int count;
            public int capacity;
            public int head;
            public int tail;

            public Deque_on_DynArray()
            {
                count = 0;
                head = 0;
                tail = 0;
                MakeArray(16);
            }

            public void MakeArray(int new_capacity)
            {
                T[] new_array = new T[new_capacity];
                if (array == null)
                {
                    array = new_array;
                    capacity = new_capacity;
                    return;
                }
                Array.Copy(array, head, new_array, 0, capacity - head);
                Array.Copy(array, 0, new_array, capacity - head, head);
                head = 0;
                tail = capacity;
                array = new_array;
                capacity = new_capacity;
            }

            public void AddFront(T item)
            {
                // добавление в голову
                if (count >= capacity)
                {
                    int new_capacity = capacity * 2;
                    MakeArray(new_capacity);
                }
                head = (head - 1 + capacity) % capacity;
                array[head] = item;
                count++;
            }

            public void AddTail(T item)
            {
                // добавление в хвост
                if (count >= capacity)
                {
                    int new_capacity = capacity * 2;
                    MakeArray(new_capacity);
                }
                tail = (tail + 1) % capacity;
                array[tail] = item;
                count++;
            }

            public T RemoveFront()
            {
                // удаление из головы
                if (count == 0) return default(T);
                T res = array[head];
                head = (head + 1) % capacity;
                count--;
                return res;
            }

            public T RemoveTail()
            {
                // удаление из хвоста
                if (count == 0) return default(T);
                T res = array[tail];
                tail = (tail - 1 + capacity) % capacity;
                count--;
                return res;
            }

            public int Size()
            {
                return count;
            }
        }
        /* Сделал, как сказано на основе динамического массива. Скелет взял из предыдущих занятий. Вся фишка амортизированной сложности, что мы работаем с массивом зацикленно. То есть, при добавлении в хед, мы не двигаем массив,
         * а добавляем элементы с конца массива. Реализуется это с помощью индексов, которые зацикливаются путем нахождения остатка от деления. Естественно при увеличении массива, срабатывает сложность O(n) при копировании всех элементов в новый массив.
         * Сложность по времени у методов амортизированная O(1), но при расширении массива и при уменьшении она будет O(n).
         * Сложность по памяти, так же, амортизированная O(1), при реаллокации O(n).
         */

    }
    // Рекомендации по решению задач задания 4.

    // Задание 4. Баланс открывающих и закрывающих скобок.
    // задание 5. Баланс открывающих и закрывающих скобок трёх типов.
    /* Рефлексия по прошлому заданию. Сделал почти, как в эталонном решении. Пушил в стек открывающие, потом, если закрывающая, доставал из стека и сравнивал, если не та пара, значит баланс нарушен.
     * Если после всех сравнений в стеке что то осталось, значит больше открывающих и баланс нарушен. Единственное сделал не через словарь, а через свитч кейс.
     */

    // Задание 6.Текущий минимальный элемент в стеке за O(1).
    /* Рефлексия по прошлому заданию. Сделал все, как в эталонном решении. Единственное бы добавил, что сначала не правильно делал сравнение, если элемент равен вершине стека минимумов, его все равно надо добавить в стек,
       потому что если его не добавить, то например было два повторяющихся минимальных элемента, а мы добавили один, при попе из основного стека одного из минимальных элементов, мы наввсегда теряем его значение, хотя в основном стеке,
       все еще будет второй такой минимальный элемент.
    */

    // Задание 7. Среднее значение всех элементов в стеке за O(1).
    /* Рефлексия по прошлому заданию. Сделал, как в эталонном решении, только поле не приватное). Было понятно, что надо просто сделать поле со счетчиком.
     */

    // Задание 8. Постфиксная запись выражения.
    /* Рефлексия по прошлому заданию. Сделал через свитч кейс, хорошее замечание про то, что не надо делать два попа в одну строку, не знал, что могут символы не в том порядке достаться.
     */

}
