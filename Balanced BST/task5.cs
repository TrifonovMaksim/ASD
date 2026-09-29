using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures2
{
    public static class BalancedBST
    {
        public static int[] GenerateBBSTArray(int[] a)
        {
            int[] ResultBBSTArray = new int[a.Length];
            Array.Sort(a);
            DoGenerateBBSTArray(a,  ResultBBSTArray, 0, a.Length - 1, 0);
            return ResultBBSTArray;
        }

        static private void DoGenerateBBSTArray(int[] SortedArray,  int[] ResultArray, int SortedLeftIndex, int SortedRightIndex, int ResultArrIndex)
        {
            if (SortedLeftIndex > SortedRightIndex) return;
            int Median = (SortedLeftIndex + SortedRightIndex) / 2;
            ResultArray[ResultArrIndex] = SortedArray[Median];
            DoGenerateBBSTArray(SortedArray,  ResultArray, SortedLeftIndex, Median - 1, ResultArrIndex * 2 + 1);
            DoGenerateBBSTArray(SortedArray,  ResultArray, Median + 1, SortedRightIndex, ResultArrIndex * 2 + 2);
        }
    }

    /* Задание 2.Оцените, насколько поиск узла в дереве, представленном в виде массива, эффективнее (или неэффективнее) поиска узла в классическом дереве с указателями.
     * Я думаю, что работа в массиве в целом эффективнее. Засчет того, что мы двигаемся не по ссылкам, а по индексам массива.
    */

}