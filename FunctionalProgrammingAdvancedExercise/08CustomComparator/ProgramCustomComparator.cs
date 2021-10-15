using System;
using System.Linq;

namespace _08CustomComparator
{
    class ProgramCustomComparator
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            Func<int, int, int> comperator = (num, num1) =>
            (num % 2 == 0 && num1 % 2 != 0) ? -1 :
            (num % 2 != 0 && num1 % 2 == 0) ? 1 :
            num.CompareTo(num1);

            Array.Sort(numbers, new Comparison<int>(comperator));
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
