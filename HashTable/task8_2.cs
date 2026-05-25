using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace AlgorithmsDataStructures
{

    // Задание 3. Реализуйте динамическую хэш-таблицу, которая автоматически увеличивает свой размер, если места перестаёт хватать.
    public class DynHashTable
    {
        public string[] slots;
        public int count;
        public int size;
        public int step;

        public DynHashTable(int stp, int start_size = 17)
        {
            step = stp;
            count = 0;
            if (start_size < 17) start_size = 17;
            MakeArray(start_size);
        }
        public bool IsSimple(int digit)
        {
            bool res = true;
            for (int i = 2; i <= Math.Sqrt(digit); i++)
            {
                if (digit % i == 0)
                {
                    res = false;
                    return res;
                }
            }
            return res;
        }

        public int CalcCapacity(int old_size)
        {
            int new_size = old_size * 2;
            if (IsSimple(new_size)) return new_size;
            while (!IsSimple(new_size))
            {
                new_size++;
            }
            return new_size;
        }

        public void CopyHashTable(DynHashTable new_array, string[] old_array)
        {
            for (int i = 0; i < size; i++)
            {
                if (old_array[i] != null) new_array.Put(old_array[i]);
            }
        }

        public void MakeArray(int new_size)
        {
            if (slots == null)
            {
                slots = new string[new_size];
                size = new_size;
                return;
            }
            DynHashTable new_array = new DynHashTable(step, new_size);
            CopyHashTable(new_array, slots);
            slots = new_array.slots;
            size = new_size;
        }
        public int Put(string value)
        {
            // записываем значение по хэш-функции

            // возвращается индекс слота или -1
            // если из-за коллизий элемент не удаётся разместить 
            if (count >= size)
            {
                int new_size = CalcCapacity(size);
                MakeArray(new_size);
            }
            int idx = SeekSlot(value);
            if (idx == -1) return -1;
            slots[idx] = value;
            count++;
            return idx;
        }
        public int HashFun(string value)
        {
            // всегда возвращает корректный индекс слота
            if (value == null) throw new Exception("В хэш функцию, подано пустое значение");
            int res = 0;
            foreach (var item in value)
            {
                res += (int)item;
            }
            return res % size;
        }
        public int SeekSlot(string value)
        {
            // находит индекс пустого слота для значения, или -1
            int idx = HashFun(value);
            if (slots[idx] == null) return idx;
            for (int i = 0; i < size; i++)
            {
                idx = (idx + step) % size;
                if (slots[idx] == null) return idx;
            }
            return -1;
        }

        public int Find(string value)
        {
            // находит индекс слота со значением, или -1
            int idx = HashFun(value);
            if (slots[idx] == value)
            {
                return idx;
            }
            for (int i = 0; i < size; i++)
            {
                idx = (idx + step) % size;
                if (slots[idx] == value)
                {
                    return idx;
                }
            }
            return -1;
        }

    }
    /* Для реализации данного задания, я взял скелет динамического массива из прошлых занятий и модифицировал его. Добавил новые методы: для рассчета размера(простого), потому, что мы знаем из теории, что лучше брать простой размер и простой шаг,
     * чтобы при поиске свободного слота, для элемента с коллизией, мы не топтались на одном месте, а чаще проходили по пустым слотам. Добавил метод копирования, ведь при увеличении размера, мы не просто переносим значения по индексам, мы 
     * должны заново прохэшировать все значения в новом массиве с учетом его длины, ведь на нашу хэш функцию влияет длина массива. 
     * Сложность по времени такая же, как и у изначального динамического массива, только при реалокации у нас сложность добавления элемента O(n), а так O(1).
     * Сложность по памяти O(n), тут мы уже не работаем с фиксированной длиной, а расширяемся по мере необходисоти.
     */


    // Задание 4. Реализуйте хэш-таблицу, которая использует несколько хэш-функций для каждой операции вставки, чтобы уменьшить вероятность коллизий. Проанализируйте, как это влияет на производительность и вероятность коллизий.
    public class DynDoubleHashTable
    {
        public string[] slots;
        public int count;
        public int size;

        public DynDoubleHashTable(int start_size = 17)
        {
            count = 0;
            if (start_size < 17) start_size = 17;
            MakeArray(start_size);
        }
        public bool IsSimple(int digit)
        {
            bool res = true;
            for (int i = 2; i <= Math.Sqrt(digit); i++)
            {
                if (digit % i == 0)
                {
                    res = false;
                    return res;
                }
            }
            return res;
        }

        public int CalcSize(int old_size)
        {
            int new_size = old_size * 2;
            if (IsSimple(new_size)) return new_size;
            while (!IsSimple(new_size))
            {
                new_size++;
            }
            return new_size;
        }

        public void CopyHashTable(DynDoubleHashTable new_array, string[] old_array)
        {
            for (int i = 0; i < size; i++)
            {
                if (old_array[i] != null) new_array.Put(old_array[i]);
            }
        }

        public void MakeArray(int new_size)
        {
            if (slots == null)
            {
                slots = new string[new_size];
                size = new_size;
                return;
            }
            DynDoubleHashTable new_array = new DynDoubleHashTable(new_size);
            CopyHashTable(new_array, slots);
            slots = new_array.slots;
            size = new_size;
        }
        public int Put(string value)
        {
            // записываем значение по хэш-функции

            // возвращается индекс слота
            if (count >= size)
            {
                int new_size = CalcSize(size);
                MakeArray(new_size);
            }
            int idx = SeekSlot(value);
            slots[idx] = value;
            count++;
            return idx;
        }
        public int HashFun(string value, int i)
        {
            // всегда возвращает корректный индекс слота
            if (value == null) throw new Exception("В хэш функцию, подано пустое значение");
            int res = 0;
            foreach (var item in value)
            {
                res += (int)item;
            }
            int h1 = res % size;
            int h2 = 1 + (res % (size - 1));
            return (h1 + i * h2) % size;
        }
        public int SeekSlot(string value)
        {
            // находит индекс пустого слота для значения
            for (int i = 0; i < size; i++)
            {
                int idx = HashFun(value, i);
                if (slots[idx] == null) return idx;
            }
            MakeArray(CalcSize(size));
            return SeekSlot(value);
        }

        public int Find(string value)
        {
            // находит индекс слота со значением, или -1
            for (int i = 0; i < size; i++)
            {
                int idx = HashFun(value, i);
                if (slots[idx] == null) return -1;
                if (slots[idx] == value) return idx;
            }
            return -1;
        }

    }

    /* Использовал формулу двойного хэширования из теории, данный трюк хорошо влияет на уменьшение вероятности коллизии, ведь мы при попадании в коллизию не просто, как в методе проб используем статичный шаг,
     * а уже с помощью второй хэш функции изменяем шаг в списке и эффективнее ищем пустой слот, для нашего значения. Я кончено не могу оценить силу влияния, но мне кажется, что она явно сильнее, чем просто, 
     * линейное увеличение шага, как в методе проб.
     * Сложность по времени такая же, как у стандартной "однохэшируемой" таблицы.
     * Сложностть по памяти тоже.
     */

    // Задание 5. Организуйте ddos-атаку на вашу исходную хэш-таблицу -- с помощью специально сгенерированных ключей, вызывающих большое число коллизий. Затем модифицируйте хэш-таблицу для защиты от таких атак.
    public class HashTableWithSalt
    {
        public int size;
        public int step;
        public string[] slots;
        public int fullnes;

        public HashTableWithSalt(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];

            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            // всегда возвращает корректный индекс слота
            if (value == null) throw new Exception("В хэш функцию, подано пустое значение");
            int res = 0;
            for (int i = 0; i < value.Length; i++)
            {
                res += (int)value[i] * (i + 1);
            }
            return Math.Abs(res) % size;
        }

        public int SeekSlot(string value)
        {
            // находит индекс пустого слота для значения, или -1
            if (fullnes == size)
            {
                Console.WriteLine("Хэш таблица заполнена");
                return -1;
            }
            int idx = HashFun(value);
            if (slots[idx] == null) return idx;
            for (int i = 0; i < size; i++)
            {
                idx = (idx + step) % size;
                if (slots[idx] == null) return idx;
            }
            return -1;
        }

        public int Put(string value)
        {
            // записываем значение по хэш-функции

            // возвращается индекс слота или -1
            // если из-за коллизий элемент не удаётся разместить 
            if (fullnes == size)
            {
                Console.WriteLine("Хэш таблица заполнена");
                return -1;
            }
            int idx = SeekSlot(value);
            if (idx == -1) return -1;
            slots[idx] = value;
            fullnes++;
            return idx;
        }

        public int Find(string value)
        {
            // находит индекс слота со значением, или -1
            int idx = HashFun(value);
            if (slots[idx] == value)
            {
                return idx;
            }
            for (int i = 0; i < size; i++)
            {
                idx = (idx + step) % size;
                if (slots[idx] == value)
                {
                    return idx;
                }
            }
            return -1;
        }
        /* Сначала пытался делать через соль, но потом понял, что хоть используя динамическую соль или статическую, мы используем ее фиксированную в нашем экземпляре и следовательно,
         * хэш, для нашей базовой хэш функции (суммирование битов символов) будет одинаков хоть с солью, хоть без. Поэтому надо менять хэш функцию, как в криптографических хэш функциях. 
         * Модифицировал ее, чтобы от изменения положения элементов, сумма битов менялась и хэш менялся. 
         * Так же, не мог понять почему изначально в тестах у меня, модифицированная хэш таблица работала медленнее, чем стартовая в десятки раз по тикам. При помощи интернета и ИИ, выяснил, что дело в Just In Time Compiler.
         * К счастью, я как раз, недавно начал читать CLR VIA C# Рихтера, и прочитал про JIT как раз таки узнал, как работает компилятор и что при повторном вызове на тот же метод он не создает под него машинный код,
         * а уже имеет в памяти ссылку на этот машинный код. Благодаря этому, я в тесте, сначала использовал метод для инициализации его в JIT, чтобы он был на равных условиях с изначальным.
         * И мы видим, прирост в скорости, от модификации хэш функции.
         * Сложность по времени для модификации, O(1) равна длине ключа.
         * Сложность по памяти, O(1) ничего не создаем.
         */
    }


    // Рекомендации по решению задач задания 6.

    /* Рефлексия по прошлому заданию. 4. Проверка строки на палиндром.
    Сделал, как в эталонном решении. Тоже шел с начала и с конца и сравнивал элементы до середины.
     */


    /* Рефлексия по прошлому заданию. 5. Минимальный элемент деки за O(1).
     * Сделал не так, как в эталонном решении. Я подумал, что правильно будет сделать, как в прошлых занятиях в стеке, через второй стек для минимумов. 
     * Мне показалось, что его достаточно. Вроде у меня отслеживаются и хвост и голова. По моим тестам все было верно, но возможно надо перепроверить и найдется ошибка.
     */


    /* Рефлексия по прошлому заданию. Двусторонняя очередь на базе динамического массива.
     * Сделал в точности, как не надо было) У меня смешались две разные структуры. Я просто в лоб использовал нужные методы для решения заданной задачи и все.
     * А надо было разделить методы по своим классам и использовать это все, для создания более чистой структуры.
     */
}

