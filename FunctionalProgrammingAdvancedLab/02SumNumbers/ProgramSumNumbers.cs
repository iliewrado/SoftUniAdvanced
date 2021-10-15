using System;
using System.Linq;

namespace _02SumNumbers
{
    class ProgramSumNumbers
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = x => int.Parse(x);
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}
