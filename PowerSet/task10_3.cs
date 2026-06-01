using System;
using System.Collections.Generic;
using static AlgorithmsDataStructures.Solution;

namespace AlgorithmsDataStructures
{
    public class Tests
    {

        public static void Put1()
        {
            PowerSet<string> test = new PowerSet<string>();
            test.Put("a");
            Console.WriteLine(test.Get("a") && test.Size() == 1 ? "Тест Put1 пройден" : "Тест Put1 не пройден");
        }


        public static void Put2()
        {
            PowerSet<string> test = new PowerSet<string>();
            test.Put("a");
            test.Put("a");
            Console.WriteLine(test.Size() == 1 ? "Тест Put2 пройден" : "Тест Put2 не пройден");
        }

        public static void Remove1()
        {
            PowerSet<string> test = new PowerSet<string>();
            test.Put("a");
            test.Put("b");
            Console.WriteLine(test.Remove("a") && !test.Get("a") && test.Size() == 1 ? "Тест Remove1 пройден" : "Тест Remove1 не пройден");
        }


        public static void Remove2()
        {
            PowerSet<string> test = new PowerSet<string>();
            test.Put("a");
            Console.WriteLine(!test.Remove("b") ? "Тест Remove2 пройден" : "Тест Remove2 не пройден");
        }

        public static void Intersection1()
        {
            PowerSet<string> test1 = new PowerSet<string>();
            PowerSet<string> test2 = new PowerSet<string>();
            test1.Put("a");
            test1.Put("b");
            test1.Put("c");
            test2.Put("b");
            test2.Put("c");
            test2.Put("d");
            PowerSet<string> res = test1.Intersection(test2);
            Console.WriteLine(res.Size() == 2 && res.Get("b") && res.Get("c") && !res.Get("a") ? "Тест Intersection1 пройден" : "Тест Intersection1 не пройден");
        }

        public static void Intersection2()
        {
            PowerSet<string> test1 = new PowerSet<string>();
            PowerSet<string> test2 = new PowerSet<string>();
            test1.Put("a");
            test1.Put("b");
            test2.Put("c");
            test2.Put("d");
            PowerSet<string> res = test1.Intersection(test2);
            Console.WriteLine(res.Size() == 0 ? "Тест Intersection2 пройден" : "Тест Intersection2 не пройден");
        }

        public static void Union1()
        {
            PowerSet<string> test1 = new PowerSet<string>();
            PowerSet<string> test2 = new PowerSet<string>();
            test1.Put("a");
            test1.Put("b");
            test2.Put("c");
            test2.Put("d");
            PowerSet<string> res = test1.Union(test2);
            Console.WriteLine(res.Size() == 4 && res.Get("a") && res.Get("b") && res.Get("c") && res.Get("d") ? "Тест Union1 пройден" : "Тест Union1 не пройден");
        }

        public static void Union2()
        {
            PowerSet<string> test1 = new PowerSet<string>();
            PowerSet<string> test2 = new PowerSet<string>();
            test1.Put("a");
            test1.Put("b");
            PowerSet<string> res = test1.Union(test2);
            Console.WriteLine(res.Size() == 2 && res.Get("a") && res.Get("b") ? "Тест Union2 пройден" : "Тест Union2 не пройден");
        }


        public static void Difference1()
        {
            PowerSet<string> test1 = new PowerSet<string>();
            PowerSet<string> test2 = new PowerSet<string>();
            test1.Put("a");
            test1.Put("b");
            test1.Put("c");
            test2.Put("b");
            test2.Put("c");
            PowerSet<string> res = test1.Difference(test2);
            Console.WriteLine(res.Size() == 1 && res.Get("a") && !res.Get("b") ? "Тест Difference1 пройден" : "Тест Difference1 не пройден");
        }

        public static void Difference2()
        {
            PowerSet<string> test1 = new PowerSet<string>();
            PowerSet<string> test2 = new PowerSet<string>();
            test1.Put("a");
            test1.Put("b");
            test2.Put("a");
            test2.Put("b");
            test2.Put("c");
            PowerSet<string> res = test1.Difference(test2);
            Console.WriteLine(res.Size() == 0 ? "Тест Difference2 пройден" : "Тест Difference2 не пройден");
        }


        public static void IsSubset1()
        {
            PowerSet<string> test1 = new PowerSet<string>();
            PowerSet<string> test2 = new PowerSet<string>();
            test1.Put("a");
            test1.Put("b");
            test1.Put("c");
            test2.Put("a");
            test2.Put("b");
            Console.WriteLine(test1.IsSubset(test2) ? "Тест IsSubset1 пройден" : "Тест IsSubset1 не пройден");
        }

        public static void IsSubset2()
        {
            PowerSet<string> test1 = new PowerSet<string>();
            PowerSet<string> test2 = new PowerSet<string>();
            test1.Put("a");
            test1.Put("b");
            test2.Put("a");
            test2.Put("b");
            test2.Put("c");
            Console.WriteLine(!test1.IsSubset(test2) ? "Тест IsSubset2 пройден" : "Тест IsSubset2 не пройден");
        }

