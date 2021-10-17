using System;
using System.Collections.Generic;

namespace _03PeriodicTable
{
    class ProgramPeriodicTable
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in input)
                {
                    elements.Add(item);
                }
            }

            Console.Write(string.Join(' ', elements));
        }
    }
}
