using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    class Tests
    {
        static void Pop_1()
        {
            Stack<int> test = new Stack<int>();
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1234);
            Console.WriteLine(test.Pop() == 1234 ? "Тест Pop_1 пройден" : "Тест Pop_1 не пройден");
        }
        static void Pop_2()
        {
            Stack<int> test = new Stack<int>();
            Console.WriteLine(test.Pop() == 0 ? "Тест Pop_2 пройден" : "Тест Pop_2 не пройден");
        }

        static void Pop_3()
        {
            Stack<string> test = new Stack<string>();
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("LOL");
            Console.WriteLine(test.Pop() == "LOL" ? "Тест Pop_3 пройден" : "Тест Pop_3 не пройден");
        }
        static void Pop_4()
        {
            Stack<string> test = new Stack<string>();
            Console.WriteLine(test.Pop() == null ? "Тест Pop_4 пройден" : "Тест Pop_4 не пройден");
        }

        static void Push_Size_1()
        {
            Stack<int> test = new Stack<int>();
            test.Push(1);
            Console.WriteLine(test.stack_size == 1 ? "Тест Push_Size_1 пройден" : "Тест Push_Size_1 не пройден");
        }

        static void Push_Size_2()
        {
            Stack<string> test = new Stack<string>();
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("LOL");
            Console.WriteLine(test.stack_size == 21? "Тест Push_Size_2 пройден" : "Тест Push_Size_2 не пройден");
        }

        static void Peek_1()
        {
            Stack<int> test = new Stack<int>();
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1234);
            Console.WriteLine(test.Peek() == 1234 ? "Тест Peek_1 пройден" : "Тест Peek_1 не пройден");
        }
        static void Peek_2()
        {
            Stack<int> test = new Stack<int>();
            Console.WriteLine(test.Peek() == 0 ? "Тест Peek_2 пройден" : "Тест Peek_2 не пройден");
        }

        static void Peek_3()
        {
            Stack<string> test = new Stack<string>();
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("LOL");
            Console.WriteLine(test.Peek() == "LOL" ? "Тест Peek_3 пройден" : "Тест Peek_3 не пройден");
        }
        static void Peek_4()
        {
            Stack<string> test = new Stack<string>();
            Console.WriteLine(test.Peek() == null ? "Тест Peek_4 пройден" : "Тест Peek_4 не пройден");
        }

        static void Pop_1Reverse()
        {
            StackReverse<int> test = new StackReverse<int>();
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1234);
            Console.WriteLine(test.Pop() == 1234 ? "Тест Pop_1Reverse пройден" : "Тест Pop_1Reverse не пройден");
        }
        static void Pop_2Reverse()
        {
            StackReverse<int> test = new StackReverse<int>();
            Console.WriteLine(test.Pop() == 0 ? "Тест Pop_2Reverse пройден" : "Тест Pop_2Reverse не пройден");
        }

        static void Pop_3Reverse()
        {
            StackReverse<string> test = new StackReverse<string>();
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("LOL");
            Console.WriteLine(test.Pop() == "LOL" ? "Тест Pop_3Reverse пройден" : "Тест Pop_3Reverse не пройден");
        }
        static void Pop_4Reverse()
        {
            StackReverse<string> test = new StackReverse<string>();
            Console.WriteLine(test.Pop() == null ? "Тест Pop_4Reverse пройден" : "Тест Pop_4Reverse не пройден");
        }

        static void Push_Size_1Reverse()
        {
            StackReverse<int> test = new StackReverse<int>();
            test.Push(1);
            Console.WriteLine(test.stack_size == 1 ? "Тест Push_Size_1Reverse пройден" : "Тест Push_Size_1Reverse не пройден");
        }

        static void Push_Size_2Reverse()
        {
            StackReverse<string> test = new StackReverse<string>();
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("LOL");
            Console.WriteLine(test.stack_size == 21 ? "Тест Push_Size_2Reverse пройден" : "Тест Push_Size_2Reverse не пройден");
        }

        static void Peek_1Reverse()
        {
            StackReverse<int> test = new StackReverse<int>();
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1);
            test.Push(1234);
            Console.WriteLine(test.Peek() == 1234 ? "Тест Peek_1Reverse пройден" : "Тест Peek_1Reverse не пройден");
        }
        static void Peek_2Reverse()
        {
            StackReverse<int> test = new StackReverse<int>();
            Console.WriteLine(test.Peek() == 0 ? "Тест Peek_2Reverse пройден" : "Тест Peek_2Reverse не пройден");
        }

        static void Peek_3Reverse()
        {
            StackReverse<string> test = new StackReverse<string>();
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("sdfds");
            test.Push("LOL");
            Console.WriteLine(test.Peek() == "LOL" ? "Тест Peek_3Reverse пройден" : "Тест Peek_3Reverse не пройден");
        }
        static void Peek_4Reverse()
        {
            StackReverse<string> test = new StackReverse<string>();
            Console.WriteLine(test.Peek() == null ? "Тест Peek_4Reverse пройден" : "Тест Peek_4Reverse не пройден");
        }

        static void Is_Balanced1()
        {
            string test = "(()((())()))";
            Solution.Is_Balanced(test);
        }
        static void Is_Balanced2()
        {
            string test = "(()()(()";
            Solution.Is_Balanced(test);
        }

        static void Is_BalancedUpgraded1()
        {
            string test = "{{}{{{}}{}}}";
            Solution.Is_Balanced_Upgraded(test);
        }
        static void Is_BalancedUprgaded2()
        {
            string test = "[[][][[]";
            Solution.Is_Balanced_Upgraded(test);
        }

        static void Min1()
        {
            Stack1 test = new Stack1();
            test.Push(1);
            test.Push(2);
            test.Push(3);
            test.Push(4);
            test.Push(5);
            test.Push(6);
            test.Push(-1);
            test.Push(-2);
            test.Push(1);
            test.Push(4);
            test.Push(1);
            test.Push(5);
            test.Push(4);
            test.Push(-111);
            test.Push(1);
            Console.WriteLine(test.Min() == -111 ? "Тест Min1 пройден" : "Тест Min1 не пройден");
        }

        static void Min2()
        {
            Stack1 test = new Stack1();
            test.Push(1);
            test.Push(2);
            test.Push(3);
            test.Push(4);
            test.Push(5);
            test.Push(6);
            test.Push(-1);
            test.Push(-2);
            test.Push(1);
            test.Push(4);
            test.Push(1);
            test.Push(5);
            test.Push(4);
            test.Push(-111);
            test.Push(1);
            test.Pop();
            test.Pop();
            test.Pop();
            test.Pop();
            test.Pop();
            test.Pop();
            test.Pop();
            test.Pop();

            Console.WriteLine(test.Min() == -1 ? "Тест Min2 пройден" : "Тест Min2 не пройден");
        }

        static void Average1()
        {
            Stack1 test = new Stack1();
            test.Push(1);
            test.Push(2);
            test.Push(3);
            test.Push(4);
            test.Push(5);

            Console.WriteLine(test.Average() == 3 ? "Тест Average1 пройден" : "Тест Average1 не пройден");
        }

        static void Average2()
        {
            Stack1 test = new Stack1();
            try
            {
                test.Average();
                Console.WriteLine("Тест Average2 не пройден");
            }
            catch
            {
                Console.WriteLine("Тест Average2 пройден");
            }
        }

        static void calculation()
        {
            string expression = "8 2 + 5 * 9 + =";
            Solution.calculation(expression);
        }

        static void Main(string[] args)
        {
            Pop_1();
            Pop_2();
            Pop_3();
            Pop_4();
            Push_Size_1();
            Push_Size_2();
            Peek_1();
            Peek_2();
            Peek_3();
            Peek_4();
            Pop_1Reverse();
            Pop_2Reverse();
            Pop_3Reverse();
            Pop_4Reverse();
            Push_Size_1Reverse();
            Push_Size_2Reverse();
            Peek_1Reverse();
            Peek_2Reverse();
            Peek_3Reverse();
            Peek_4Reverse();
            Is_Balanced1();
            Is_Balanced2();
            Is_BalancedUpgraded1();
            Is_BalancedUprgaded2();
            Min1();
            Min2();
            Average1();
            Average2();
            calculation();
        }
    }



}