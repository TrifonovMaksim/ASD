using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Queue<T>
    {
        int size;
        LinkedList<T> queue;
        public Queue()
        {
            size = 0;
            queue = new LinkedList<T>();
        }

        public void Enqueue(T item)
        {
            if (item == null) throw new ArgumentNullException("item");
            queue.AddLast(item);
            size++;
        }

        public T Dequeue()
        {
            if (size == 0) return default(T);
            else
            {
                T res = queue.First.Value;
                queue.RemoveFirst();
                size--;
                return res;
            }
        }

        public int Size()
        {
            return size; 
        }
        // Задание 2.Оцените меру сложности для операций enqueue() (добавление) и dequeue() (удаление) в данной реализации.
        // В данной реализации сложность по времени и по памяти для обеих операций 0(1).

    }
}
