using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    // наследуйте этот класс от HashTable
    // или расширьте его методами из HashTable
    public class PowerSet<T>
    {
        public int size;
        public T[] slots;
        public int count;
        public bool[] is_deleted;

        public PowerSet()
        {
            // ваша реализация хранилища
            size = 20000;
            slots = new T[size];
            is_deleted = new bool[size];
        }

        public int Size()
        {
            // количество элементов в множестве
            return count;
        }

        public void Put(T value)
        {
            // всегда срабатывает
            if (count == size)
            {
                Console.WriteLine("Множество заполненно");
                return;
            }
            int idx = SeekSlot(value);
            if (idx == -1) return;
            slots[idx] = value;
            count++;
        }

        public bool Get(T value)
        {
            // возвращает true если value имеется в множестве,
            // иначе false
            if (FindKeyIndex(value) != -1) return true;
            return false;
        }

        public bool Remove(T value)
        {
            // возвращает true если value удалено
            // иначе false
            int idx = FindKeyIndex(value);
            if (idx != -1)
            {
                slots[idx] = default(T);
                is_deleted[idx] = true;
                count--;
                if (count == 0) is_deleted = new bool[size];
                return true;
            }
            return false;
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            // пересечение текущего множества и set2
            PowerSet<T> res = new PowerSet<T>();
            PowerSet<T> small = set2;
            PowerSet<T> large = this;
            if (Size() < set2.Size()) // выгоднее идти по меньшему множеству
            {
                small = this;
                large = set2;
            }
            for (int i = 0; i < small.size; i++)
            {
                if (!object.Equals(small.slots[i], default(T)) && large.Get(small.slots[i])) res.Put(small.slots[i]);
            }
                return res;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            // объединение текущего множества и set2
            PowerSet<T> res = new PowerSet<T>();
            for(int i = 0; i < size; i++)
            {
                if (!object.Equals(this.slots[i], default(T))) res.Put(this.slots[i]);
            }
            for (int i = 0; i < set2.size; i++)
            {
                if (!object.Equals(set2.slots[i], default(T))) res.Put(set2.slots[i]);
            }
            return res;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            // разница текущего множества и set2
            PowerSet<T> res = new PowerSet<T>();
            for(int i = 0; i < size; i++)
            {
                if (!object.Equals(this.slots[i], default(T)) && !set2.Get(this.slots[i])) res.Put(this.slots[i]);
            }
            return res;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            // возвращает true, если set2 есть
            // подмножество текущего множества,
            // иначе false
            if (set2.Size() > Size()) return false;
            for (int i = 0; i < set2.size; i++)
            {
                if (!object.Equals(set2.slots[i], default(T)) && !this.Get(set2.slots[i])) return false;
            }
            return true;
        }

        public bool Equals(PowerSet<T> set2)
        {
            // возвращает true, 
            // если set2 равно текущему множеству,
            // иначе false
            if (set2.Size() != Size()) return false;
            return IsSubset(set2);
        }

        public int HashFun(T value, int i)
        {
            // всегда возвращает корректный индекс слота
            if (value == null) throw new Exception("Неверное занчение");
            int res = 0;
            string key = value.ToString();
            foreach (var item in key)
            {
                res += (int)item;
            }
            int h1 = res % size;
            int h2 = 1 + (res % (size - 1));
            return (h1 + i * h2) % size;
        }
        public int SeekSlot(T value)
        {
            // находит индекс пустого слота для значения
            int idx = HashFun(value, 0);
            if (object.Equals(slots[idx], default(T)) && is_deleted[idx] == false) return idx; // если слот пустой и в нем не было до этого значений
            if (!object.Equals(slots[idx], default(T)) && value.Equals(slots[idx])) return -1; // если слот не пустой и значение дублируется
            // если есть коллизия, значит есть шанс, что данное значение уже во множестве
            int first_idx = -1;
            if (is_deleted[idx] == true) first_idx = idx; // если слот пуст, но значение из него было удалено, значит возможно дубликаты дальше
            for (int i = 1; i < size; i++)
            {
                idx = HashFun(value, i);
                if (is_deleted[idx] == true && first_idx == -1) first_idx = idx;
                if (!object.Equals(slots[idx], default(T)) && value.Equals(slots[idx])) return -1; // если слот не пустой и значение дублируется
                if (object.Equals(slots[idx], default(T)) && is_deleted[idx] == false) return first_idx != -1? first_idx : idx; // если слот пустой и значения там не было
            }
            return first_idx;
        }
        private int FindKeyIndex(T value)
        {
            // находит индекс значения
            for (int i = 0; i < size; i++)
            {
                int idx = HashFun(value, i);
                if (object.Equals(slots[idx], default(T)) && is_deleted[idx] == false) return -1; // если слот пуст и в нем никогда не было значений, дальше искать смысла нет
                if (!object.Equals(slots[idx], default(T)) && value.Equals(slots[idx])) return idx;
            }
            return -1;
        }

    }
}
