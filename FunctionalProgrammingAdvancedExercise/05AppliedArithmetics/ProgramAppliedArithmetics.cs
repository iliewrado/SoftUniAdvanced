using System;
using System.Collections.Generic;
using System.Linq;

namespace _05AppliedArithmetics
{
    class ProgramAppliedArithmetics
    {
        static void Main(string[] args)
        {
            Func<int, int> add = x => x + 1;
            Func<int, int> subtract = x => x - 1;
            Func<int, int> multiply = x => x * 2;
            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(x => add(x)).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(x => multiply(x)).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(x => subtract(x)).ToList();
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
            }
        }
    }
}
