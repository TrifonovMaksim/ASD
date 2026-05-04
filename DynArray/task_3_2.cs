using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    // Задание 6 Реализуйте динамический массив на основе банковского метода.
    public class BankDynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;
        public int balance;
        public BankDynArray()
        {
            count = 0;
            MakeArray(16);
            balance = 0;
        }

        public void MakeArray(int new_capacity)
        {
            T[] new_array = new T[new_capacity];
            if (array == null)
            {
                array = new_array;
                capacity = new_capacity;
                return;
            }
            Array.Copy(array, 0, new_array, 0, count);
            array = new_array;
            capacity = new_capacity;
        }

        public T GetItem(int index)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException("Некорректный индекс");
            return array[index];
        }

        public void Append(T itm)
        {
            balance += 3;
            if (count >= capacity)
            {
                int new_capacity = capacity * 2;
                if (balance < Cost(new_capacity)) throw new Exception("Кончился баланс");
                MakeArray(new_capacity);
                balance -= Cost(new_capacity);
            }
            array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            balance += 3;
            bool is_alocated = false;
            if (index < 0 || index > count) throw new IndexOutOfRangeException("Некорректный индекс");
            int new_count = count + 1;
            if (new_count > capacity)
            {
                int new_capacity = capacity * 2;
                if (balance < Cost(new_capacity)) throw new Exception("Кончился баланс");
                MakeArray(new_capacity);
                balance -= Cost(new_capacity);
            }
            for (int i = count - 1; i >= index; i--)
            {
                array[i + 1] = array[i];
                if (is_alocated == false) balance += 3;
                
            }
            array[index] = itm;
            count = new_count;
        }

        public void Remove(int index)
        {
            balance += 3;
            if (index < 0 || index > count - 1) throw new IndexOutOfRangeException("Некорректный индекс");
            for (int i = index; i < count - 1; i++)
            {
                array[i] = array[i + 1];
                balance += 3;
            }
            count -= 1;
            if ((int)(capacity / 1.5) > count && capacity > 16)
            {
                int new_capacity = ((int)(capacity / 1.5) > 16 ? (int)(capacity / 1.5) : 16);
                if (balance < Cost(new_capacity)) throw new Exception("Кончился баланс");
                MakeArray(new_capacity);
                balance -= Cost(new_capacity);
            }
        }

        int Cost(int capacity)
        {
            return (int)Math.Pow(2, Math.Floor(Math.Log(capacity, 2)));
        }
    }
    /* Сначала думал, как сделать, потом пришел к тому, что надо, как сказанно просто добавить баланс и работать с ним исходя из операций.
     */

    // Задание 7 Реализуйте многомерный динамический массив: произвольное количество измерений, при этом каждое измерение может внутри масштабироваться по потребности.
    // В конструкторе задаётся число измерений и размер по каждому из них. Обращаться к такому массиву надо как к обычному многомерному, например: myArr[1,2,3].
    public class MultiDynArray<T>
    {
        DynArray<object> arrays;
        int[] size;

        public MultiDynArray(params int[] size)
        {
            if (size.Length == 0 || size == null) throw new Exception("Не дана размерность");
            this.size = size;
            arrays = MakeArray(size);
        }
        public DynArray<object> MakeArray(int[] size)
        {
            DynArray<object> array = new DynArray<object>();
            for(int i = 0; i < size[0]; i++)
            {
                if (size.Length == 1) break;
                else
                {
                    int[] to_copy = new int[size.Length - 1];
                    Array.Copy(size, 1, to_copy, 0, to_copy.Length);
                    array.Append(MakeArray(to_copy));
                }
            }
            return array;
        }
        public T GetItem(int[] index, int pos_index)
        {
            T item = default(T);
            var current_array = arrays;
            for (int i = 0; i < index.Length; i ++) current_array = (DynArray<object>)current_array.GetItem(index[i]);
            item = (T)current_array.GetItem(pos_index);
            return item;
        }

        public void Append(T itm, int[] index)
        {
            var current_array = arrays;
            for (int i = 0; i < index.Length; i++) current_array = (DynArray<object>)current_array.GetItem(index[i]);
            current_array.Append(itm);
        }

        public void Insert(T itm, int[] index, int pos_index)
        {
            var current_array = arrays;
            for (int i = 0; i < index.Length; i++) current_array = (DynArray<object>)current_array.GetItem(index[i]);
            current_array.Insert(itm,pos_index);
        }

        public void Remove (int[] index, int pos_index)
        {
            var current_array = arrays;
            for (int i = 0; i < index.Length; i++) current_array = (DynArray<object>)current_array.GetItem(index[i]);
            current_array.Remove(pos_index);
        }
    }
    /* Делал 2 дня, не мог понять, как лучше делать.
     * Сначала подумал, что логично использовать уже имеющийся класс, одномерного динамического массива, но показалось сначала, что это очень сложно.
     * В интернете нашел, что стандартная библиотека C# создает многомерный массив как одномерный и просто работает с индексами.
     * Сначала пытался сделать, как в стандартной библиотеке, ушел целый день. Не получилось нормально.
     * Потом спросил у ИИ, как лучше реализовать, он сказал, что лучше сделать через вложенные массивы, так и сделал.
     * Суть работы такова, создается корневой массив, который хранит тип обджект, в нем мы храним другие массивы, а уже в самом верхнем уровне у нам классический одномерный динамический массив.
     * Для работы методов, мы начиная с корневого, спускаемся "вниз" и идем до нужного нам массива через гетайтем встроенный в одномерный динамический массив. Затем когда мы дошли до нужного нам уровня, мы используем нужный нам метод из одномерного массива.
     */
}


