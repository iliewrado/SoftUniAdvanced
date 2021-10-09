using System;
using System.Collections.Generic;
using System.Linq;

namespace _02BasicQueueOperations
{
    class ProgramBasicQueueOperations
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

            Queue<int> numbers = new Queue<int>(temp);

            for (int i = 0; i < pops; i++)
            {
                numbers.Dequeue();
            }
            bool isfound = false;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers.Peek() == lokingFor)
                {
                    isfound = true;
                    Console.WriteLine(isfound.ToString().ToLower());
                    break;
                }
                numbers.Enqueue(numbers.Dequeue());
            }
            if (isfound != true)
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
                            small = numbers.Dequeue();
                        }
                        else
                        {
                            numbers.Dequeue();
                        }
                    }
                    Console.WriteLine(small);
                }
            }
        }
    }
}
