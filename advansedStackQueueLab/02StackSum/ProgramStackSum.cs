using System;
using System.Collections.Generic;
using System.Linq;

namespace _02StackSum
{
    class ProgramStackSum
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numberStack = new Stack<int>(numbers);

            string input = string.Empty;

            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (command[0].ToLower() == "add")
                {
                    numberStack.Push(int.Parse(command[1]));
                    numberStack.Push(int.Parse(command[2]));
                }
                else
                {
                    int num = int.Parse(command[1]);
                    if (num < numberStack.Count)
                    {
                        for (int i = 0; i < num; i++)
                        {
                            numberStack.Pop();
                        }
                    }
                }
            }
            int sum = 0;
            foreach (var num in numberStack)
            {
                sum += num;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
