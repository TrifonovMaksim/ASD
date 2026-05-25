using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;
        public int fullnes;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];

            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            // всегда возвращает корректный индекс слота
            if (value == null) throw new Exception("В хэш функцию, подано пустое значение");
            int res = 0;
            foreach (var item in value)
            {
                res += (int)item;
            }
            return res % size;
        }

        public int SeekSlot(string value)
        {
            // находит индекс пустого слота для значения, или -1
            if (fullnes == size)
            {
                Console.WriteLine("Хэш таблица заполнена");
                return -1;
            }
            int idx = HashFun(value);
            if (slots[idx] == null) return idx;
            for (int i = 0; i < size; i ++)
            {
                idx = (idx + step) % size;
                if (slots[idx] == null) return idx; 
            }
            return -1;
        }

        public int Put(string value)
        {
            // записываем значение по хэш-функции

            // возвращается индекс слота или -1
            // если из-за коллизий элемент не удаётся разместить 
            if (fullnes == size)
            {
                Console.WriteLine("Хэш таблица заполнена");
                return -1;
            }
            int idx = SeekSlot(value);
            if (idx == -1) return -1;
            slots[idx] = value;
            fullnes++;
            return idx;
        }

        public int Find(string value)
        {
            // находит индекс слота со значением, или -1
            int idx = HashFun(value);
            if (slots[idx] == value)
            {
                return idx;
            }
            for (int i = 0; i < size; i++)
            {
                idx = (idx + step) % size;
                if (slots[idx] == value)
                {
                    return idx;
                }
            }
            return -1;
        }
    }

}
