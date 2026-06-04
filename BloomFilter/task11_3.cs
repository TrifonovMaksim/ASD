using System;
using System.Collections.Generic;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace AlgorithmsDataStructures
{
    public class Tests
    {
        public static void Add1()
        {
            BloomFilter test = new BloomFilter(32);
            test.Add("0123456789");
            Console.WriteLine(test.bloom_filter != 0 ? "Тест Add1 пройден" : "Тест Add1 не пройден");
        }
        public static void IsValue1()
        {
            BloomFilter test = new BloomFilter(32);
            test.Add("0123456789");
            Console.WriteLine(test.IsValue("0123456789") ? "Тест IsValue1 пройден" : "Тест IsValue1 не пройден");
        }

        public static void IsValue2()
        {
            BloomFilter test = new BloomFilter(32);
            test.Add("0123456789");
            Console.WriteLine(!test.IsValue("0000000000") ? "Тест IsValue2 пройден" : "Тест IsValue2 не пройден");
        }

        public static void IsValue3()
        {
            BloomFilter test = new BloomFilter(32);
            test.Add("0123456789");
            test.Add("1234567890");
            test.Add("2345678901");
            test.Add("3456789012");
            test.Add("4567890123");
            test.Add("5678901234");
            test.Add("6789012345");
            test.Add("7890123456");
            test.Add("8901234567");
            test.Add("9012345678");
            Console.WriteLine(test.IsValue("0123456789") ? "Тест IsValue3 пройден" : "Тест IsValue3 не пройден");
        }

        public static void IsValue4()
        {
            BloomFilter test = new BloomFilter(32);
            test.Add("0123456789");
            test.Add("1234567890");
            test.Add("2345678901");
            test.Add("3456789012");
            test.Add("4567890123");
            test.Add("5678901234");
            test.Add("6789012345");
            test.Add("7890123456");
            test.Add("8901234567");
            test.Add("9012345678");
            Console.WriteLine(!test.IsValue("0011223344") ? "Тест IsValue4 пройден" : "Тест IsValue4 не пройден");
        }

        public static void BloomAddition1()
        {
            BloomFilter test1 = new BloomFilter(32);
            BloomFilter test2 = new BloomFilter(32);
            test1.Add("0123456789");
            test1.Add("1234567890");
            test1.Add("2345678901");
            test1.Add("3456789012");
            test1.Add("4567890123");
            test2.Add("5678901234");
            test2.Add("6789012345");
            test2.Add("7890123456");
            test2.Add("8901234567");
            test2.Add("9012345678");
            BloomFilter res = Solution.BloomAddition(new List<BloomFilter> { test1, test2});
            Console.WriteLine(res.IsValue("0123456789") && res.IsValue("9012345678") ? "Тест BloomAddition1 пройден" : "Тест BloomAddition1 не пройден");
        }

        public static void BloomAddition2()
        {
            BloomFilter test1 = new BloomFilter(32);
            BloomFilter test2 = new BloomFilter(32);
            BloomFilter test3 = new BloomFilter(32);
            test1.Add("0123456789");
            test1.Add("1234567890");
            test2.Add("2345678901");
            test2.Add("3456789012");
            test2.Add("4567890123");
            test3.Add("5678901234");
            test3.Add("6789012345");
            test3.Add("7890123456");
            test3.Add("8901234567");
            test3.Add("9012345678");
            BloomFilter res = Solution.BloomAddition(new List<BloomFilter> { test1, test2, test3 });
            Console.WriteLine(res.IsValue("0123456789") && res.IsValue("3456789012") && res.IsValue("9012345678") ? "Тест BloomAddition2 пройден" : "Тест BloomAddition2 не пройден");
        }

        public static void BloomAddition3()
        {
            BloomFilter test1 = new BloomFilter(32);
            BloomFilter test2 = new BloomFilter(32);
            test1.Add("0123456789");
            test2.Add("1234567890");
            BloomFilter res = Solution.BloomAddition(new List<BloomFilter> { test1, test2 });
            Console.WriteLine(!res.IsValue("000000000") ? "Тест BloomAddition3 пройден" : "Тест BloomAddition3 не пройден");
        }
        public static void AddDelete1()
        {
            BloomFilterWithDelete test = new BloomFilterWithDelete(32);
            test.Add("0123456789");
            Console.WriteLine(test.bloom_filter[test.Hash1("0123456789")] > 0 ? "Тест AddDelete1 пройден" : "Тест AddDelete1 не пройден");
        }

        public static void AddDelete2()
        {
            BloomFilterWithDelete test = new BloomFilterWithDelete(32);
            test.Add("0123456789");
            test.Add("1234567890");
            test.Add("2345678901");
            test.Add("3456789012");
            test.Add("4567890123");
            test.Add("5678901234");
            test.Add("6789012345");
            test.Add("7890123456");
            test.Add("8901234567");
            test.Add("9012345678");
            Console.WriteLine(test.bloom_filter[test.Hash1("0123456789")] > 0 && test.bloom_filter[test.Hash1("7890123456")] > 0 ? "Тест AddDelete2 пройден" : "Тест AddDelete2 не пройден");
        }

        public static void IsValueDelete1()
        {
            BloomFilterWithDelete test = new BloomFilterWithDelete(32);
            test.Add("0123456789");
            Console.WriteLine(test.IsValue("0123456789") ? "Тест IsValueDelete1 пройден" : "Тест IsValueDelete1 не пройден");
        }

        public static void IsValueDelete2()
        {
            BloomFilterWithDelete test = new BloomFilterWithDelete(32);
            test.Add("0123456789");
            Console.WriteLine(!test.IsValue("0000000000") ? "Тест IsValueDelete2 пройден" : "Тест IsValueDelete2 не пройден");
        }

        public static void IsValueDelete3()
        {
            BloomFilterWithDelete test = new BloomFilterWithDelete(32);
            test.Add("0123456789");
            test.Add("1234567890");
            test.Add("2345678901");
            test.Add("3456789012");
            test.Add("4567890123");
            test.Add("5678901234");
            test.Add("6789012345");
            test.Add("7890123456");
            test.Add("8901234567");
            test.Add("9012345678");
            Console.WriteLine(test.IsValue("0123456789") ? "Тест IsValueDelete3 пройден" : "Тест IsValueDelete3 не пройден");
        }

        public static void IsValueDelete4()
        {
            BloomFilterWithDelete test = new BloomFilterWithDelete(32);
            test.Add("0123456789");
            test.Add("1234567890");
            test.Add("2345678901");
            test.Add("3456789012");
            test.Add("4567890123");
            test.Add("5678901234");
            test.Add("6789012345");
            test.Add("7890123456");
            test.Add("8901234567");
            test.Add("9012345678");
            Console.WriteLine(!test.IsValue("0011223344") ? "Тест IsValueDelete4 пройден" : "Тест IsValueDelete4 не пройден");
        }

        public static void Delete1()
        {
            BloomFilterWithDelete test = new BloomFilterWithDelete(32);
            test.Add("0123456789");
            Console.WriteLine(test.Delete("0123456789") && !test.IsValue("0123456789") ? "Тест Delete1 пройден" : "Тест Delete1 не пройден");
        }

        public static void Delete2()
        {
            BloomFilterWithDelete test = new BloomFilterWithDelete(32);
            test.Add("0123456789");
            test.Add("1234567890");
            test.Delete("0123456789");
            Console.WriteLine(!test.IsValue("0123456789") && test.IsValue("1234567890") ? "Тест Delete2 пройден" : "Тест Delete2 не пройден");
        }

        public static void Delete3()
        {
            BloomFilterWithDelete test = new BloomFilterWithDelete(32);
            test.Add("0123456789");
            Console.WriteLine(!test.Delete("0000000000") ? "Тест Delete3 пройден" : "Тест Delete3 не пройден");
        }


        public static void GetBloomValues1()
        {
            BloomFilter test = new BloomFilter(32);
            test.Add("0123456789");
            test.Add("4567890123");
            test.Add("8901234567");
            List<string> dictionary = new List<string> {"0123456789", "1234567890", "2345678901", "3456789012", "4567890123","5678901234", "6789012345", "7890123456", "8901234567", "9012345678"};
            List<string> res = Solution.GetBloomValues(test, dictionary);
            Console.WriteLine(res.Contains("0123456789") && res.Contains("4567890123") && res.Contains("8901234567") ? "Тест GetBloomValues1 пройден" : "Тест GetBloomValues1 не пройден");
        }

        public static void GetBloomValues2()
        {
            BloomFilter test = new BloomFilter(32);
            test.Add("000000000");
            test.Add("111111111");
            test.Add("222222222");
            test.Add("333333333");
            test.Add("444444444");
            test.Add("555555555");
            test.Add("666666666");
            test.Add("777777777");
            test.Add("888888888");
            test.Add("112233445");
            List<string> dictionary = new List<string> {"0123456789", "1234567890", "2345678901", "3456789012", "4567890123", "5678901234", "6789012345", "7890123456", "8901234567", "9012345678"};
            List<string> res = Solution.GetBloomValues(test, dictionary);
            Console.WriteLine(res.Count == 0 ? "Тест GetBloomValues2 пройден" : "Тест GetBloomValues2 не пройден");
        }
        public static void Main(string[] args)
        {
            Add1();
            IsValue1();
            IsValue2();
            IsValue3();
            IsValue4();
            BloomAddition1();
            BloomAddition2();
            BloomAddition3();
            AddDelete1();
            AddDelete2();
            IsValueDelete1();
            IsValueDelete2();
            IsValueDelete3();
            IsValueDelete4();
            Delete1();
            Delete2();
            Delete3();
            GetBloomValues1();
            GetBloomValues2();
        }
    }
}