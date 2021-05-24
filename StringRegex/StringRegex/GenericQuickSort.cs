using System;
using System.Collections.Generic;
using System.Text;

namespace StringRegex
{
    public class GenericQuickSort
    {
        public void Sort<T>(T[] array, int firstIndex, int lastIndex) where T : IComparable<T>
        {
            if (firstIndex >= lastIndex) return;
            int c = Swap(array, firstIndex, lastIndex);
            Sort<T>(array, firstIndex, c - 1);
            Sort<T>(array, c + 1, lastIndex);
        }

        public int Swap<T>(T[] array, int firstIndex, int lastIndex) where T : IComparable<T>
        {
            int i = firstIndex;
            for (int j = firstIndex; j <= lastIndex; j++)
            {
                if (array[j].CompareTo(array[lastIndex]) <= 0)
                {
                    T t = array[i];
                    array[i] = array[j];
                    array[j] = t;
                    i++;
                }
            }
            return i - 1;
        }
    }
}
