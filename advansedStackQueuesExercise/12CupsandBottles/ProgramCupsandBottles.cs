using System;
using System.Collections.Generic;
using System.Linq;

namespace _12CupsandBottles
{
    class ProgramCupsandBottles
    {
        static void Main(string[] args)
        {
            int[] cupSequence = IntArrayConsoleReadLine();
            int[] bottleSequence = IntArrayConsoleReadLine();

            Stack<int> bottles = new Stack<int>(bottleSequence);
            Queue<int> cups = new Queue<int>(cupSequence);

            int wastedWater = 0;

            while (bottles.Count > 0 && cups.Count > 0)
            {
                if (bottles.Peek() >= cups.Peek())
                {
                    wastedWater += bottles.Pop() - cups.Dequeue();
                }
                else
                {
                    int temp = cups.Peek();
                    while (temp > 0)
                    {
                        temp -= bottles.Pop();
                        if (bottles.Count == 0)
                        {
                            break;
                        }
                    }
                    if (temp <= 0)
                    {
                        cups.Dequeue();
                        wastedWater += Math.Abs(temp);
                    }
                }
            }
            if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(' ', cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }

        private static int[] IntArrayConsoleReadLine()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
