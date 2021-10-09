using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FashionBoutique
{
    class ProgramFashionBoutique
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int capacity = int.Parse(Console.ReadLine());
            int racks = 1;
            Stack<int> clothes = new Stack<int>(input);
            int sum = 0;
            while (clothes.Count > 0)
            {
                if (clothes.Peek() + sum <= capacity)
                {
                    sum += clothes.Pop();
                }
                else
                {
                    racks++;
                    sum = 0;
                }
            }
            Console.WriteLine(racks);
        }
    }
}
