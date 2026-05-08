using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace AlgorithmsDataStructures
{

    public class Solution
    {
        // Задание 4. Напишите функцию, которая получает на вход строку, состоящую из открывающих и закрывающих скобок.
        static public void Is_Balanced(string str)
        {
            Stack<char> stack = new Stack<char>();
            bool Is_Balanced = true;
            foreach (char s in str)
            {
                if (s == '(') stack.Push(s);

                else
                {
                    if (stack.Pop() != '(')
                    {
                        Is_Balanced = false;
                        break;
                    }
                }
            }
            if (stack.stack_size != 0) Is_Balanced = false;
            Console.WriteLine( Is_Balanced == true ? "Последовательность сбалансированна" : "Последовательность не сбалансированна");
        }
        // Такое задание уже делал на литкоде, просто надо сверить, что совпадают открывающие с закрывающими, если в конце в стеке что-то остлось, значит перекос по открывающиам.
        // По времени сложность O(n) Идем по всей строке.
        // По памяти сложность O(n) Создаем стэк размером почти n в случае если все открывающие, если нет то меньше, а так в худшем случае O(n).


        // Задание 5.Расширьте фукнцию из предыдущего примера, если скобки могут быть трех типов: (), {}, [].
        static public void Is_Balanced_Upgraded(string str)
        {
            Stack<char> stack = new Stack<char>();
            bool Is_Balanced = true;
            foreach (char s in str)
            {
                switch(s)
                {
                    case '(': 
                        stack.Push(s); 
                        break;

                    case '{':
                        stack.Push(s);
                        break;
                    case '[':
                        stack.Push(s);
                        break;
                    case ')':
                        if (stack.Pop() != '(') Is_Balanced = false;
                        break;
                    case '}':
                        if (stack.Pop() != '{') Is_Balanced = false;
                        break;
                    case ']':
                        if (stack.Pop() != '[') Is_Balanced = false;
                        break;
                }
                if (Is_Balanced == false) break;
            }
            if (stack.stack_size != 0) Is_Balanced = false;
            Console.WriteLine(Is_Balanced == true ? "Последовательность сбалансированна" : "Последовательность не сбалансированна");
        }
        /*Было не сложно, просто надо было расширить количество возможных скобок, в питоне это все проще можно было бы просто написать эти скобки в строке и проверить через in, в C# я подумал, что удобнее всего сделать через свитч, можно то-же самое сделать через if else.
         * По времени и по памяти все то-же самое O(n), ничего не изменилось.
         */



        // Задание 8. Напишите функцию, которая с помощью двух стеков реализует вычисление подобных постфиксных выражений.
        static public void calculation(string str)
        {
            string[] chars = str.Split(' ');
            Stack<string> stack1 = new Stack<string>();
            Stack<int> stack2 = new Stack<int>();
            for (int i = chars.Length - 1; i >= 0; i--) stack1.Push(chars[i]);
            while(stack1.stack_size > 0) 
            {
                string s = stack1.Pop();
                if (int.TryParse(s, out int res))
                {
                    stack2.Push(res);
                }
                else
                {
                    if(s == "=") continue;
                    int a = stack2.Pop();
                    int b = stack2.Pop();
                    switch (s)
                    {
                        case "+":
                            stack2.Push(a + b);
                            break;
                        case "-":
                            stack2.Push(a - b);
                            break;
                        case "/":
                            stack2.Push(a / b);
                            break;
                        case "*":
                            stack2.Push(a * b);
                            break;
                    }
                }
            }
            Console.WriteLine("Результат " + stack2.Pop());

        }

        /* Сделал как в примере через 2 стека, получил строку, запушил ее в 1 стек, потом начал парсить на инты и операции, по логике у выражений всегда 2 числа поэтому просто а и b достаточно. Решил не обрабатывать знак =, а просто через иф проверяю, если равно, значит надо заканчивать итерацию, а дальше цикл идти не будет так как кончились элементы в стеке.
         * Так же, сделал цикл через вайл, потому что на каждой итерации размер уменьшается и через фор это через костыли надо отслеживать.
         * По времени сложность O(2n) или O(n) надо пройти по строке сначала и запушить в 1 стек, затем пройтись по первому стеку.
         * По памяти O(2n) или O(n) надо создать 2 стека.
         */
    }


    // Задание 6. Добавьте в стек функцию, возвращающую текущий минимальный элемент в нём за O(1) (подсказка: используйте второй стек).
    public class Stack1
    {
        public List<int> stack;
        public int stack_size;
        public int tail;
        public Stack<int> stack_for_min;
        public int counter;
        public Stack1()
        {
            stack_size = 0;
            tail = 0;
            stack = new List<int>();
            stack_for_min = new Stack<int>();
            counter = 0;
        }

        public int Size()
        {
            return stack_size;
        }

        // Pop работает за O(1)
        public int Pop()
        {
            int res;
            if (stack_size > 0)
            {
                res = stack[tail - 1];
                if (res == stack_for_min.Peek()) stack_for_min.Pop();
                stack.RemoveAt(tail - 1);
                stack_size--;
                tail--;
            }
            else res = default(int);
            counter -= res;
            return res;
        }

        // Push тоже работает за O(1)
        public void Push(int val)
        {
            stack.Add(val);
            if (val <= stack_for_min.Peek() || stack_for_min.stack_size == 0) stack_for_min.Push(val);
            tail++;
            stack_size++;
            counter += val;
        }

        public int Peek()
        {
            return stack_size > 0 ? stack[tail - 1] : default(int);
        }

        public int Min()
        {

            return stack_size > 0 ? stack_for_min.Peek() : default(int);
        }
        // Создал второй стек, в него добавлял только значения меньше имеющегося в стеке. В итоге на вершине 2 стека всегда наименьшее значение первого стека.
        // По времени O(1)
        // По памяти O(2n) на два стека.


        // Задание 7. Добавьте в стек функцию, которая возвращает среднее значение всех элементов в стеке. Она должна выполняться за O(1).
        public int Average()
        {
            if (stack_size == 0) throw new Exception("Стек пустой");
            return counter / stack_size;
        }

        // Просто добавил поле со счетчиком и делю потом сумму элементов на их количество.
        // Память O(1) время O(1)
    }   

        
}
