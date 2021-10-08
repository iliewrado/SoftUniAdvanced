using System;
using System.Linq;

namespace _01SumMatrixElements
{
    class ProgramSumMatrixElements
    {
        static void Main(string[] args)
        {
            int[] size = ReadIntArrayConsole();

            int[,] matrix = new int[size[0], size[1]];
            int sum = 0;
            for (int rols = 0; rols < matrix.GetLength(0); rols++)
            {
                int[] filling = ReadIntArrayConsole();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rols, cols] = filling[cols];
                    sum += filling[cols];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }

        public static int[] ReadIntArrayConsole()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
