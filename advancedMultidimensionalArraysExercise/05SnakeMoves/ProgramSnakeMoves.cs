using System;
using System.Linq;

namespace _05SnakeMoves
{
    class ProgramSnakeMoves
    {
        static void Main(string[] args)
        {
            int[] size = ReadIntArrayConsole();

            char[,] matrix = new char[size[0], size[1]];

            string snake = Console.ReadLine();
            int c = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = snake[c];
                        c++;
                        if (c == snake.Length)
                        {
                            c = 0;
                        }
                    }
                }
                else
                {
                    for (int j = matrix.GetLength(1)-1; j >= 0; j--)
                    {
                        matrix[i, j] = snake[c];
                        c++;
                        if (c == snake.Length)
                        {
                            c = 0;
                        }
                    }
                }
            }
            Printmatrix(matrix);
        }
        public static void Printmatrix(char[,] temp)
        {
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    Console.Write($"{temp[i, j]}");
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
