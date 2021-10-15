using System;
using System.Collections.Generic;
using System.Linq;

namespace _06ReverseAndExclude
{
    class ProgramReverseAndExclude
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> toRemove = (a, b) => a % b != 0;
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int dev = int.Parse(Console.ReadLine());
            List<int> numbers = input
                .Where(x => toRemove(x, dev))
                .Reverse()
                .ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
