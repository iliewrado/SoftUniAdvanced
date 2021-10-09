using System;
using System.Collections.Generic;
using System.Linq;

namespace _11KeyRevolver
{
    class ProgramKeyRevolver
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bulletSiquence = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] lockSiquence = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int valuePrice = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(bulletSiquence);
            Queue<int> locks = new Queue<int>(lockSiquence);

            int count = 0;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                if (bullets.Peek() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    bullets.Pop();
                    count++;
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                    count++;
                }
                if (count == barrelSize && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    count = 0;
                }
            }
            double buletCost = bulletPrice * (bulletSiquence.Length - bullets.Count);
            double profit = valuePrice - buletCost;
            if (bullets.Count < locks.Count)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${profit}");
            }
        }
    }
}
