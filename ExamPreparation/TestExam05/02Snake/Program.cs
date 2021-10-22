using System;

namespace _02Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] territory = new char[size, size];

            int row = -1;
            int col = -1;

            for (int i = 0; i < size; i++)
            {
                string values = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    territory[i, j] = values[j];
                    if (values[j] == 'S')
                    {
                        row = i;
                        col = j;
                    }
                }
            }

            int foodEaten = 0;
            bool isOut = false;

            while (foodEaten < 10 && isOut == false)
            {
                string command = Console.ReadLine();
                territory[row, col] = '.';
                switch (command)
                {
                    case "up":
                        if (!isOut == IsIn(row - 1, col, size))
                        {
                            row--;
                            TerritoryCheck(territory, ref row, ref col,ref foodEaten);
                        }
                        else
                        {
                            isOut = true;
                        }
                        break;
                    case "down":
                        if (!isOut == IsIn(row + 1, col, size))
                        {
                            row++;
                            TerritoryCheck(territory, ref row, ref col, ref foodEaten);
                        }
                        else
                        {
                            isOut = true;
                        }
                        break;
                    case "left":
                        if (!isOut == IsIn(row, col - 1, size))
                        {
                            col--;
                            TerritoryCheck(territory, ref row, ref col, ref foodEaten);
                        }
                        else
                        {
                            isOut = true;
                        }
                        break;
                    case "right":
                        if (!isOut == IsIn(row, col + 1, size))
                        {
                            col++;
                            TerritoryCheck(territory, ref row, ref col, ref foodEaten);
                        }
                        else
                        {
                            isOut = true;
                        }
                        break;
                }
            }

            Console.WriteLine(foodEaten == 10 ? "You won! You fed the snake." : "Game over!");
            Console.WriteLine($"Food eaten: {foodEaten}");
            PrintMatrix(size, territory);
        }

        private static void TerritoryCheck(char[,] territory,ref int row,ref int col,ref int foodEaten)
        {
            if (territory[row, col] == '*')
            {
                foodEaten++;
                territory[row, col] = 'S';
            }
            else if (territory[row, col] == 'B')
            {
                BurrowsMove(territory, ref row, ref col);
            }
            else
            {
                territory[row, col] = 'S';
            }
        }

        private static void BurrowsMove(char[,] territory, ref int row, ref int col)
        {
            for (int i = row; i < territory.GetLength(0); i++)
            {
                if (i > row)
                {
                    for (int j = 0; j < territory.GetLength(1); j++)
                    {
                        if (territory[i, j] == 'B')
                        {
                            territory[row, col] = '.';
                            row = i;
                            col = j;
                            territory[i, j] = 'S';
                            return;
                        }
                    }
                }
                else
                {
                    for (int j = col+1; j < territory.GetLength(1); j++)
                    {
                        if (territory[i, j] == 'B')
                        {
                            row = i;
                            col = j;
                            territory[i, j] = 'S';
                            return;
                        }
                    }
                }
            }
        }

        private static void PrintMatrix(int size, char[,] territory)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(territory[i, j]);
                }
                Console.WriteLine();
            }
        }
        private static bool IsIn(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }
    }
}
