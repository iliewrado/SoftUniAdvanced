using System;

namespace _02TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armyArmor = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[][] world = new char[size][];
            int aRow = -1;
            int aCol = -1;
            bool isDead = false;
            bool isWin = false;

            for (int i = 0; i < size; i++)
            {
                world[i] = Console.ReadLine().ToCharArray();
                for (int j = 0; j < world[i].Length; j++)
                {
                    if (world[i][j] == 'A')
                    {
                        aRow = i;
                        aCol = j;
                    }
                }
            }

            while (isDead == false && isWin == false)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                int orcRow = int.Parse(input[1]);
                int orcCol = int.Parse(input[2]);
                world[orcRow][orcCol] = 'O';
                armyArmor--;
                world[aRow][aCol] = '-';
                switch (command)
                {
                    case "up":
                        aRow--;
                        if (isInside(aRow, aCol, world))
                        {
                            WOrldMoveCheck(ref armyArmor, world, ref aRow, aCol, ref isWin);
                        }
                        else
                        {
                            aRow++;
                        }
                        break;
                    case "down":
                        aRow++;
                        if (isInside(aRow, aCol, world))
                        {
                            WOrldMoveCheck(ref armyArmor, world, ref aRow, aCol, ref isWin);
                        }
                        else
                        {
                            aRow--;
                        }
                        break;
                    case "left":
                        aCol--;
                        if (isInside(aRow, aCol, world))
                        {
                            WOrldMoveCheck(ref armyArmor, world, ref aRow, aCol, ref isWin);
                        }
                        else
                        {
                            aCol++;
                        }
                        break;
                    case "right":
                        aCol++;
                        if (isInside(aRow, aCol, world))
                        {
                            WOrldMoveCheck(ref armyArmor, world, ref aRow, aCol, ref isWin);
                        }
                        else
                        {
                            aCol--;
                        }
                        break;
                }
                if (armyArmor <= 0)
                {
                    isDead = true;
                    world[aRow][aCol] = 'X';
                }
            }

            if (isWin == true)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");
            }
            else
            {
                Console.WriteLine($"The army was defeated at {aRow};{aCol}.");
            }

            for (int i = 0; i < world.Length; i++)
            {
                for (int j = 0; j < world[i].Length; j++)
                {
                    Console.Write(world[i][j]);
                }
                Console.WriteLine();
            }
        }

        private static void WOrldMoveCheck(ref int armyArmor, char[][] world, ref int aRow, int aCol, ref bool isWin)
        {
            if (world[aRow][aCol] == 'M')
            {
                isWin = true;
                world[aRow][aCol] = '-';
            }
            else if (world[aRow][aCol] == 'O')
            {
                armyArmor -= 2;
                world[aRow][aCol] = 'A';
            }
        }

        private static bool isInside(int row, int col, char[][] field)
        {
            return row >= 0 && row < field.Length
                && col >= 0 && col < field[row].Length;
        }
    }
}
