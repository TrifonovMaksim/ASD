using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        public int bloom_filter;
        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            // создаём битовый массив длиной f_len ...
            bloom_filter = 0;
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
            int mask = 0;
            mask = (mask | (1 << Hash1(str1))) | (mask | (1 << Hash2(str1)));
            bloom_filter = bloom_filter | mask;
        }

        public bool IsValue(string str1)
        {
            // проверка, имеется ли строка str1 в фильтре
            int mask = 0;
            mask = (mask | (1 << Hash1(str1))) | (mask | (1 << Hash2(str1)));
            if ((bloom_filter & mask) == mask) return true;
            return false;
        }
    }
}