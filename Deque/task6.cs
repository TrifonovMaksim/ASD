using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    class Deque<T>
    {
        public LinkedList<T> deque;
        public int size;
        public Deque()
        {
            // инициализация внутреннего хранилища
            deque = new LinkedList<T>();
            size = 0;
        }

        public void AddFront(T item)
        {
            // добавление в голову
            if (item == null) throw new ArgumentNullException("item");
            deque.AddFirst(item);
            size++;
        }

        public void AddTail(T item)
        {
            // добавление в хвост
            if (item == null) throw new ArgumentNullException("item");
            deque.AddLast(item);
            size++;
        }

        public T RemoveFront()
        {
            // удаление из головы
            if (size == 0) return default(T);
            T res = deque.First.Value;
            deque.RemoveFirst();
            size--;
            return res;
        }

        public T RemoveTail()
        {
            // удаление из хвоста
            if (size == 0) return default(T);
            T res = deque.Last.Value;
            deque.RemoveLast();
            size--;
            return res;
        }

        public int Size()
        {
            return size; // размер очереди
        }

        // Задание 2. Как можно понизить (выровнять) сложность addHead/removeHead и addTail/removeTail, с помощью какого ранее изученного типа данных?
        /* Выровнять можно с помощью двусвязного списка, так как в нем, мы за О(1) работаем и с началом и с концом. 
         */
    }

}