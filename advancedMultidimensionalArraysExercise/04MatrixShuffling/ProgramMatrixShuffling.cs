using System;
using System.Linq;

namespace _04MatrixShuffling
{
    class ProgramMatrixShuffling
    {
        static void Main(string[] args)
        {
            int[] size = ReadIntArrayConsole();

            string[,] matrix = MatrixFiller(size[0], size[1]);

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] temp = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (temp[0] != "swap" || temp.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int row1 = int.Parse(temp[1]);
                    int col1 = int.Parse(temp[2]);
                    int row2 = int.Parse(temp[3]);
                    int col2 = int.Parse(temp[4]);

                    if (row1 >= 0 && row1 < matrix.GetLength(0)
                        && row2 >= 0 && row2 < matrix.GetLength(0)
                        && col1 >= 0 && col1 < matrix.GetLength(1)
                        && col2 >= 0 && col2 < matrix.GetLength(1))
                    {
                        string oldPlace = matrix[row1, col1];
                        string newPlace = matrix[row2, col2];
                        matrix[row2, col2] = oldPlace;
                        matrix[row1, col1] = newPlace;
                        Printmatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
            }
        }
        public static int[] ReadIntArrayConsole()
        {
            return Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
        public static string[] ReadStringArrayConsole()
        {
            return Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public static void Printmatrix(string[,] temp)
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
        static string[,] MatrixFiller(int i, int j)
        {
            string[,] temp = new string[i, j];

            for (i = 0; i < temp.GetLength(0); i++)
            {
                string[] input = ReadStringArrayConsole();
                for (j = 0; j < temp.GetLength(1); j++)
                {
                    temp[i, j] = input[j];
                }
            }
            return temp;
        }
    }
}
