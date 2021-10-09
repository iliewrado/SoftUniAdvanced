using System;
using System.Collections.Generic;
using System.Linq;

namespace _04FastFood
{
    class ProgramFastFood
    {
        static void Main(string[] args)
        {
            int foodQty = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> orderQty = new Queue<int>(orders);
            int biggest = 0;

            foreach (var num in orderQty)
            {
                if (num >= biggest)
                {
                    biggest = num;
                }
            }
            Console.WriteLine(biggest);

            while (orderQty.Count > 0)
            {
                if (foodQty >= orderQty.Peek())
                {
                    foodQty -= orderQty.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (orderQty.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(' ', orderQty)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
