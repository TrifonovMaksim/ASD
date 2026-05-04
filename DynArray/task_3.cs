using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
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
            Array.Copy(array, 0, new_array, 0, count);
            array = new_array;
            capacity = new_capacity;
        }

        public T GetItem(int index)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException("Некорректный индекс");
            return array[index];
        }

        public void Append(T itm)
        {
            if (count >= capacity)
            {
                int new_capacity = capacity * 2;
                MakeArray(new_capacity);
            }
            array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            if (index < 0 || index > count) throw new IndexOutOfRangeException("Некорректный индекс");
            int new_count = count + 1;
            if (new_count > capacity) MakeArray(capacity * 2);
            for (int i = count - 1; i >= index; i--)
            {
                array[i + 1] = array[i];
            }
            array[index] = itm;
            count = new_count;
        }

        public void Remove(int index)
        {
            if (index < 0 || index > count - 1) throw new IndexOutOfRangeException("Некорректный индекс");
            for (int i = index; i < count - 1; i++)
            {
                array[i] = array[i + 1];
            }
            count -= 1;
            if ((int)(capacity / 2) > count && capacity > 16) MakeArray((int)(capacity / 1.5) > 16? (int)(capacity / 1.5) : 16);
        }

    }
}