        public static void IsSubset3()
        {
            PowerSet<string> test1 = new PowerSet<string>();
            PowerSet<string> test2 = new PowerSet<string>();
            test1.Put("a");
            test1.Put("b");
            test1.Put("c");
            test2.Put("a");
            test2.Put("d");
            Console.WriteLine(!test1.IsSubset(test2) ? "Тест IsSubset3 пройден" : "Тест IsSubset3 не пройден");
        }

        public static void Equals1()
        {
            PowerSet<string> test1 = new PowerSet<string>();
            PowerSet<string> test2 = new PowerSet<string>();
            test1.Put("a");
            test1.Put("b");
            test1.Put("c");
            test2.Put("a");
            test2.Put("b");
            test2.Put("c");
            Console.WriteLine(test1.Equals(test2) ? "Тест Equals1 пройден" : "Тест Equals1 не пройден");
        }


        public static void Equals2()
        {
            PowerSet<string> test1 = new PowerSet<string>();
            PowerSet<string> test2 = new PowerSet<string>();
            test1.Put("a");
            test1.Put("b");
            test1.Put("c");
            test2.Put("a");
            test2.Put("b");
            Console.WriteLine(!test1.Equals(test2) ? "Тест Equals2 пройден" : "Тест Equals2 не пройден");
        }

