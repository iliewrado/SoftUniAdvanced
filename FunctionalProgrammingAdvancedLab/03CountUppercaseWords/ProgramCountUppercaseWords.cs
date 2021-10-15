using System;
using System.Linq;

namespace _03CountUppercaseWords
{
    class ProgramCountUppercaseWords
    {
        static void Main(string[] args)
        {
            Predicate<string> toUpper = str => char.IsUpper(str[0]);

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => toUpper(x))
                .ToList()
                .ForEach(word => Console.WriteLine(word));
        }
    }
}
