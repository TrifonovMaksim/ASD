using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
        }

        public int HashFun(string key, int i)
        {
            // всегда возвращает корректный индекс слота
            if (key == null) throw new Exception("Неверное занчение ключа");
            int res = 0;
            foreach (var item in key)
            {
                res += (int)item;
            }
            int h1 = res % size;
            int h2 = 1 + (res % (size - 1));
            return (h1 + i * h2) % size;
        }
        public int SeekSlot(string key)
        {
            // находит индекс пустого слота для значения
            for (int i = 0; i < size; i++)
            {
                int idx = HashFun(key, i);
                if (slots[idx] == null) return idx;
            }
            return -1;
        }

        private int FindKeyIndex(string key)
        {
            // находит индекс ключа
            for (int i = 0; i < size; i++)
            {
                int idx = HashFun(key, i);
                if (slots[idx] == key) return idx;
            }
            return -1;
        }

        public bool IsKey(string key)
        {
            // возвращает true если ключ имеется,
            // иначе false
            if (FindKeyIndex(key) != -1) return true;
            return false;
        }

        public void Put(string key, T value)
        {
            // гарантированно записываем 
            // значение value по ключу key
            if (IsKey(key))
            {
                values[FindKeyIndex(key)] = value;
                return;
            }
            int idx = SeekSlot(key);
            slots[idx] = key;
            values[idx] = value;
        }

        public T Get(string key)
        {
            // возвращает value для key, 
            // или null если ключ не найден
            if (!IsKey(key)) return default(T);
            return values[FindKeyIndex(key)];

        }
    }
}
