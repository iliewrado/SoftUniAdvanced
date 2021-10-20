using System;
using System.Linq;

namespace _02Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = ReadIntArray();
            int[,] garden = new int[dimensions[0], dimensions[1]];
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    garden[i, j] = 0;
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] position = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                if (ifIsIn(position[0], position[1], garden))
                {
                    for (int i = 0; i < garden.GetLength(0); i++)
                    {
                        garden[position[0], i] += 1;
                    }
                    for (int i = 0; i < garden.GetLength(1); i++)
                    {
                        garden[i, position[1]] += 1;
                    }
                    garden[position[0], position[1]] = 1;
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
            }
            PrintMatrix(garden);
        }

        private static void PrintMatrix(int[,] garden)
        {
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    Console.Write(garden[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool ifIsIn(int row, int col, int[,] field)
        {
            return row >= 0 && col >= 0
                && row < field.GetLength(0)
                && col < field.GetLength(1); 
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
