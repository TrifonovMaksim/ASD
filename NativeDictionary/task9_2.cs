using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures
{

    // Задание 5. Реализуйте словарь с использованием упорядоченного списка по ключу для оптимизации производительности поиска.
    public class DictionaryOnOrderedList<T>
    {
        public OrderedListIndex<T> slots;

        public DictionaryOnOrderedList()
        {
            slots = new OrderedListIndex<T>();
        }

        public void Put(string key, T value)
        {
            // записывает значение в список
            KeyValue<T> item = new KeyValue<T>(key, value);
            slots.Add(item);
        }

        public int Delete(string key)
        {
            int? idx = slots.Find_Index(key);
            if (idx == null)
            {
                Console.WriteLine("Такого ключа нет в словаре");
                return -1;
            }
            slots.list.RemoveAt((int)idx);
            return 0;
        }

        public T Find(string key)
        {
            T res;
            int? idx = slots.Find_Index(key);
            if (idx == null)
            {
                Console.WriteLine("Такого ключа нет в словаре");
                return default(T);
            }
            return slots.list[(int)idx].value;
        }

    }

    /* Сделал на основе связанного списка из прошлых заданий. Для этого сделал тип данных кей вэлью, который лежит в списке, а там уже мы можем обращаться к ключу и значению. Они получаются у нас связанные, а не в двух разных массивах или списках.
     * Сложность по времени для вставки O(n) идем с начала списка до конца ища нужное место, удаление O(logN) используется поиск индекса через бинарный поиск, для поиска так же O(logN).
     * Сложность по памяти для каждого метода O(1), не создаем ничего дополнительного в памяти.
     */




    // Задание 6. Создайте словарь, в котором ключи представлены битовыми строками фиксированной длины.
    public class BitDictionary<T>
    {
        public int size;
        long slots;
        public T[] values;

        public BitDictionary()
        {
            size = 64;
            values = new T[size];
        }
        public void Put(int key, T value)
        {
            // гарантированно записываем 
            // значение value по ключу key
            if (IsKey(key))
            {
                values[key] = value;
                return;
            }
            values[key] = value;
            long a = 1;
            a = a << key;
            slots = slots | a;
        }

        public T Get(int key)
        {
            // возвращает value для key, 
            // или null если ключ не найден
            if (!IsKey(key)) return default(T);
            return values[key];

        }

        public int Delete(int key)
        {
            if (!IsKey(key))
            {
                Console.WriteLine("Ключа нет в словаре");
                return -1;
            }
            long a = 1;
            a = a << key;
            slots = slots & ~a;
            return 0;
        }

        public bool IsKey(int key)
        {
            if (((slots >> key) & 1) == 1) return true;
            return false;
        }
    
    }

    /* Не совсем понял, как надо реализовывать. Единственное, что пришло в голову, как ускорить битовыми операциями поиск, это создать переменную, вместо массива слотов и там побитово работать с ней.
     * Так как битовые операции быстрее операций с обычными типами данных.
     * По времени сложность для всех операций получилась O(1).
     * По памяти O(n), но n у меня как бы фиксированный 64.
     */


    public class KeyValue<T>
    {
        public string key;
        public T value;
        public KeyValue(string _key, T _value)
        {
            key = _key;
            value = _value;
        }
    }
    public class OrderedListIndex<T>
    {
        public List<KeyValue<T>> list;
        public bool _ascending;
        public OrderedListIndex(bool asc = true)
        {
            _ascending = asc;
            list = new List<KeyValue<T>>();
        }

        public int Compare(string v1, string v2)
        {
            int result = 0;

                // версия для лексикографического сравнения строк
                string a = ((string)((object)v1)).Trim();
                string b = ((string)((object)v2)).Trim();
                int res = a.CompareTo(b);
                if (res > 0) result = 1;
                if (res < 0) result = -1;

                return result;
           
        }

        public void Add(KeyValue<T> value)
        {
            // автоматическая вставка value 
            // в нужную позицию
            if (value == null) throw new ArgumentNullException("Пустое значение");
            if (list.Count == 0)
            {
                list.Add(value);
                return;
            }

            int direction = _ascending ? -1 : 1;
            if (Compare(value.key, list.First().key) == direction)
            {
                list.Insert(0, value);
                return;
            }
            if (Compare(value.key, list.Last().key) == -direction)
            {
                list.Add(value);
                return;
            }
            for (int i = 0; i < list.Count(); i++)
            {
                if (Compare(value.key, list[i].key) == direction || Compare(value.key, list[i].key) == 0)
                {
                    list.Insert(i, value);
                    return;
                }
            }
            return;
        }

        public int? Find_Index(string key)
        {
            if (list.Count() == 0) return null;
            if (Compare(list.First().key, key) == 0) return 0;
            if (Compare(list.Last().key, key) == 0) return list.Count() - 1;
            int min_index = 0;
            int max_index = list.Count() - 1;
            int direction = _ascending ? -1 : 1;
            while (min_index <= max_index)
            {
                int middle = (max_index + min_index) / 2;
                if (Compare(list[middle].key, key) == 0)
                {
                    return middle;
                }
                if (Compare(list[middle].key, key) == -1)
                {
                    min_index = middle + -direction;
                    continue;
                }
                if (Compare(list[middle].key, key) == +1)
                {
                    max_index = middle - direction;
                    continue;
                }
            }
            return null;
        }
    }
    /*  Рекомендации по решению задач задания 7.
     *  
     *  9. Слияние двух упорядоченных списков в один.
     *  Рефлексия по прошлому заданию. Сделал, как в эталонном решении, просто производим слияние двух списков в один через цикл, а так как они оба уже упорядоченные, предварительно сортировать их не надо.
     *  
     *  
     *  10. Проверка наличия заданного упорядоченного под-списка в текущем списке.
     *  Рефлексия по прошлому заданию. Сделал почти, как в эталонном решении, так же если нахожу возможное начало последовательности включаю флаг и иду по списку, так же если флаг фолс прекращаю текущую итерацию проверки подсписка и иду дальше по основному списку
     *  в поиске первого элемента из подсписка, тоесть возможного его начала в списке. Если нахожу элемент меньший или больший в зависимости от того список возростающий или убывающий, то прерываю поиск в целом. Единственное
     *  нет оптимизации по проверке длины оставшегося списка.
     *  
     *  11. Ищем наиболее часто встречающееся значение в списке.
     *  Рефлексия по прошлому заданию. Сделал почти, как в эталонном решении, только сравнивал не текущий и предыдущий, а текущий и следующий.
     *  
     *  12. Индекс заданного элемента в списке за O(log N).
     *  Рефлексия по прошлому заданию. Сделал, как в эталонном решении, через бинарный поиск, для этого создал класс, на основе встроенного списка, чтобы работать с индексами.
     */


}