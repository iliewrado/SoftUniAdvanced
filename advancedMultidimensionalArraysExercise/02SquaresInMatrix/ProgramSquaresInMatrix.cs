using System;
using System.Linq;

namespace _02SquaresInMatrix
{
    class ProgramSquaresInMatrix
    {
        static void Main(string[] args)
        {
            int[] size = ReadIntArrayConsole();
            string[,] matrix = new string[size[0], size[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] filler = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = filler[j];
                }
            }
            int count = 0;
            
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1)-1; j++)
                {
                    if (matrix[i, j] == matrix[i, j+1] 
                        && matrix[i,j] == matrix[i+1,j] 
                        && matrix[i,j] == matrix[i+1,j+1])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
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
