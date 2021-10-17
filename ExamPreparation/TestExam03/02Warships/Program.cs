using System;
using System.Linq;

namespace _02Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] coordinateSets = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            char[,] battleField = new char[size, size];
            int playerOneShips = 0;
            int playerTwoShips = 0;
            int totalCountShipsDestroyed = 0;

            for (int i = 0; i < size; i++)
            {
                char[] fieldLine = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < size; j++)
                {
                    battleField[i, j] = fieldLine[j];
                    if (battleField[i, j] == '<')
                    {
                        playerOneShips++;
                    }
                    else if (battleField[i, j] == '>')
                    {
                        playerTwoShips++;
                    }
                }
            }

            for (int i = 0; i < coordinateSets.Length; i++)
            {
                if (playerOneShips <= 0 || playerTwoShips <= 0)
                {
                    break;
                }
                int[] coordinates = coordinateSets[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int row = coordinates[0];
                int col = coordinates[1];
                if (!ifIsIn(battleField, row, col))
                {
                    continue;
                }
                if (battleField[row, col] == '#')
                {
                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            totalCountShipsDestroyed = ShipsCount
                            (battleField, totalCountShipsDestroyed, 
                            row+k, col+l, ref playerOneShips, ref playerTwoShips);
                        }
                    }
                    
                }

                if (battleField[row, col] == '>')
                {
                    playerTwoShips--;
                    totalCountShipsDestroyed++;
                    battleField[row, col] = 'X';
                }
                else if (battleField[row, col] == '<')
                {
                    playerOneShips--;
                    totalCountShipsDestroyed++;
                    battleField[row, col] = 'X';
                }
            }
            if (playerOneShips > 0 && playerTwoShips > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }
            else if (playerOneShips <= 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
            }
            else if (playerTwoShips <= 0)
            {
                Console.WriteLine($"Player One has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
            }
        }

        private static int ShipsCount(char[,] battleField, int countShipsDestroyed, int row, int col, ref int playerOne, ref int playerTwo)
        {
            if (ifIsIn(battleField, row, col))
            {
                if (battleField[row, col] == '>'
                    || battleField[row, col] == '<')
                {
                    countShipsDestroyed++;
                    if (battleField[row, col] == '<')
                    {
                        playerOne--;
                    }
                    else if (battleField[row, col] == '>')
                    {
                        playerTwo--;
                    }
                    battleField[row, col] = 'X';
                }
            }
            return countShipsDestroyed;
        }

        private static bool ifIsIn(char[,] battleField, int row, int col)
        {
            return row >= 0 && col >= 0
                                && row < battleField.GetLength(0)
                                && col < battleField.GetLength(1);
        }

        private static void PrintMatrix(char[,] battleField)
        {
            for (int i = 0; i < battleField.GetLength(0); i++)
            {
                for (int j = 0; j < battleField.GetLength(1); j++)
                {
                    Console.Write(battleField[i, j] + ' '.ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
