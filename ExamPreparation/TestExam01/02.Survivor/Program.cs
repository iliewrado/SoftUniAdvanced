using System;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            string[][] beach = new string[lines][];
            for (int i = 0; i < lines; i++)
            {
                beach[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            int playerTokens = 0;
            int opponentTokens = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Gong")
            {
                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                if (command[0] == "Find")
                {
                    if (isIn(beach, row, col))
                    {
                        istoken(ref beach, row, col, ref playerTokens);
                    }
                }
                else if (command[0] == "Opponent")
                {
                    string direction = command[3];
                    if (isIn(beach, row, col))
                    {
                        istoken(ref beach, row, col, ref opponentTokens);
                    }
                    else
                    {
                        continue;
                    }
                    OponentMooves(ref beach, ref opponentTokens, ref row, ref col, direction);
                }
            }

            PrintArray(beach);
            Console.WriteLine($"Collected tokens: {playerTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }
        private static void PrintArray(string[][] beach)
        {
            for (int i = 0; i < beach.Length; i++)
            {
                Console.WriteLine(string.Join(' ', beach[i]));
            }
        }

        private static void istoken(ref string[][] map, int row, int col, ref int playerTokens)
        {
            if (map[row][col] == "T")
            {
                map[row][col] = "-";
                playerTokens++;
            }
        }

        private static bool isIn(string[][] map, int row, int col)
        {
            return row >= 0 && row < map.Length
                && col >= 0 && col < map[row].Length;
        }

        private static void OponentMooves(ref string[][] beach, ref int opponentTokens, ref int row, ref int col, string direction)
        {
            for (int i = 0; i < 3; i++)
            {
                switch (direction)
                {
                    case "up":
                        if (isIn(beach, --row, col))
                        {
                            istoken(ref beach, row, col, ref opponentTokens);
                        }
                        else
                        {
                            if (row < 0)
                            {
                                row = 0;
                            }
                            col = beach[row].Length - 1;
                            istoken(ref beach, row, col, ref opponentTokens);
                        }
                        break;
                    case "down":
                        if (isIn(beach, ++row, col))
                        {
                            istoken(ref beach, row, col, ref opponentTokens);
                        }
                        else
                        {
                            if (row >= beach.Length)
                            {
                                row = beach.Length - 1;
                            }
                            col = beach[row].Length - 1;
                            istoken(ref beach, row, col, ref opponentTokens);
                        }
                        break;
                    case "left":
                        if (isIn(beach, row, --col))
                        {
                            istoken(ref beach, row, col, ref opponentTokens);
                        }
                        else
                        {
                            if (col < 0)
                            {
                                col = 0;
                            }
                            istoken(ref beach, row, col, ref opponentTokens);
                        }
                        break;
                    case "right":
                        if (isIn(beach, row, ++col))
                        {
                            istoken(ref beach, row, col, ref opponentTokens);
                        }
                        else
                        {
                            if (col >= beach[row].Length)
                            {
                                col = beach[row].Length - 1;
                            }
                            istoken(ref beach, row, col, ref opponentTokens);
                        }
                        break;
                }
            }
        }
    }
}
