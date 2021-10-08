using System;
using System.Linq;

namespace _03PrimaryDiagonal
{
    class ProgramPrimaryDiagonal
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] filler = ReadIntArrayConsole();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = filler[col];
                }
            }
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = i; j <= i; j++)
                {
                    sum += matrix[i, j];
                }
            }
            Console.WriteLine(sum);

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