        public static void Time()
        {
            PowerSet<string> test1 = new PowerSet<string>();
            PowerSet<string> test2 = new PowerSet<string>();
            for (int i = 0; i < 19000; i++) test1.Put(i.ToString());
            for (int i = 10000; i < 19000; i++) test2.Put(i.ToString());

            var watch = System.Diagnostics.Stopwatch.StartNew();
            test1.Put("a");
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds < 2000 ? "Тест на время Put пройден" : "Тест на время Put пройден не пройден");
            test2.Put("a");
            watch.Restart();
            test1.Remove("a");
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds < 2000 ? "Тест на время Remove пройден" : "Тест на время Remove пройден не пройден");
            test2.Remove("a");
            watch.Restart();
            test1.Intersection(test2);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds < 2000 ? "Тест на время Intersection пройден" : "Тест на время Intersection не пройден");
            watch.Restart();
            test1.Union(test2);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds < 2000 ? "Тест на время Union пройден" : "Тест на время Union пройден не пройден");
            watch.Restart();
            test1.Difference(test2);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds < 2000 ? "Тест на время Difference пройден" : "Тест на время Difference не пройден");
            watch.Restart();
            test1.IsSubset(test2);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds < 2000 ? "Тест на время IsSubset пройден" : "Тест на время IsSubset не пройден");
        }

        public static void DecartMultiply1()
        {
            PowerSetSolution<string> test1 = new PowerSetSolution<string>();
            PowerSetSolution<string> test2 = new PowerSetSolution<string>();
            test1.Put("a");
            test1.Put("b");
            test2.Put("c");
            test2.Put("d");
            PowerSetSolution<string> res = PowerSetSolution<string>.DecartMultiply(test1, test2);
            Console.WriteLine(res.Size() == 4 && res.Get("a,c") && res.Get("a,d") && res.Get("b,c") && res.Get("b,d") ? "Тест DecartMultiply1 пройден" : "Тест DecartMultiply1 не пройден");
        }

        public static void DecartMultiply2()
        {
            PowerSetSolution<string> test1 = new PowerSetSolution<string>();
            PowerSetSolution<string> test2 = new PowerSetSolution<string>();
            test1.Put("1");
            test1.Put("2");
            test1.Put("3");
            test2.Put("3");
            test2.Put("5");
            PowerSetSolution<string> res = PowerSetSolution<string>.DecartMultiply(test1, test2);
            Console.WriteLine(res.Size() == 6 && res.Get("1,3") && res.Get("1,5") && res.Get("2,3") && res.Get("2,5") && res.Get("3,3") && res.Get("3,5") ? "Тест DecartMultiply2 пройден" : "Тест DecartMultiply2 не пройден");
        }

        public static void DecartMultiply3()
        {
            PowerSetSolution<string> test1 = new PowerSetSolution<string>();
            PowerSetSolution<string> test2 = new PowerSetSolution<string>();
            test1.Put("a");
            PowerSetSolution<string> res = PowerSetSolution<string>.DecartMultiply(test1, test2);
            Console.WriteLine(res.Size() == 0 ? "Тест DecartMultiply3 пройден" : "Тест DecartMultiply3 не пройден");
        }


        public static void MultiIntersection1()
        {
            PowerSet<string> test1 = new PowerSet<string>();
            PowerSet<string> test2 = new PowerSet<string>();
            PowerSet<string> test3 = new PowerSet<string>();
            test1.Put("a");
            test1.Put("b");
            test1.Put("c");
            test2.Put("b");
            test2.Put("c");
            test2.Put("d");
            test3.Put("c");
            test3.Put("d");
            test3.Put("e");
            List<PowerSet<string>> lst = new List<PowerSet<string>> {test1, test2, test3};
            PowerSet<string> res = MultiIntersection(lst);
            Console.WriteLine(res.Size() == 1 && res.Get("c") ? "Тест MultiIntersection1 пройден" : "Тест MultiIntersection1 не пройден");
        }

        public static void MultiIntersection2()
        {
            PowerSet<string> test1 = new PowerSet<string>();
            PowerSet<string> test2 = new PowerSet<string>();
            PowerSet<string> test3 = new PowerSet<string>();
            PowerSet<string> test4 = new PowerSet<string>();
            test1.Put("a");
            test1.Put("b");
            test1.Put("c");
            test2.Put("a");
            test2.Put("b");
            test2.Put("c");
            test3.Put("a");
            test3.Put("b");
            test3.Put("c");
            test4.Put("d");
            test4.Put("e");
            List<PowerSet<string>> lst = new List<PowerSet<string>> {test1, test2, test3, test4};
            PowerSet<string> res = MultiIntersection(lst);
            Console.WriteLine(res.Size() == 0 ? "Тест MultiIntersection2 пройден" : "Тест MultiIntersection2 не пройден");
        }

        public static void MultiIntersection3()
        {
            PowerSet<string> test1 = new PowerSet<string>();
            PowerSet<string> test2 = new PowerSet<string>();
            PowerSet<string> test3 = new PowerSet<string>();
            test1.Put("a");
            test1.Put("b");
            test1.Put("c");
            test2.Put("a");
            test2.Put("b");
            test2.Put("c");
            test3.Put("a");
            test3.Put("b");
            test3.Put("c");
            List<PowerSet<string>> lst = new List<PowerSet<string>> {test1, test2, test3};
            PowerSet<string> res = MultiIntersection(lst);
            Console.WriteLine(res.Size() == 3 && res.Get("a") && res.Get("b") && res.Get("c") ? "Тест MultiIntersection3 пройден" : "Тест MultiIntersection3 не пройден");
        }

        public static void BagPut1()
        {
            Bag<string> test = new Bag<string>();
            test.Put("a");
            test.Put("a");
            test.Put("b");
            Console.WriteLine(test.Size() == 3 && test.Get("a") && test.Get("b") ? "Тест BagPut1 пройден" : "Тест BagPut1 не пройден");
        }

        public static void BagPut2()
        {
            Bag<string> test = new Bag<string>();
            test.Put("a");
            test.Put("a");
            test.Put("a");
            List<string> all = test.GetAll();
            Console.WriteLine(all.Count == 1 && all[0] == "a,3" ? "Тест BagPut2 пройден" : "Тест BagPut2 не пройден");
        }

        public static void BagRemove1()
        {
            Bag<string> test = new Bag<string>();
            test.Put("a");
            test.Put("a");
            test.Put("a");
            test.Remove("a");
            List<string> all = test.GetAll();
            Console.WriteLine(test.Size() == 2 && all[0] == "a,2" ? "Тест BagRemove1 пройден" : "Тест BagRemove1 не пройден");
        }


        public static void BagRemove2()
        {
            Bag<string> test = new Bag<string>();
            test.Put("a");
            test.Remove("a");
            Console.WriteLine(test.Size() == 0 && !test.Get("a") ? "Тест BagRemove2 пройден" : "Тест BagRemove2 не пройден");
        }

        public static void BagGetAll1()
        {
            Bag<string> test = new Bag<string>();
            test.Put("a");
            test.Put("a");
            test.Put("b");
            test.Put("c");
            test.Put("c");
            test.Put("c");
            List<string> res = test.GetAll();
            Console.WriteLine($"Поданные значения [a 2, b 1, c 3], результат [{string.Join(", ", res)}]");
            Console.WriteLine(res.Count == 3 ? "Тест BagGetAll1 пройден" : "Тест BagGetAll1 не пройден");
        }


        public static void BagGetAll2()
        {
            Bag<string> test = new Bag<string>();
            List<string> res = test.GetAll();
            Console.WriteLine(res.Count == 0 ? "Тест BagGetAll2 пройден" : "Тест BagGetAll2 не пройден");
        }
        public static void Main(string[] args)
        {
            Put1();
            Put2();
            Remove1();
            Remove2();
            Intersection1();
            Intersection2();
            Union1();
            Union2();
            Difference1();
            Difference2();
            IsSubset1();
            IsSubset2();
            IsSubset3();
            Equals1();
            Equals2();
            Time();
            DecartMultiply1();
            DecartMultiply2();
            DecartMultiply3();
            MultiIntersection1();
            MultiIntersection2();
            MultiIntersection3();
            BagPut1();
            BagPut2();
            BagRemove1();
            BagRemove2();
            BagGetAll1();
            BagGetAll2();
        }
    }
}
