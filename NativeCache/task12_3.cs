using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Tests     
        {

        public static void Full1()
        {
            NativeCache<string> test = new NativeCache<string>(5);
            test.Put("a", "1");
            test.Put("b", "2");
            test.Put("c", "3");
            test.Put("d", "4");
            test.Put("e", "5");
            test.Put("f", "6");
            test.Put("g", "7");
            Console.WriteLine(test.IsKey("g") && test.size == 5 ? "Тест Full1 пройден" : "Тест Full1 не пройден");
        }
        public static void Full2()
        {
            NativeCache<string> test = new NativeCache<string>(5);
            test.Put("a", "1");
            test.Put("b", "2");
            test.Put("c", "3");
            test.Put("d", "4");
            test.Put("e", "5");
            test.Get("b");
            test.Get("c");
            test.Get("d");
            test.Get("e");
            test.Put("f", "6");
            Console.WriteLine(!test.IsKey("a") && test.IsKey("f") ? "Тест Full2 пройден" : "Тест Full2 не пройден");
        }

        public static void Full3()
        {
            NativeCache<string> test = new NativeCache<string>(5);
            test.Put("abcde", "1");
            test.Put("eabcd", "2");
            test.Put("deabc", "3");
            test.Put("cdeab", "4");
            test.Put("bcdea", "5");
            test.Put("f", "6");
            test.Put("g", "7");
            Console.WriteLine(test.IsKey("g") && test.size == 5 ? "Тест Full3 пройден" : "Тест Full3 не пройден");
        }


        public static void Main(string[] args)
        {
            Full1();
            Full2();
            Full3();
        }
    }
}
