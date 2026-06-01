using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace AlgorithmsDataStructures
{
    public class Solution
    {
        public class PowerSetSolution<T> : PowerSet<T>
        {

            // Задание 4. Добавьте метод, реализующий декартово произведение множеств. Возвращайте множество из пар соответствий.
            public PowerSetSolution() : base() { }
            public static PowerSetSolution<string> DecartMultiply(PowerSetSolution<T> set1, PowerSetSolution<T> set2)
            {
                PowerSetSolution<string> res = new PowerSetSolution<string>();
                for (int i = 0; i < set1.size; i++)
                {
                    if (!object.Equals(set1.slots[i], default(T)))
                    {
                        for (int j = 0; j < set2.size; j++)
                        {
                            if (!object.Equals(set2.slots[j], default(T)))
                            {
                                res.Put(set1.slots[i].ToString() + "," + set2.slots[j].ToString());
                            }
                        }
                    }
                }
                return res;
            }

            /* Во внешнем цикле идем по элементам первого множества, во внутреннем по элементам второго, соответственно получаем все возможные пары и кладем их в результируещее множество.\
             * Сложность по времени O(n^2) вложенный проход по двум множествам.
             * Сложность по памяти O(n) создаем новое множество.
             */
        }

        // Задание 5. Напишите функцию, которая находит пересечение любых трёх и более множеств (принимает количество множеств >= 3 в качестве списка).

        public static PowerSet<T> MultiIntersection<T>(List<PowerSet<T>> lst)
        {
            // пересечение множеств
            PowerSet<T> res = lst[0];
            for (int i = 1; i < lst.Count; i++)
            {
                res = res.Intersection(lst[i]);
            }

            return res;
        }

        /* Просто вызываю пересечение всех множеств по очереди.
         * Сложность по времени O(n), пересечение для пары происходит O(n).
         * Сложность по памяти O(n), создаем новое результирующее множество.
         */
    }


    // Задание 6. Реализуйте мульти-множество (Bag), в котором каждый элемент может присутствовать несколько раз.
    // Добавьте методы добавления элементов, удаления одного экземпляра элемента и получения списка всех элементов с их частотами (сколько раз встречаются).
    public class Bag<T>
    {
        public int size;
        public T[] slots;
        public int count;
        public int[] count_array;
        public bool[] is_deleted;

        public Bag()
        {
            // ваша реализация хранилища
            size = 20000;
            slots = new T[size];
            count_array = new int[size];
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
            int idx = FindKeyIndex(value);
            if (idx == -1)
            {
                idx = SeekSlot(value);
                slots[idx] = value;
                count_array[idx]++;
                count++;
                return;
            }
            count_array[idx]++;
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
            // возвращает true если значение value уменьшено
            // иначе false
            int idx = FindKeyIndex(value);
            if (idx != -1)
            {
                count_array[idx]--;
                count--;
                if (count_array[idx] == 0)
                {
                    is_deleted[idx] = true;
                    slots[idx] = default(T);
                }
                if (count == 0) is_deleted = new bool[size];
                return true;
            }
            return false;
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
                if (object.Equals(slots[idx], default(T)) && is_deleted[idx] == false) return first_idx != -1 ? first_idx : idx; // если слот пустой и значения там не было
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

        public List<string> GetAll()
        {
            // возвращает список со всеми значениями и их частотой
            List<string> lst = new List<string>();
            for (int i = 0; i < size; i++)
            {
                if (!object.Equals(slots[i], default(T)))
                {
                    lst.Add(slots[i].ToString() + "," + count_array[i].ToString());
                }
            }
            return lst;
        }
    }
    /* Немного поправил реализацию обычного множества, добавил массив, в котором храним частоту элементов. Теперь сначала при добавлении проверяяем есть ли данный элемент во множестве и исходя из рехультата,
     * либо увеличиваем его частоту или добавляем его во множество. При удалении, уменьшается частота, если частота равна 0, значит элемент полностью удален. При желании с небольшой модификацией текущего метода удаления,
     * можно легко реализовать метод полного удаления элемента.
     * Сложность по времени увеличилась, если мы добавляем новый элемент, потому что чтобы проверить его наличие надо пройти по всему списку и чтобы найти для него слот, тоже в худшем случае надо пройти по всему списку, другие методы по сложности не изменились
     * O(n).
     * Сложность по памяти для GetAll O(n) создаем новый список.
     */




/*  Рекомендации по решению задач задания 8.
 *  
 * 
 * 
 * 3. Динамическая хэш-таблица.
 *  Сделал почти, как в эталонном решении, только без геттера, а просто через параметры конструктора. Задал минимальный размер 17, и расширение производится только на простое число. При реаллокации, естественно перехэшировал все имеющиеся значения.
 *  Единственное, у меня расширение происходит при полном запонении, а не при 80%.
 *  
 *  
 * 5. ddos хэш-таблицы и соль.
 *  Не додумался, как сделать динамическую соль. Не понял, как при случайной соли, потом правильно, так же к нужному значению находить эту случайную соль. Сейчас изучил, и нашел, что соль хранится отдельно и ее не надо знать для поиска значения.
 *  При статической, значения хэшируются в тот же результат, поэтому сделал модификацию хэш функции.
 */
}
