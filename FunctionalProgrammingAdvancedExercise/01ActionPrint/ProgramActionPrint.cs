using System;
using System.Linq;

namespace _01ActionPrint
{
    class ProgramActionPrint
    {
        static void Main(string[] args)
        {
            Action<string> names = name => Console.WriteLine(name);

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(names);
        }
    }
}
