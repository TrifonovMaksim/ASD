using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class tests
    {
        static void Enqueue1()
        {
            AlgorithmsDataStructures.Queue<int> test = new AlgorithmsDataStructures.Queue<int>();
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            Console.WriteLine(test.Size() == 5 ? "Тест Test_Enqueue1 пройден" : "Тест Test_Enqueue1 не пройден");
        }

        static void Dequeue1()
        {
            AlgorithmsDataStructures.Queue<int> test = new AlgorithmsDataStructures.Queue<int>();
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            test.Dequeue();
            Console.WriteLine(test.Size() == 4 ? "Тест Test_Dequeue1 пройден" : "Тест Test_Dequeue1 не пройден");
        }

        static void Dequeue2()
        {
            AlgorithmsDataStructures.Queue<int> test = new AlgorithmsDataStructures.Queue<int>();
            Console.WriteLine(test.Dequeue() == default(int) ? "Тест Test_Dequeue2 пройден" : "Тест Test_Dequeue2 не пройден");
        }

        static void Dequeue3()
        {
            AlgorithmsDataStructures.Queue<int> test = new AlgorithmsDataStructures.Queue<int>();
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            Console.WriteLine(test.Dequeue() == 1 ? "Тест Test_Dequeue3 пройден" : "Тест Test_Dequeue3 не пройден");
        }

        static void Cycle_queue1()
        {
            AlgorithmsDataStructures.Queue<int> test = new AlgorithmsDataStructures.Queue<int>();
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            Solution.Cycle_Queue(test, 1);
            Console.WriteLine(test.Dequeue() == 2 ? "Тест Cycle_queue1 пройден" : "Тест Cycle_queue1 не пройден");
        }

        static void Cycle_queue2()
        {
            AlgorithmsDataStructures.Queue<int> test = new AlgorithmsDataStructures.Queue<int>();
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            Solution.Cycle_Queue(test, 5);
            Console.WriteLine(test.Dequeue() == 1 ? "Тест Cycle_queue2 пройден" : "Тест Cycle_queue2 не пройден");
        }

        static void Queue_on_stacksEnqueue1()
        {
            AlgorithmsDataStructures.Queue_on_stacks<int> test = new AlgorithmsDataStructures.Queue_on_stacks<int>();
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            Console.WriteLine(test.Size() == 5 ? "Тест Queue_on_stacksEnqueue1 пройден" : "Тест Queue_on_stacksEnqueue1 не пройден");
        }

        static void Queue_on_stacksDequeue1()
        {
            AlgorithmsDataStructures.Queue_on_stacks<int> test = new AlgorithmsDataStructures.Queue_on_stacks<int>();
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            test.Dequeue();
            Console.WriteLine(test.Size() == 4 ? "Тест Queue_on_stacksDequeue1 пройден" : "Тест Queue_on_stacksDequeue1 не пройден");
        }

        static void Queue_on_stacksDequeue2()
        {
            AlgorithmsDataStructures.Queue_on_stacks<int> test = new AlgorithmsDataStructures.Queue_on_stacks<int>();
            Console.WriteLine(test.Dequeue() == default(int) ? "Тест Queue_on_stacksDequeue2 пройден" : "Тест Queue_on_stacksDequeue2 не пройден");
        }
        static void Queue_on_stacksDequeue3()
        {
            AlgorithmsDataStructures.Queue_on_stacks<int> test = new AlgorithmsDataStructures.Queue_on_stacks<int>();
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            Console.WriteLine(test.Dequeue() == 1 ? "Тест Queue_on_stacksDequeue3 пройден" : "Тест Queue_on_stacksDequeue3 не пройден");
        }

        static void Reverse1()
        {
            AlgorithmsDataStructures.Queue<int> test = new AlgorithmsDataStructures.Queue<int>();
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            Solution.Reverse_Queue(test);
            Console.WriteLine(test.Dequeue() == 5 ? "Тест Reverse1 пройден" : "Тест Reverse1 не пройден");
        }

        static void Reverse2()
        {
            AlgorithmsDataStructures.Queue<int> test = new AlgorithmsDataStructures.Queue<int>();
            test.Enqueue(1);;
            Solution.Reverse_Queue(test);
            Console.WriteLine(test.Dequeue() == 1 ? "Тест Reverse2 пройден" : "Тест Reverse2 не пройден");
        }

        static void Static_Enqueue1()
        {
            AlgorithmsDataStructures.Static_Queue<int> test = new AlgorithmsDataStructures.Static_Queue<int>(10);
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            Console.WriteLine(test.Size() == 5 ? "Тест Static_Enqueue1 пройден" : "Тест Static_Enqueue1 не пройден");
        }

        static void Static_Enqueue2()
        {
            AlgorithmsDataStructures.Static_Queue<int> test = new AlgorithmsDataStructures.Static_Queue<int>(10);
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            test.Enqueue(5);
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            test.Enqueue(5);
            Console.WriteLine(test.Size() == 10 ? "Тест Static_Enqueue2 пройден" : "Тест Static_Enqueue2 не пройден");
        }

        static void Static_Enqueue3()
        {
            AlgorithmsDataStructures.Static_Queue<int> test = new AlgorithmsDataStructures.Static_Queue<int>(10);
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            test.Enqueue(6);
            test.Enqueue(7);
            test.Enqueue(8);
            test.Enqueue(9);
            test.Enqueue(10);
            test.Dequeue();
            test.Dequeue();
            test.Dequeue();
            test.Dequeue();
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            test.Enqueue(6);
            test.Enqueue(7);
            test.Enqueue(8);
            test.Enqueue(9);
            test.Enqueue(10);
            Console.WriteLine(test.Dequeue() == 5 ? "Тест Static_Enqueue3 пройден" : "Тест Static_Enqueue3 не пройден");
        }

        static void Static_Dequeue1()
        {
            AlgorithmsDataStructures.Static_Queue<int> test = new AlgorithmsDataStructures.Static_Queue<int>(10);
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            test.Dequeue();
            Console.WriteLine(test.Size() == 4 ? "Тест Static_Dequeue1 пройден" : "Тест Static_Dequeue1 не пройден");
        }

        static void Static_Dequeue2()
        {
            AlgorithmsDataStructures.Static_Queue<int> test = new AlgorithmsDataStructures.Static_Queue<int>(10);
            Console.WriteLine(test.Dequeue() == default(int) ? "Тест Static_Dequeue2 пройден" : "Тест Static_Dequeue2 не пройден");
        }

        static void Static_Dequeue3()
        {
            AlgorithmsDataStructures.Static_Queue<int> test = new AlgorithmsDataStructures.Static_Queue<int>(10);
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            Console.WriteLine(test.Dequeue() == 1 ? "Тест Static_Dequeue3 пройден" : "Тест Static_Dequeue3 не пройден");
        }

        static void Static_Isfull1()
        {
            AlgorithmsDataStructures.Static_Queue<int> test = new AlgorithmsDataStructures.Static_Queue<int>(10);
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            test.Enqueue(1);
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Enqueue(5);
            Console.WriteLine(test.Is_full() == true ? "Тест Static_Isfull1 пройден" : "Тест Static_Isfull1 не пройден");
        }

        static void Static_Isfull2()
        {
            AlgorithmsDataStructures.Static_Queue<int> test = new AlgorithmsDataStructures.Static_Queue<int>(10);
            Console.WriteLine(test.Is_full() == false ? "Тест Static_Isfull2 пройден" : "Тест Static_Isfull2 не пройден");
        }


        public static void Main(string[] args)
        {
            Enqueue1();
            Dequeue1();
            Dequeue2();
            Dequeue3();
            Cycle_queue1();
            Cycle_queue2();
            Queue_on_stacksDequeue1();
            Queue_on_stacksDequeue2();
            Queue_on_stacksDequeue3();
            Queue_on_stacksEnqueue1();
            Reverse1();
            Reverse2();
            Static_Dequeue1();
            Static_Dequeue2();
            Static_Dequeue3();
            Static_Enqueue1();
            Static_Enqueue2();
            Static_Enqueue3();
            Static_Isfull1();
            Static_Isfull2();
        }
    }
}
