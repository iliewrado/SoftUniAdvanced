using System;
using System.Linq;

namespace _05SquareWithMaximumSum
{
    class ProgramSquareWithMaximumSum
    {
        static void Main(string[] args)
        {
            int[] size = ReadIntArrayConsole();

            int[,] matrix = new int[size[0], size[1]];

            for (int i = 0; i < size[0]; i++)
            {
                int[] filler = ReadIntArrayConsole();
                for (int j = 0; j < size[1]; j++)
                {
                    matrix[i, j] = filler[j];
                }
            }
            int sum = 0;
            int total = 0;
            int row = 0;
            int col = 0;
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1)-1; j++)
                {
                    sum += matrix[i, j] + matrix[i, j+1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                    if (sum > total)
                    {
                        total = sum;
                        row = i;
                        col = j;
                    }
                    sum = 0;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"{matrix[row + i, col]} {matrix[row + i , col + 1]}");
            }
            Console.WriteLine(total);
        }
        public static int[] ReadIntArrayConsole()
        {
            return Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
