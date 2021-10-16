using System;
using System.Linq;

namespace GenericSwapMethodInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Box<int> numbers = new Box<int>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());
                numbers.Add(input);
            }
            int[] swapIndexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            numbers.Swap(numbers, swapIndexes[0], swapIndexes[1]);

            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine($"{numbers[i].GetType().FullName}: {numbers[i]}");
            }
        }
    }
}
