using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        public List<T> stack;
        public int stack_size;
        public int tail;
        public Stack()
        {
            stack_size = 0;
            tail = 0;
            stack = new List<T>();
        }

        public int Size()
        {
            return stack_size;
        }

        // Pop работает за O(1)
        public T Pop()
        {
            T res;
            if (stack_size > 0)
            {
                res = stack[tail - 1];
                stack.RemoveAt(tail - 1);
                stack_size--;
                tail--;
            }
            else res = default(T);
            return res;
        }

        // Push тоже работает за O(1)
        public void Push(T val)
        {
            stack.Add(val);
            tail++;
            stack_size++;
        }

        public T Peek()
        { 
            return stack_size > 0 ? stack[tail - 1] : default(T);
        }
    }

    public class StackReverse<T>
    {
        public LinkedList<T> stack;
        public int stack_size;
        public StackReverse()
        {
            stack_size = 0;
            stack = new LinkedList<T>();
        }

        public int Size()
        {
            return stack_size;
        }

        public T Pop()
        {
            T res;
            if (stack_size > 0)
            {
                res = stack.First.Value;
                stack.RemoveFirst();
                stack_size--;
            }
            else res = default(T);
            return res;
        }

        public void Push(T val)
        {
            stack.AddFirst(val);
            stack_size++;
        }

        public T Peek()
        {
            return stack_size > 0 ? stack.First.Value : default(T);
        }

        // Задание 3. Как отработает данный цикл.
        //            while (stack.size() > 0)
        //            stack.pop()
        //            stack.pop()
        // Данный цикл отработает нормально, если количество элементов в стеке четное, если нет то последний поп вернет null.
    }

}