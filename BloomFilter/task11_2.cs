using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class Solution
    {


        // Задание 2. Напишите алгоритм слияния нескольких фильтров Блюма (одинакового размера и с одинаковым набором хэш-функций).
        // Как изменится вероятность ложного срабатывания для итогового фильтра?
        public static BloomFilter BloomAddition(List<BloomFilter> filters)
        {
            BloomFilter res = new BloomFilter(filters[0].filter_len);
            foreach (BloomFilter filter in filters)
            {
                res.bloom_filter = res.bloom_filter | filter.bloom_filter;
            }
            return res;
        }
        /* Решение заключается в побитовом сравнении двух фильтров, делаем операцию побитового сложения и получаем в результате фильтр, который содержит все возможные элементы из двух фильтров.
         * Вероятность ложного срабатывания увеличится, ведь увеличится количество единиц в битовой маске.
         * Сложность по времени O(n) где n удет количество фильтров, а не элементов в фильтре, потому что операция сложения моментальна.
         * Сложность по памяти O(1) создаем новый фильтр.
         */


        // Задание 4. Подумайте (и попробуйте реализовать), каким может быть алгоритм, который анализирует конфигурацию фильтра Блюма и пытается, насколько возможно, восстановить исходное множество.
        public static List<string> GetBloomValues(BloomFilter filter, List<string> dictionary)
        {
            List<string> res =  new List<string>();
            foreach(string word in dictionary)
            {
                if (filter.IsValue(word)) res.Add(word);
            }
            return res;
        }
        /* Вариант который мне пришел в голову, это имея возможные входные данные, мы можем подать их в фильтр для проверки наличия и попытаться исходя из этого восстановаить множество значений фильтра
         * Сложность по времени O(n) где n длина словаря с возможными данными фильтра.
         * Сложность по памяти O(n) создаем список восстановленного множества.
         */
    }


    // Задание 3.  Реализуйте фильтр Блюма, предусматривающий удаление элементов.
    public class BloomFilterWithDelete
    {
        public int filter_len;
        public int[] bloom_filter;
        public BloomFilterWithDelete(int f_len)
        {
            filter_len = f_len;
            bloom_filter = new int[f_len];
        }

        // хэш-функции
        public int Hash1(string str1)
        {
            int res = 0;
            int hash1_rand = 17;
            // 17
            for (int i = 0; i < str1.Length; i++)
            {
                res = (res * hash1_rand + str1[i]) % filter_len;
            }
            // реализация ...
            return res;
        }
        public int Hash2(string str1)
        {
            // 223
            // реализация ...
            int res = 0;
            int hash1_rand = 223;
            // 17
            for (int i = 0; i < str1.Length; i++)
            {
                res = (res * hash1_rand + str1[i]) % filter_len;
            }
            // реализация ...
            return res;
        }

        public void Add(string str1)
        {
            // добавляем строку str1 в фильтр
            bloom_filter[Hash1(str1)]++;
            bloom_filter[Hash2(str1)]++;
        }

        public bool IsValue(string str1)
        {
            // проверка, имеется ли строка str1 в фильтре
            if (bloom_filter[Hash1(str1)] > 0 && bloom_filter[Hash2(str1)] > 0) return true;
            return false;
        }

        public bool Delete(string str1)
        {
            if(IsValue(str1))
            {
                bloom_filter[Hash1(str1)]--;
                bloom_filter[Hash2(str1)]--;
                return true;
            }
            return false;
        }

        /* Так как если работать с битами, не получится сделать счетчик количества повторений индекса хэша, то пришлось заменить битовое представление на обычный массив.
         * Это все равно не панацея, ведь при ложном срабатывании удалятся биты реально существующих значений и мы потеряем значение.
         * Сложность по времени для функции удаления O(1), просто уменьшаем значение индекса хэша в массиве.
         * Сложность по памяти для функции удаления O(1), ничего не создаем.
         */
    }


    /*  Рекомендации по решению задач задания 9.
 *  
 * 
 * 
 *  5. Словарь с использованием упорядоченного списка по ключу.
 *  Сделал не как в эталонном решении, создал один упорядоченный список, отдельно создал тип для хранения ключа и значения. 
 *  Немного переопределил методы сравнения в списке, чтобы он работал с новым типом и корректно сравнивал ключи.
 */
}
