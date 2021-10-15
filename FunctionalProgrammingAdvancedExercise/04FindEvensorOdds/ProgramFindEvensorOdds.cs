using System;
using System.Collections.Generic;
using System.Linq;

namespace _04FindEvensorOdds
{
    class ProgramFindEvensorOdds
    {
        static void Main(string[] args)
        {
            Predicate<int> even = x => x % 2 == 0;
            Predicate<int> odd = x => x % 2 != 0;
            int[] bouderies = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int start = bouderies[0];
            int end = bouderies[1];
            string command = Console.ReadLine();
            List<int> numbers = new List<int>();
            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            switch (command)
            {
                case "even":
                    Console.WriteLine(string.Join(" ", numbers.Where(x => even(x))));
                    break;
                case "odd":
                    Console.WriteLine(string.Join(" ", numbers.Where(x => odd(x))));
                    break;
            }
        }
    }
}
