using System;
using System.Collections.Generic;
using System.Linq;

namespace _01BasicStackOperations
{
    class ProgramBasicStackOperations
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int pops = input[1];
            int lokingFor = input[2];

            int[] temp = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>(temp);

            for (int i = 0; i < pops; i++)
            {
                numbers.Pop();
            }

            bool isFound = false;

            foreach (var num in numbers)
            {
                if (num == lokingFor)
                {
                    isFound = true;
                    Console.WriteLine(isFound.ToString().ToLower());
                    break;
                }
            }
            if (isFound != true)
            {
                if (numbers.Count == 0)
                {
                    Console.WriteLine(numbers.Count);
                }
                else
                {
                    int small = int.MaxValue;
                    while (numbers.Count > 0)
                    {
                        if (numbers.Peek() <= small)
                        {
                            small = numbers.Pop();
                        }
                        else
                        {
                            numbers.Pop();
                        }
                    }
                    Console.WriteLine(small);
                }
            }
        }
    }
}
