using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures2
{
    public static class BalancedBSTAdd
    {
        public static int[] GenerateBBSTArray(int[] a)
        {
            if (a == null || a.Length == 0) return null;
            Array.Sort(a);
            int depth = (int)Math.Ceiling(Math.Log(a.Length + 1, 2));
            int tree_size = (int)(Math.Pow(2, depth) - 1);
            int[] ResultBBSTArray = new int[tree_size]; 
            DoGenerateBBSTArray(a, ResultBBSTArray, 0, a.Length - 1, 0);
            return ResultBBSTArray;
        }

        static private void DoGenerateBBSTArray(int[] SortedArray, int[] ResultArray, int SortedLeftIndex, int SortedRightIndex, int ResultArrIndex)
        {
            if (SortedLeftIndex > SortedRightIndex) return;
            int Median = (SortedLeftIndex + SortedRightIndex) / 2;
            ResultArray[ResultArrIndex] = SortedArray[Median];
            DoGenerateBBSTArray(SortedArray, ResultArray, SortedLeftIndex, Median - 1, ResultArrIndex * 2 + 1);
            DoGenerateBBSTArray(SortedArray, ResultArray, Median + 1, SortedRightIndex, ResultArrIndex * 2 + 2);
        }

        // Задание 3. Реализуйте метод удаления узла из двоичного дерева, заданного в виде массива. Несмотря на отсутствие пустых мест, метод должен корректно перестраивать дерево, сохраняя балансировку.
        public static int[] DeleteNodeFromBBST(int[] BBSTArray, int key)
        {
            if (!BBSTArray.Contains(key)) return BBSTArray;
            int[] NewArray = new int[BBSTArray.Length - 1];
            int i = 0;
            bool IsFinded = false;
            foreach (int Node in BBSTArray)
            {
                if (Node == key && IsFinded == false) 
                {
                    IsFinded = true;
                    continue;
                }
                NewArray[i] = Node;
                i++;
            }
            if (IsFinded) return GenerateBBSTArray(NewArray);
                
            return BBSTArray;
        }
        /* Проверяем есть ли искомый ключ, если есть создаем новый массив без него. Этот массив отправляем в уже сделанный метод формирования сбалансированного дерева.
         * Сложность по времени O(nlogn) потому, что производится сортировка при генерации дерева.
         * Сложность по памяти O(n) создаем дополнительные массивы.
         */

        //Задание 4. Подумайте, как ответить на вопрос с картинки (реально, периодически на собесах так подкалывают).
        /*  Сортировка BST за О(1) реальна, так как оно уже отсортированно. Конечно, нужно сделать обход, 
         *  чтобы получить список или массив элементов, но это уже операция обхода. А если реализовывать метод sort, 
         *  то он будет работать за O(1).
         */


        // Рекомендации по решению задач задания 3.

        /* Рефлексия по прошлому заданию. 3. Алгоритм инвертирования дерева.
         * Сделал через обход в ширину, как в рекомендации начиная с корневого узла.
         */

        /* Рефлексия по прошлому заданию. 4. Ищем уровень в дереве, сумма значений узлов на котором максимальна.
         * Как в эталоне сделал через обход в ширину. В отличии от эталона, логику не выносил обход в отдельеый метод.
         */

        /* Рефлексия по прошлому заданию. 5. Восстановление оригинального дерева по префиксу и инфиксу.
         * В отличие от эталона,думал, что нужно обязательно 2 массива. Оказывается достаточного превиксного.
         * Как и в эталоне, разделал массив на части и из них восстанавливал дерево. Правильно подмечено, что 
         * если будут узлы с одинаковыми значениями не получится восстановить дерево.
        */



    }
}