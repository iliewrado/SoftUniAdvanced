using System;
using System.Collections.Generic;

namespace _07HotPotato
{
    class ProgramHotPotato
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Queue<string> kids = new Queue<string>(names);
            int count = int.Parse(Console.ReadLine());

            while (kids.Count > 1)
            {
                for (int i = 1; i < count; i++)
                {
                    kids.Enqueue(kids.Dequeue());
                }
                Console.WriteLine($"Removed {kids.Dequeue()}");
            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
