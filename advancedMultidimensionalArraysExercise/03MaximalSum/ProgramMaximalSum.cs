using System;
using System.Linq;

namespace _03MaximalSum
{
    class ProgramMaximalSum
    {
        static void Main(string[] args)
        {
            int[] size = ReadIntArrayConsole();

            int[,] matrix = new int[size[0], size[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] filler = ReadIntArrayConsole();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = filler[j];
                }
            }

            int row = 0;
            int col = 0;
            int bigest = 0;

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                        + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                        + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    
                    if (sum > bigest)
                    {
                        bigest = sum;
                        row = i;
                        col = j;
                    }
                }
            }

            int r = row;

            Console.WriteLine($"Sum = {bigest}");

            for (int i = 0; i < 3; i++, r++)
            {
                int c = col;

                for (int j = 0; j < 3; j++, c++)
                {
                    Console.Write($"{matrix[r, c]} ");
                }
                Console.WriteLine();
            }
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
