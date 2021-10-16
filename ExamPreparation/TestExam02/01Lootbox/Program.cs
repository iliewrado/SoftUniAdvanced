using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstBox = ReadIntArray();
            int[] secondBox = ReadIntArray();
            Queue<int> firstItems = new Queue<int>(firstBox);
            Stack<int> secondItems = new Stack<int>(secondBox);
            List<int> claimedItems = new List<int>();

            while (firstItems.Count > 0 && secondItems.Count > 0)
            {
                int sum = firstItems.Peek() + secondItems.Peek();
                if (sum % 2 == 0)
                {
                    secondItems.Pop();
                    firstItems.Dequeue();
                    claimedItems.Add(sum);
                }
                else
                {
                    firstItems.Enqueue(secondItems.Pop());
                }
            }
            if (firstItems.Count <= 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondItems.Count <= 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (claimedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }

        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
