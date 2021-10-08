using System;
using System.Linq;

namespace _02SumMatrixColumns
{
    class ProgramSumMatrixColumns
    {
        static void Main(string[] args)
        {
            int[] size = ReadIntArrayConsole();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] filler = ReadIntArrayConsole();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = filler[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;
                for (int raw = 0; raw < matrix.GetLength(0); raw++)
                {
                    sum += matrix[raw, col];
                }
                Console.WriteLine(sum);
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
