using System;
using System.Collections.Generic;
using System.Linq;

namespace _02SetsOfElements
{
    class ProgramSetsOfElements
    {
        static void Main(string[] args)
        {
            int[] nm = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = nm[0];
            int m = nm[1];
            HashSet<int> numbersN = new HashSet<int>();
            HashSet<int> numbersM = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbersN.Add(number);
            }
            for (int i = 0; i < m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbersM.Add(number);
            }

            HashSet<int> appearence = new HashSet<int>();

            foreach (var item in numbersN)
            {
                foreach (var num in numbersM)
                {
                    if (item == num)
                    {
                        appearence.Add(item);
                    }
                }
            }
            Console.WriteLine(string.Join(' ', appearence));
        }
    }
}
