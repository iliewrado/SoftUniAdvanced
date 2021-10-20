using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasks = Console.ReadLine().
                Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] thread = Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int killerValue = int.Parse(Console.ReadLine());
            
            Stack<int> tasksValue = new Stack<int>(tasks);
            Queue<int> threadValue = new Queue<int>(thread);
            bool isKilled = false;
            while (isKilled == false)
            {
                if (threadValue.Peek() >= tasksValue.Peek() 
                    && tasksValue.Peek() != killerValue)
                {
                    threadValue.Dequeue();
                    tasksValue.Pop();
                }
                else if (tasksValue.Peek() == killerValue)
                {
                    Console.WriteLine($"Thread with value {threadValue.Peek()} killed task {tasksValue.Pop()}");
                    break;
                }
                else
                {
                    threadValue.Dequeue();
                }
            }
            Console.WriteLine(string.Join(' ', threadValue));
        }
    }
}
