using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AlgorithmsDataStructures
{
    public class Tests
    {
        public static void HashFun1()
        {
            HashTable test = new HashTable(17, 3);
            int res1 = test.HashFun("gfdgsdgsdfgsdfgfsdg");
            int res2 = test.HashFun("gfdgsdgsdfgsdfgfsdg");
            int res3 = test.HashFun("gfdgsdgsdfgsdfgfsdg");
            Console.WriteLine( res1 == res2 && res2 == res3 ? "Тест HashFun1 пройден" : "Тест HashFun1 не пройден");
        }

        public static void HashFun2()
        {
            HashTable test = new HashTable(17, 3);
            int res1 = test.HashFun("gfdgsdgsdfgsdg");
            int res2 = test.HashFun("gfdgsdgsdfgsdfgfsdg");
            int res3 = test.HashFun("gfdgsdgsdfgsdfgfsdsdafasdfasfasdfasdfsdafg");
            Console.WriteLine( 0 <= res1 && res1 < test.size && 0 <= res2 && res2 < test.size && 0 <= res3 && res3 < test.size ? "Тест HashFun2 пройден" : "Тест HashFun2 не пройден");
        }

        public static void SeekSlot1()
        {
            HashTable test = new HashTable(17, 3);
            int res1 = test.SeekSlot("gfdgsdgsdfgsdg");
            int res2 = test.SeekSlot("gfdgsdgsdfgsdfgfsdg");
            int res3 = test.SeekSlot("gfdgsdgsdfgsdfgfsdsdafasdfasfasdfasdfsdafg");
            Console.WriteLine(res1 != res2 && res1 != res3 && res3 != res2 ? "Тест SeekSlot1 пройден" : "Тест SeekSlot1 не пройден");
        }

        public static void SeekSlot2()
        {
            HashTable test = new HashTable(0, 3);
            Console.WriteLine(test.SeekSlot("gfdgsdgsdfgsdg") == -1 ? "Тест SeekSlot2 пройден" : "Тест SeekSlot2 не пройден");
        }

        public static void Put1()
        {
            HashTable test = new HashTable(17, 3);
            int res1 = test.Put("gfdgsdgsdfgsdg");
            Console.WriteLine(test.fullnes == 1 ? "Тест Put1 пройден" : "Тест Put1 не пройден");
        }

        public static void Put2()
        {
            HashTable test = new HashTable(5, 3);
            test.Put("gfdgsdgsdfgsdg");
            test.Put("gfdgsdgsdfgsdfg");
            test.Put("gfdgsdgsdfgsdgавппавы");
            test.Put("gfdgsdgsdfgsdfваыпывапg");
            test.Put("gfdgsdgsdfgsdfваыпывафывфаывапg");
            Console.WriteLine(test.Put("dffga") == -1 ? "Тест Put2 пройден" : "Тест Put2 не пройден");
        }

        public static void Find1()
        {
            HashTable test = new HashTable(5, 3);
            test.Put("gfdgsdgsdfgsdg");
            test.Put("gfdgsdgsdfgsdfg");
            test.Put("gfdgsdgsdfgsdgавппавы");
            test.Put("gfdgsdgsdfgsdfваыпывапg");
            test.Put("gfdgsdgsdfgsdfваыпывафывфаывапg");
            Console.WriteLine(test.Find("gfdgsdgsdfgsdg") != -1 ? "Тест Find1 пройден" : "Тест Find1 не пройден");
        }


        public static void Find2()
        {
            HashTable test = new HashTable(5, 3);
            test.Put("gfdgsdgsdfgsdg");
            test.Put("gfdgsdgsdfgsdfg");
            test.Put("gfdgsdgsdfgsdgавппавы");
            test.Put("gfdgsdgsdfgsdfваыпывапg");
            test.Put("gfdgsdgsdfgsdfваыпывафывфаывапg");
            Console.WriteLine(test.Find("g") == -1 ? "Тест Find2 пройден" : "Тест Find2 не пройден");
        }

        public static void DynHashFun1()
        {
            DynHashTable test = new DynHashTable(3);
            int res1 = test.HashFun("gfdgsdgsdfgsdfgfsdg");
            int res2 = test.HashFun("gfdgsdgsdfgsdfgfsdg");
            int res3 = test.HashFun("gfdgsdgsdfgsdfgfsdg");
            Console.WriteLine(res1 == res2 && res2 == res3 ? "Тест DynHashFun1 пройден" : "Тест DynHashFun1 не пройден");
        }

        public static void DynHashFun2()
        {
            DynHashTable test = new DynHashTable(3);
            int res1 = test.HashFun("gfdgsdgsdfgsdg");
            int res2 = test.HashFun("gfdgsdgsdfgsdfgfsdg");
            int res3 = test.HashFun("gfdgsdgsdfgsdfgfsdsdafasdfasfasdfasdfsdafg");
            Console.WriteLine(0 <= res1 && res1 < test.size && 0 <= res2 && res2 < test.size && 0 <= res3 && res3 < test.size ? "Тест DynHashFun2 пройден" : "Тест DynHashFun2 не пройден");
        }

        public static void DynSeekSlot1()
        {
            DynHashTable test = new DynHashTable(3);
            int res1 = test.SeekSlot("gfdgsdgsdfgsdg");
            int res2 = test.SeekSlot("gfdgsdgsdfgsdfgfsdg");
            int res3 = test.SeekSlot("gfdgsdgsdfgsdfgfsdsdafasdfasfasdfasdfsdafg");
            Console.WriteLine(res1 != res2 && res1 != res3 && res3 != res2 ? "Тест DynSeekSlot1 пройден" : "Тест DynSeekSlot1 не пройден");
        }

        public static void DynPut1()
        {
            DynHashTable test = new DynHashTable(3);
            int res1 = test.Put("gfdgsdgsdfgsdg");
            Console.WriteLine(test.size == 17 ? "Тест DynPut1 пройден" : "Тест DynPut1 не пройден");
        }

        public static void DynPut2()
        {
            DynHashTable test = new DynHashTable(3);
            test.Put("gfdgsdgsdfgsdg");
            test.Put("gfdgsdgsdfgsdfg");
            test.Put("gfdgsdgsdfgsdgавппавы");
            test.Put("gfdgsdgsdfgsdfваыпывапg");
            test.Put("gfdgsdgsdfgsdfваыпывафывфаывапg");
            test.Put("gfdgsdgsdfgsdg");
            test.Put("gfdgsdgsdfgsdfg");
            test.Put("gfdgsdgsdfgsdgавппавы");
            test.Put("gfdgsdgsdfgsdfваыпывапg");
            test.Put("gfdgsdgsdfgsdfваыпывафывфаывапg");
            test.Put("gfdgsdgsdfgsdg");
            test.Put("gfdgsdgsdfgsdfg");
            test.Put("gfdgsdgsdfgsdgавппавы");
            test.Put("gfdgsdgsdfgsdfваыпывапg");
            test.Put("gfdgsdgsdfgsdfваыпывафывфаывапg");
            test.Put("gfdgsdgsdfgsdg");
            test.Put("gfdgsdgsdfgsdfg");
            test.Put("gfdgsdgsdfgsdgавппавы");
            test.Put("gfdgsdgsdfgsdfваыпывапg");
            test.Put("gfdgsdgsdfgsdfваыпывафывфаывапg");
            Console.WriteLine(test.size == 37 ? "Тест DynPut2 пройден" : "Тест DynPut2 не пройден");
        }

        public static void DynFind1()
        {
            DynHashTable test = new DynHashTable(3);
            test.Put("gfdgsdgsdfgsdg");
            test.Put("gfdgsdgsdfgsdfg");
            test.Put("gfdgsdgsdfgsdgавппавы");
            test.Put("gfdgsdgsdfgsdfваыпывапg");
            test.Put("gfdgsdgsdfgsdfваыпывафывфаывапg");
            Console.WriteLine(test.Find("gfdgsdgsdfgsdg") != -1 ? "Тест DynFind1 пройден" : "Тест DynFind1 не пройден");
        }


        public static void DynFind2()
        {
            DynHashTable test = new DynHashTable(3);
            test.Put("gfdgsdgsdfgsdg");
            test.Put("gfdgsdgsdfgsdfg");
            test.Put("gfdgsdgsdfgsdgавппавы");
            test.Put("gfdgsdgsdfgsdfваыпывапg");
            test.Put("gfdgsdgsdfgsdfваыпывафывфаывапg");
            Console.WriteLine(test.Find("g") == -1 ? "Тест DynFind2 пройден" : "Тест DynFind2 не пройден");
        }

        public static void DynDoubleHashFun1()
        {
            DynDoubleHashTable test = new DynDoubleHashTable(3);
            int res1 = test.HashFun("gfdgsdgsdfgsdfgfsdg", 0);
            int res2 = test.HashFun("gfdgsdgsdfgsdfgfsdg", 0);
            int res3 = test.HashFun("gfdgsdgsdfgsdfgfsdg", 0);
            Console.WriteLine(res1 == res2 && res2 == res3 ? "Тест DynDoubleHashFun1 пройден" : "Тест DynDoubleHashFun1 не пройден");
        }

        public static void DynDoubleHashFun2()
        {
            DynDoubleHashTable test = new DynDoubleHashTable(3);
            int res1 = test.HashFun("gfdgsdgsdfgsdg", 0);
            int res2 = test.HashFun("gfdgsdgsdfgsdfgfsdg", 0);
            int res3 = test.HashFun("gfdgsdgsdfgsdfgfsdsdafasdfasfasdfasdfsdafg", 0);
            Console.WriteLine(0 <= res1 && res1 < test.size && 0 <= res2 && res2 < test.size && 0 <= res3 && res3 < test.size ? "Тест DynDoubleHashFun2 пройден" : "Тест DynDoubleHashFun2 не пройден");
        }

        public static void DynDoubleSeekSlot1()
        {
            DynDoubleHashTable test = new DynDoubleHashTable(3);
            int res1 = test.SeekSlot("gfdgsdgsdfgsdg");
            int res2 = test.SeekSlot("gfdgsdgsdfgsdfgfsdg");
            int res3 = test.SeekSlot("gfdgsdgsdfgsdfgfsdsdafasdfasfasdfasdfsdafg");
            Console.WriteLine(res1 != res2 && res1 != res3 && res3 != res2 ? "Тест DynDoubleSeekSlot1 пройден" : "Тест DynDoubleSeekSlot1 не пройден");
        }

        public static void DynDoublePut1()
        {
            DynDoubleHashTable test = new DynDoubleHashTable(3);
            int res1 = test.Put("gfdgsdgsdfgsdg");
            Console.WriteLine(test.size == 17 ? "Тест DynDoublePut1 пройден" : "Тест DynDoublePut1 не пройден");
        }

        public static void DynDoublePut2()
        {
            DynDoubleHashTable test = new DynDoubleHashTable(3);
            test.Put("gfdgsdgsdfgsdg");
            test.Put("gfdgsdgsdfgsdfg");
            test.Put("gfdgsdgsdfgsdgавппавы");
            test.Put("gfdgsdgsdfgsdfваыпывапg");
            test.Put("gfdgsdgsdfgsdfваыпывафывфаывапg");
            test.Put("gfdgsdgsdfgsdg");
            test.Put("gfdgsdgsdfgsdfg");
            test.Put("gfdgsdgsdfgsdgавппавы");
            test.Put("gfdgsdgsdfgsdfваыпывапg");
            test.Put("gfdgsdgsdfgsdfваыпывафывфаывапg");
            test.Put("gfdgsdgsdfgsdg");
            test.Put("gfdgsdgsdfgsdfg");
            test.Put("gfdgsdgsdfgsdgавппавы");
            test.Put("gfdgsdgsdfgsdfваыпывапg");
            test.Put("gfdgsdgsdfgsdfваыпывафывфаывапg");
            test.Put("gfdgsdgsdfgsdg");
            test.Put("gfdgsdgsdfgsdfg");
            test.Put("gfdgsdgsdfgsdgавппавы");
            test.Put("gfdgsdgsdfgsdfваыпывапg");
            test.Put("gfdgsdgsdfgsdfваыпывафывфаывапg");
            Console.WriteLine(test.size == 37 ? "Тест DynDoublePut2 пройден" : "Тест DynDoublePut2 не пройден");
        }

        public static void DynDoubleFind1()
        {
            DynDoubleHashTable test = new DynDoubleHashTable(3);
            test.Put("gfdgsdgsdfgsdg");
            test.Put("gfdgsdgsdfgsdfg");
            test.Put("gfdgsdgsdfgsdgавппавы");
            test.Put("gfdgsdgsdfgsdfваыпывапg");
            test.Put("gfdgsdgsdfgsdfваыпывафывфаывапg");
            Console.WriteLine(test.Find("gfdgsdgsdfgsdg") != -1 ? "Тест DynDoubleFind1 пройден" : "Тест DynDoubleFind1 не пройден");
        }


        public static void DynDoubleFind2()
        {
            DynDoubleHashTable test = new DynDoubleHashTable(3);
            test.Put("gfdgsdgsdfgsdg");
            test.Put("gfdgsdgsdfgsdfg");
            test.Put("gfdgsdgsdfgsdgавппавы");
            test.Put("gfdgsdgsdfgsdfваыпывапg");
            test.Put("gfdgsdgsdfgsdfваыпывафывфаывапg");
            Console.WriteLine(test.Find("g") == -1 ? "Тест DynDoubleFind2 пройден" : "Тест DynDoubleFind2 не пройден");
        }

        public static void DDosCompare()
        {
            HashTableWithSalt abc = new HashTableWithSalt(17, 3);
            abc.Put("1");

            Stopwatch time = new Stopwatch();
            HashTable test1 = new HashTable(17, 3);
            time.Start();
            test1.Put("baaaaaaaaaaaaaaaa");
            test1.Put("abaaaaaaaaaaaaaaa");
            test1.Put("aabaaaaaaaaaaaaaa");
            test1.Put("aaaabaaaaaaaaaaaa");
            test1.Put("aaaaabaaaaaaaaaaa");
            test1.Put("aaaaaabaaaaaaaaaa");
            test1.Put("aaaaaaabaaaaaaaaa");
            test1.Put("aaaaaaaabaaaaaaaa");
            test1.Put("aaaaaaaaabaaaaaaa");
            test1.Put("aaaaaaaaaabaaaaaa");
            test1.Put("aaaaaaaaaaabaaaaa");
            test1.Put("aaaaaaaaaaaabaaaa");
            test1.Put("aaaaaaaaaaaaabaaa");
            test1.Put("aaaaaaaaaaaaaabaa");
            test1.Put("aaaaaaaaaaaaaaaba");
            test1.Put("aaaaaaaaaaaaaaaab");
            time.Stop();
            var res1 = time.ElapsedTicks;
            HashTableWithSalt test = new HashTableWithSalt(17, 3);
            time.Restart();
            test.Put("baaaaaaaaaaaaaaaa");
            test.Put("abaaaaaaaaaaaaaaa");
            test.Put("aabaaaaaaaaaaaaaa");
            test.Put("aaabaaaaaaaaaaaaa");
            test.Put("aaaabaaaaaaaaaaaa");
            test.Put("aaaaabaaaaaaaaaaa");
            test.Put("aaaaaabaaaaaaaaaa");
            test.Put("aaaaaaabaaaaaaaaa");
            test.Put("aaaaaaaabaaaaaaaa");
            test.Put("aaaaaaaaabaaaaaaa");
            test.Put("aaaaaaaaaabaaaaaa");
            test.Put("aaaaaaaaaaabaaaaa");
            test.Put("aaaaaaaaaaaabaaaa");
            test.Put("aaaaaaaaaaaaabaaa");
            test.Put("aaaaaaaaaaaaaabaa");
            test.Put("aaaaaaaaaaaaaaaba");
            test.Put("aaaaaaaaaaaaaaaab");
            time.Stop();
            var res = time.ElapsedTicks;
           
            
            Console.WriteLine($"Время работы при Ddos c измененной хэш функцией {res}, Время работы той же таблицы, но со стандартной хэш функцией {res1}");
        }

        public static void DDosOnSaltHash()
        {

        }

        public static void Main(string[] args)
        {
            HashFun1();
            HashFun2();
            SeekSlot1();
            SeekSlot2();
            Put1();
            Put2();
            Find1();
            Find2();
            DynHashFun1();
            DynHashFun2();
            DynSeekSlot1();
            DynPut1();
            DynPut2();
            DynFind1();
            DynFind2();
            DynDoubleHashFun1();
            DynDoubleHashFun2();
            DynDoubleSeekSlot1();
            DynDoublePut1();
            DynDoublePut2();
            DynDoubleFind1();
            DynDoubleFind2();
            DDosCompare();
        }
    }
}
