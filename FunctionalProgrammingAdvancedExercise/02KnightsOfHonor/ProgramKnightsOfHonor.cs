using System;
using System.Linq;

namespace _02KnightsOfHonor
{
    class ProgramKnightsOfHonor
    {
        static void Main(string[] args)
        {
            Action<string> names = name => Console.WriteLine($"Sir {name}");

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(names);
        }
    }
}
