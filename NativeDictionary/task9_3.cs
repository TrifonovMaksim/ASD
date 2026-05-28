using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Tests
    {
        public static void Put1()
        {
            NativeDictionary<int> test = new NativeDictionary<int>(17);
            test.Put(0.ToString(), 123);
            test.Put(1.ToString(), 12);
            test.Put(2.ToString(), 124);
            test.Put(3.ToString(), 121);
            Console.WriteLine(test.Get(2.ToString()) == 124? "Тест Put1 пройден" : "Тест Put1 не пройден");
        }

        public static void PutGet()
        {
            NativeDictionary<int> test = new NativeDictionary<int>(17);
            test.Put(0.ToString(), 123);
            test.Put(0.ToString(), 12);
            test.Put(0.ToString(), 124);
            test.Put(0.ToString(), 121);
            Console.WriteLine(test.Get(0.ToString()) == 121 ? "Тест PutGet пройден" : "Тест PutGet не пройден");
        }

        public static void IsKey1()
        {
            NativeDictionary<int> test = new NativeDictionary<int>(17);
            test.Put(0.ToString(), 123);
            test.Put(1.ToString(), 12);
            test.Put(2.ToString(), 124);
            test.Put(3.ToString(), 121);
            Console.WriteLine(test.IsKey(1.ToString())? "Тест IsKey1 пройден" : "Тест IsKey1 не пройден");
        }

        public static void IsKey2()
        {
            NativeDictionary<int> test = new NativeDictionary<int>(17);
            test.Put(0.ToString(), 123);
            test.Put(1.ToString(), 12);
            test.Put(2.ToString(), 124);
            test.Put(3.ToString(), 121);
            Console.WriteLine(!test.IsKey(4.ToString()) ? "Тест IsKey2 пройден" : "Тест IsKey2 не пройден");
        }

        public static void Get1()
        {
            NativeDictionary<int> test = new NativeDictionary<int>(17);
            test.Put(0.ToString(), 123);
            test.Put(1.ToString(), 12);
            test.Put(2.ToString(), 124);
            test.Put(3.ToString(), 121);
            Console.WriteLine(test.Get(1.ToString()) == 12 ? "Тест Get1 пройден" : "Тест Get1 не пройден");
        }

        public static void Get2()
        {
            NativeDictionary<int> test = new NativeDictionary<int>(17);
            test.Put(0.ToString(), 123);
            test.Put(1.ToString(), 12);
            test.Put(2.ToString(), 124);
            test.Put(3.ToString(), 121);
            Console.WriteLine(test.Get(6.ToString()) == default(int) ? "Тест Get2 пройден" : "Тест Get2 не пройден");
        }

        public static void PutOrderedList()
        {
            DictionaryOnOrderedList<int> test = new DictionaryOnOrderedList<int>();
            test.Put(0.ToString(), 123);
            test.Put(1.ToString(), 12);
            test.Put(2.ToString(), 124);
            test.Put(3.ToString(), 121);
            Console.WriteLine(test.Find(2.ToString()) == 124  ? "Тест PutOrderedList пройден" : "Тест PutOrderedList не пройден");
        }

        public static void PutOrderedList1()
        {
            DictionaryOnOrderedList<int> test = new DictionaryOnOrderedList<int>();
            test.Put(0.ToString(), 123);
            test.Put(0.ToString(), 12);
            test.Put(0.ToString(), 124);
            test.Put(0.ToString(), 121);
            Console.WriteLine(test.Find(0.ToString()) == 121 ? "Тест PutOrderedList1 пройден" : "Тест PutOrderedList1 не пройден");
        }

        public static void OrderedListFind1()
        {
            DictionaryOnOrderedList<int> test = new DictionaryOnOrderedList<int>();
            test.Put(0.ToString(), 123);
            test.Put(1.ToString(), 12);
            test.Put(2.ToString(), 124);
            test.Put(3.ToString(), 121);
            Console.WriteLine(test.Find(1.ToString()) == 12 ? "Тест OrderedListFind1 пройден" : "Тест OrderedListFind1 не пройден");
        }

        public static void OrderedListFind2()
        {
            DictionaryOnOrderedList<int> test = new DictionaryOnOrderedList<int>();
            test.Put(0.ToString(), 123);
            test.Put(1.ToString(), 12);
            test.Put(2.ToString(), 124);
            test.Put(3.ToString(), 121);
            Console.WriteLine(test.Find(4.ToString()) == default(int)? "Тест OrderedListFind2 пройден" : "Тест OrderedListFind2 не пройден");
        }

        public static void OrderedListDelete1()
        {
            DictionaryOnOrderedList<int> test = new DictionaryOnOrderedList<int>();
            test.Put(0.ToString(), 123);
            test.Put(1.ToString(), 12);
            test.Put(2.ToString(), 124);
            test.Put(3.ToString(), 121);
            Console.WriteLine(test.Delete(1.ToString()) == 0 ? "Тест OrderedListDelete1 пройден" : "Тест OrderedListDelete1 не пройден");
        }

        public static void OrderedListDelete2()
        {
            DictionaryOnOrderedList<int> test = new DictionaryOnOrderedList<int>();
            test.Put(0.ToString(), 123);
            test.Put(1.ToString(), 12);
            test.Put(2.ToString(), 124);
            test.Put(3.ToString(), 121);
            Console.WriteLine(test.Delete(4.ToString()) == -1 ? "Тест OrderedListDelete2 пройден" : "Тест OrderedListDelete2 не пройден");
        }

        public static void BitPut1()
        {
            BitDictionary<int> test = new BitDictionary<int>();
            test.Put(0, 123);
            test.Put(1, 12);
            test.Put(2, 124);
            test.Put(3, 121);
            Console.WriteLine(test.Get(2) == 124 ? "Тест BitPut1 пройден" : "Тест BitPut1 не пройден");
        }

        public static void BitPutGet()
        {
            BitDictionary<int> test = new BitDictionary<int>();
            test.Put(0, 123);
            test.Put(0, 12);
            test.Put(0, 124);
            test.Put(0, 121);
            Console.WriteLine(test.Get(0) == 121 ? "Тест BitPutGet пройден" : "Тест BitPutGet не пройден");
        }

        public static void BitIsKey1()
        {
            BitDictionary<int> test = new BitDictionary<int>();
            test.Put(0, 123);
            test.Put(1, 12);
            test.Put(2, 124);
            test.Put(3, 121);
            Console.WriteLine(test.IsKey(1) ? "Тест BitIsKey1 пройден" : "Тест BitIsKey1 не пройден");
        }

        public static void BitIsKey2()
        {
            BitDictionary<int> test = new BitDictionary<int>();
            test.Put(0, 123);
            test.Put(1, 12);
            test.Put(2, 124);
            test.Put(3, 121);
            Console.WriteLine(!test.IsKey(4) ? "Тест BitIsKey2 пройден" : "Тест BitIsKey2 не пройден");
        }

        public static void BitGet1()
        {
            BitDictionary<int> test = new BitDictionary<int>();
            test.Put(0, 123);
            test.Put(1, 12);
            test.Put(2, 124);
            test.Put(3, 121);
            Console.WriteLine(test.Get(1) == 12 ? "Тест BitGet1 пройден" : "Тест BitGet1 не пройден");
        }

        public static void BitGet2()
        {
            BitDictionary<int> test = new BitDictionary<int>();
            test.Put(0, 123);
            test.Put(1, 12);
            test.Put(2, 124);
            test.Put(3, 121);
            Console.WriteLine(test.Get(6) == default(int) ? "Тест BitGet2 пройден" : "Тест BitGet2 не пройден");
        }

        public static void Main(string[] args)
        {
            Put1();
            PutGet();
            IsKey1();
            IsKey2();
            Get1();
            Get2();
            PutOrderedList();
            PutOrderedList1();
            OrderedListFind1();
            OrderedListFind2();
            OrderedListDelete1();
            OrderedListDelete2();
            BitGet1();
            BitGet2();
            BitIsKey1();
            BitIsKey2();
            BitPut1();
            BitPutGet();
        }
    }
}