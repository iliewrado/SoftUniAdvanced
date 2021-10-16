using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Froggy
{
    class ProgramFroggy
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Lake<int> stones = new Lake<int>(input);

            Console.WriteLine(string.Join(", ", stones));
        }
    }
}
