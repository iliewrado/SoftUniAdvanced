using System;
using System.Linq;

namespace _01DiagonalDifference
{
    class ProgramDiagonalDifference
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            int[,] matrix = new int[count, count];

            for (int i = 0; i < count; i++)
            {
                int[] input = ReadIntArrayConsole();
                for (int j = 0; j < count; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            int primarySum = 0;
            for (int i = 0; i < count; i++)
            {
                for (int j = i; j <= i; j++)
                {
                    primarySum += matrix[i, j];
                }
            }
            int secondarySum = 0;
            for (int i = 0, j = count - 1; i < count; i++, j--)
            {
                secondarySum += matrix[i, j];
            }
            int total = Math.Abs(primarySum - secondarySum);
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
