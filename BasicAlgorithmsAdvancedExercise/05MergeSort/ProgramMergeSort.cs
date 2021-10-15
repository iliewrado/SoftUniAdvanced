using System;
using System.Collections.Generic;
using System.Linq;

namespace _05MergeSort
{
    class ProgramMergeSort
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            input = Mergesort<int>.Sort(input);
            Console.WriteLine(string.Join(' ', input));            
        }
        public class Mergesort<T> where T : IComparable
        {
            public static T[] Sort(T[] array)
            {
                int mid = array.Length / 2;
                Merge(array, 0, mid, array.Length - 1);
                return array;
            }
            private static T[] temp;
            private static void Merge(T[] array, int start, int middle, int end)
            {
                Sort(array, start, middle);
                Sort(array, middle + 1, end);

            }
            private static void Sort(T[] array, int start, int end)
            {
                if (start >= end)
                {
                    return;
                }

            }
        }
    }
}
