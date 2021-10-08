using System;
using System.Collections.Generic;
using System.Linq;

namespace _08Bombs
{
    class ProgramBombs
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = IntMatrixFiller(size, size);
            string[] bombs = ReadStringArrayConsole();
            List<List<int>> coordinates = new List<List<int>>();
            foreach (var item in bombs)
            {
                coordinates.Add(item
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList());
            }
            foreach (var item in coordinates)
            {
                int r = item[0];
                int c = item[1];

                if (r >= 0 && r < matrix.GetLength(0) 
                    && c >= 0 && c < matrix.GetLength(1)
                    && matrix[r,c] > 0)
                {
                    if (r-1 >= 0 && c-1 >= 0 && matrix[r - 1, c - 1] > 0)
                    {
                        matrix[r - 1, c - 1] -= matrix[r, c];
                    }
                    if (r - 1 >= 0 && matrix[r - 1, c] > 0)
                    {
                        matrix[r - 1, c] -= matrix[r, c];
                    }
                    if (r - 1 >= 0 && c + 1 < matrix.GetLength(1) 
                        && matrix[r - 1, c + 1] > 0)
                    {
                        matrix[r - 1, c + 1] -= matrix[r, c];
                    }
                    if (c - 1 >= 0 && matrix[r, c - 1] > 0)
                    {
                        matrix[r, c - 1] -= matrix[r, c];
                    }
                    if (c + 1 < matrix.GetLength(1) && matrix[r, c + 1] > 0)
                    {
                        matrix[r, c + 1] -= matrix[r, c];
                    }
                    if (r + 1 < matrix.GetLength(0) && c - 1 >= 0 
                        && matrix[r + 1, c - 1] > 0)
                    {
                        matrix[r + 1, c - 1] -= matrix[r, c];
                    }
                    if (r + 1 < matrix.GetLength(0) && matrix[r + 1, c] > 0)
                    {
                        matrix[r + 1, c] -= matrix[r, c];
                    }
                    if (r + 1 < matrix.GetLength(0) 
                        && c + 1 < matrix.GetLength(1) 
                        && matrix[r + 1, c + 1] > 0)
                    {
                        matrix[r + 1, c + 1] -= matrix[r, c];
                    }

                    matrix[r, c] = 0;
                }
            }

            int count = 0;
            int sum = 0;
            foreach (var item in matrix)
            {
                if (item > 0)
                {
                    count++;
                    sum += item;
                }
            }
            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");
            Printmatrix(matrix);
        }
        public static string[] ReadStringArrayConsole()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
        static int[,] IntMatrixFiller(int i, int j)
        {
            int[,] temp = new int[i, j];

            for (i = 0; i < temp.GetLength(0); i++)
            {
                int[] input = ReadIntArrayConsole();
                for (j = 0; j < temp.GetLength(1); j++)
                {
                    temp[i, j] = input[j];
                }
            }
            return temp;
        }
        public static int[] ReadIntArrayConsole()
        {
            return Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
        public static void Printmatrix(int[,] temp)
        {
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    Console.Write($"{temp[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
