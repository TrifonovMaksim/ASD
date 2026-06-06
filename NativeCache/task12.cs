using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class NativeCache<T>
    {
        public int size;
        public string[] slots;
        public T[] values;
        public int[] hits;
        public int counter;

        public NativeCache(int sz)
        {
            // для того, чтобы двойное хэширование могло пройти все слоты, нужен размер, равный простому числу
            size = CalcSimple(sz);
            slots = new string[size];
            values = new T[size];
            hits = new int[size];
            counter = 0;    
        }
        public bool IsSimple(int digit)
        {
            // проверка числа на простоту
            bool res = true;
            for (int i = 2; i <= Math.Sqrt(digit); i++)
            {
                if (digit % i == 0)
                {
                    res = false;
                    return res;
                }
            }
            return res;
        }

        public int CalcSimple(int old_number)
        {
            // высчитывание простого числа
            if (IsSimple(old_number)) return old_number;
            int new_number = old_number + 1;
            while (!IsSimple(new_number))
            {
                new_number++;
            }
            return new_number;
        }
        public int HashFun(string key, int i)
        {
            // всегда возвращает корректный индекс слота
            if (key == null) throw new Exception("Неверное занчение");
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
            // находит индекс пустого слота для ключа
            int idx = HashFun(key, 0);
            if (slots[idx] == null) return idx;
            for (int i = 1; i < size; i++)
            {
                idx = HashFun(key, i);
                if (slots[idx] == null) return idx;
            }
            return -1;
        }
        public int FindKeyIndex(string key)
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
            int idx;
            if (IsKey(key))
            {
                idx = FindKeyIndex(key);
                values[idx] = value;
                return;
            }
            if (size != counter)
            {   
                idx = SeekSlot(key);
                slots[idx] = key;
                values[idx] = value;
                counter++;
                return;
            }
            idx = FindMinEntranceIdx();
            Delete(idx);
            idx = SeekSlot(key);
            slots[idx] = key;
            values[idx] = value;
        }

        public T Get(string key)
        {
            // возвращает value для key, 
            // или null если ключ не найден
            if (!IsKey(key)) return default(T);
            int idx = FindKeyIndex(key);
            hits[idx]++;
            return values[idx];
        }

        public int FindMinEntranceIdx()
        {
            // находит индекс значения с минимальным количеством обращений
            int idx = 0;
            for (int i = 1; i < size; i++)
            {
                if (hits[idx] > hits[i]) idx = i;
            }
            return idx;
        }

        public void Delete(int idx)
        {
            // удаляет значение
            slots[idx] = null;
            hits[idx] = 0;
            values[idx] = default(T);
        }
    }
}