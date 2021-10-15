using System;
using System.Collections.Generic;
using System.Linq;

namespace _07PredicateForNames
{
    class ProgramPredicateForNames
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> filter = (name, length) => name.Length <= length;
            int nameLength = int.Parse(Console.ReadLine());
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => filter(x, nameLength))
                .ToList()
                .ForEach(name => Console.WriteLine(name));
        }
    }
}
