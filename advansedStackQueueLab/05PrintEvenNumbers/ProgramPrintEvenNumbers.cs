using System;
using System.Collections.Generic;
using System.Linq;

namespace _05PrintEvenNumbers
{
    class ProgramPrintEvenNumbers
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbers = new Queue<int>(integers);
            Queue<int> even = new Queue<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers.Peek() % 2 == 0)
                {
                    even.Enqueue(numbers.Dequeue());
                }
                else
                {
                    numbers.Dequeue();
                }
                i--;
            }
            Console.WriteLine(string.Join(", ", even));
        }
    }
}
