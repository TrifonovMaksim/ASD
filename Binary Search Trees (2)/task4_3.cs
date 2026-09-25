using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures2
{
    public class Tests
    {
        static void AddKey()
        {
            aBST test = new aBST(3);
            test.AddKey(50);
            test.AddKey(25);
            test.AddKey(75);
            test.AddKey(37);
            test.AddKey(62);
            test.AddKey(84);
            test.AddKey(31);
            test.AddKey(43);
            test.AddKey(55);
            test.AddKey(92);
            Console.WriteLine(test.Tree[0] == 50 && test.Tree[1] == 25 && test.Tree[2] == 75 && test.Tree[4] == 37 && test.Tree[5] == 62 && test.Tree[6] == 84 &&
                test.Tree[9] == 31 && test.Tree[10] == 43 && test.Tree[11] == 55 && test.Tree[14] == 92 ? "Тест AddKey пройден" : "Тест AddKey не пройден");
        }

        static void FindKeyIndex()
        {
            aBST test = new aBST(3);
            test.AddKey(50);
            test.AddKey(25);
            test.AddKey(75);
            test.AddKey(37);
            test.AddKey(62);
            test.AddKey(84);
            test.AddKey(31);
            test.AddKey(43);
            test.AddKey(55);
            test.AddKey(92);
            Console.WriteLine(test.FindKeyIndex(50) == 0 && test.FindKeyIndex(43) == 10 && test.FindKeyIndex(123) == null ? "Тест FindKeyIndex пройден" : "Тест FindKeyIndex не пройден");
        }


        static void FindLCA()
        {
            SolutionaBST test = new SolutionaBST(3);
            test.AddKey(50);
            test.AddKey(25);
            test.AddKey(75);
            test.AddKey(37);
            test.AddKey(62);
            test.AddKey(84);
            test.AddKey(31);
            test.AddKey(43);
            test.AddKey(55);
            test.AddKey(92);
            Console.WriteLine(test.FindLCA(55, 92) == 75 && test.FindLCA(31, 92) == 50 && test.FindLCA(55, 84) == 75 ? "Тест FindLCA пройден" : "Тест FindLCA не пройден");
        }

        static void WideAllNodes()
        {
            SolutionaBST test = new SolutionaBST(3);
            test.AddKey(50);
            test.AddKey(25);
            test.AddKey(75);
            test.AddKey(37);
            test.AddKey(62);
            test.AddKey(84);
            test.AddKey(31);
            test.AddKey(43);
            test.AddKey(55);
            test.AddKey(92);
            Console.WriteLine(test.WideAllNodes().SequenceEqual(new List<int>{50, 25, 75, 37, 62, 84, 31, 43, 55, 92}) ? "Тест WideAllNodes пройден" : "Тест WideAllNodes не пройден");
        }

        static void Main()
        {
            AddKey();
            FindKeyIndex();
            FindLCA();
            WideAllNodes();
        }
    }
}