using System;
using System.Collections.Generic;
using System.Linq;

namespace _01FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liliInput = ReadIntArray();
            int[] rosesInput = ReadIntArray();
            Stack<int> lilies = new Stack<int>(liliInput);
            Queue<int> roses = new Queue<int>(rosesInput);
            int wreath = 0;
            int flowers = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int lili = lilies.Pop();
                int rose = roses.Dequeue();

                CheckFlowerSum(ref wreath, ref flowers, ref lili, rose);
            }

            while (flowers >= 15)
            {
                flowers -= 15;
                wreath++;
            }

            Console.WriteLine(wreath >= 5 ? $"You made it, you are going to the competition with {wreath} wreaths!" 
                : $"You didn't make it, you need {5 - wreath} wreaths more!");
        }

        private static void CheckFlowerSum(ref int wreath, ref int flowers, ref int lili, int rose)
        {
            if (lili + rose == 15)
            {
                wreath++;
            }
            else if (lili + rose > 15)
            {
                lili -= 2;
                CheckFlowerSum(ref wreath, ref flowers, ref lili, rose);
            }
            else if (lili + rose < 15)
            {
                flowers += lili + rose;
            }
        }

        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
        }
    }
}
