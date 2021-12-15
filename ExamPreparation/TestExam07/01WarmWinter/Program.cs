using System;
using System.Collections.Generic;
using System.Linq;

namespace _01WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] hatsInfo = ReadIntArray();
            int[] scarfsInfo = ReadIntArray();

            List<int> sets = new List<int>();
            Stack<int> hats = new Stack<int>(hatsInfo);
            Queue<int> scarfs = new Queue<int>(scarfsInfo);

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                if (hats.Peek() > scarfs.Peek())
                {
                    int set = hats.Pop() + scarfs.Dequeue();
                    sets.Add(set);
                }
                else if (hats.Peek() < scarfs.Peek())
                {
                    hats.Pop();
                }
                else if (hats.Peek() == scarfs.Peek())
                {
                    scarfs.Dequeue();
                    int hat = 1 + hats.Pop();
                    hats.Push(hat);
                }
            }

            int maxPriceSet = sets.OrderByDescending(x => x).FirstOrDefault();
            Console.WriteLine($"The most expensive set is: {maxPriceSet}");
            Console.WriteLine(string.Join(" ", sets));
        }

        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
