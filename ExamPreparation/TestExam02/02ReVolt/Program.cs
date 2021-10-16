using System;

namespace _02ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int count = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int row = -1;
            int col = -1;
            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = input[j];
                    if (matrix[i, j] == 'f')
                    {
                        row = i;
                        col = j;
                    }
                }
            }
            bool gameOver = false;
            for (int i = 0; i < count; i++)
            {
                string command = Console.ReadLine();
                matrix[row, col] = '-';
                switch (command)
                {
                    case "up":
                        if (row - 1 < 0)
                        {
                            row = matrix.GetLength(0) - 1;
                        }
                        else
                        {
                            row--;
                        }
                        switch (matrix[row,col])
                        {
                            case 'F':
                                matrix[row, col] = 'f';
                                gameOver = true;
                                break;
                            case 'T':
                                row++;
                                if (row >= matrix.GetLength(0))
                                {
                                    row = 0;
                                }
                                break;
                            case 'B':
                                row--;
                                if (row < 0)
                                {
                                    row = matrix.GetLength(0) - 1;
                                }
                                break;
                        }
                        break;
                    case "down":
                        if (row + 1 >= matrix.GetLength(0))
                        {
                            row = 0;
                        }
                        else
                        {
                            row++;
                        }
                        switch (matrix[row, col])
                        {
                            case 'F':
                                matrix[row, col] = 'f';
                                gameOver = true;
                                break;
                            case 'T':
                                row--;
                                if (row < 0)
                                {
                                    row = matrix.GetLength(0) - 1;
                                }
                                break;
                            case 'B':
                                row++;
                                if (row >= matrix.GetLength(0))
                                {
                                    row = 0;
                                }
                                break;
                        }
                        break;
                    case "left":
                        if (col - 1 < 0)
                        {
                            col = matrix.GetLength(1) - 1;
                        }
                        else
                        {
                            col--;
                        }
                        switch (matrix[row, col])
                        {
                            case 'F':
                                matrix[row, col] = 'f';
                                gameOver = true;
                                break;
                            case 'T':
                                col++;
                                if (col >= matrix.GetLength(1))
                                {
                                    col = 0;
                                }
                                break;
                            case 'B':
                                col--;
                                if (col < 0)
                                {
                                    col = matrix.GetLength(1) - 1;
                                }
                                break;
                        }
                        break;
                    case "right":
                        if (col + 1 >= matrix.GetLength(1))
                        {
                            col = 0;
                        }
                        else
                        {
                            col++;
                        }
                        switch (matrix[row, col])
                        {
                            case 'F':
                                matrix[row, col] = 'f';
                                gameOver = true;
                                break;
                            case 'T':
                                col--;
                                if (col < 0)
                                {
                                    col = matrix.GetLength(1);
                                }
                                break;
                            case 'B':
                                col++;
                                if (col >= 0)
                                {
                                    col = 0;
                                }
                                break;
                        }
                        break;
                }
                matrix[row, col] = 'f';
                if (gameOver)
                {
                    break;
                }
            }

            if (gameOver)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
