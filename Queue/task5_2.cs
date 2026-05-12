using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Solution
    {
        // Задание 3. Напишите функцию, которая "вращает" очередь по кругу на N элементов.
        public static void Cycle_Queue<T>(AlgorithmsDataStructures.Queue<T> queue, int n)
        {
            if (queue.Size() == 0)
            {
                Console.WriteLine("Очередь пуста");
                return;
            }
            for (int i = 0; i < n; i++)
            {
                T tmp = queue.Dequeue();
                queue.Enqueue(tmp);
            }
        }
        /*Суть решения, просто убираем из головы значение и вставляем его в хвост n раз.
         * Сложность по памяти O(1) мы ничего нового не создаем кроме временной переменной.
         * Сложность по времени O(n) зависит от того, насколько элементов надо "вращать".
         */

        // Задание 5. Добавьте функцию, которая обращает все элементы в очереди в обратном порядке.
        public static void Reverse_Queue<T>(AlgorithmsDataStructures.Queue<T> queue)
        {
            if (queue.Size() == 0)
            {
                Console.WriteLine("Очередь пуста");
                return;
            }
            Stack<T> stack = new Stack<T>();
            int size = queue.Size();
            for (int i = 0; i < size; i++) stack.Push(queue.Dequeue());
            for (int i = 0; i < size; i++) queue.Enqueue(stack.Pop());
        }
        /* По решению предыдущей задачи, быстро стало понятно, что перевернуть очередь можно стеком, поэтому я просто взял и запушил всю очередь, а потом доставал из стека и возвращал в очередь уже в обратном порядке от изначального.
         * Сложность по памяти O(n) создали стек.
         * Сложность по времени O(n) сделали n раз пуш, поп, вставку в очередь и удааление из очереди.
         */
    }


    // Задание 4. Реализуйте очередь с помощью двух стеков.
    public class Queue_on_stacks<T>
    {
        Stack<T> stack1;
        Stack<T> stack2;
        public Queue_on_stacks()
        {
            stack1 = new Stack<T>();
            stack2 = new Stack<T>();
        }

        public void Enqueue(T item)
        {
            stack1.Push(item);
        }

        public T Dequeue()
        {
            if (stack1.Size() == 0 && stack2.Size() == 0) return default(T);
            if (stack2.Size() == 0)
            {
                int len = stack1.Size();
                for (int i = 0; i < len; i++)
                {
                    stack2.Push(stack1.Pop());
                }
            }
            return stack2.Pop();
        }

        public int Size()
        {
            return stack1.Size() + stack2.Size(); // размер очереди
        }

    }
    /* Первый стек исполизовался для хранения, по сравнению с очередью там порядок обратный, чтобы получить результат, как в очереди второй стек использовался, как бы для переворота первого и получения элементов в обратном порядке,
     * но правильным для очереди. Второй стек после самого первого заполнения не надо трогать пока он не станет пустым, чтобы не переменаоись элементы.
     * Сложность по времени O(n) делаем пуши в 2 стека n раз и попы из стеков n раз.
     * Сложность по памяти O(n) создали 2 стека.
     */ 
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

    // Задание 6. Реализуйте круговую (циклическую буферную) очередь статическим массивом фиксированного размера.
    public class Static_Queue<T>
    {
        public int capacity;
        public int fullnes;
        public T[] queue;
        public int head;
        public int tail;
        public Static_Queue(int capacity)
        {
            if (capacity <= 0) throw new Exception("Размерность не задана или равна 0");
            this.capacity = capacity;
            fullnes = 0;
            queue = new T[capacity];
            head = tail = 0;
        }

        public void Enqueue(T item)
        {
            if (Is_full())
            {
                Console.WriteLine("Очередь заполнена");
                return;
            }
            queue[tail] = item;
            tail = (tail + 1) % capacity;
            fullnes++;
        }

        public T Dequeue()
        {
            if (fullnes == 0) return default(T);
            T res = queue[head];
            head = (head + 1) % capacity;
            fullnes--;
            return res;
        }

        public int Size()
        {
            return fullnes; 
        }

        public bool Is_full()
        {
            return capacity > fullnes ? false : true;
        }

    }
    /* Создал статический массив, можно было бы сделать размерность по умолчанию, но в задании не было сказано ничего про это, поэтому решил не заниматься самодеятельностью. 
     * С помощью остатка от деления можно легко идти циклически по массиву и не допустить ошибку при индексации. В этом и весь фокус.
     * По времени сложность у методов O(1).
     * По памяти тоже O(1).
     * */





    // 6. Динамический массив на основе банковского метода.
    // Рефлексия по прошлому заданию. Я сделал похоже на эталонное решение, вставку и добавление в конец сделал по цене 3, удаление тоже за 3 а реаллокацию за N. Но в эталонном решение написано про реальные и не реальные расходы это,
    // я не понял при решении, хотя это логично, было сказано, что мы завышаем реальный расход, тоесть надо было делать реальные расходы и то, что кладем в банк.

    // 7. Многомерный динамический массив.
    // Рефлексия по прошлому заданию. Так и думал, что надо сделать одномерный через индексы, но мне показалось, что это слишком запутанно. Поэтому мне показалось логичным, раз мы реализовали динамический массив, значит надо его использовать
    // и я решил сделать, как бы вложенные друг в друга динамические массивы. Получилось достаточно запутанно, не очевидно понятен спуск до нужного уровня вложенности в массивах, тяжело придти и работать с нужным индексом.
    // Специально гуглил, как реализованы многомерные массивы в стандартной библиотеке сишарп, там было напеисано про одномерный через индексы, вобщем сам себя запутал и сделал не так, как надо было.
}