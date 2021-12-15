using System;

namespace _02Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            char[,] field = new char[count, count];
            int bRow = -1;
            int bCol = -1;
            int polinationed = 0;
            string input = string.Empty;
            bool isOut = false;

            for (int i = 0; i < count; i++)
            {
                input = Console.ReadLine();
                for (int j = 0; j < count; j++)
                {
                    field[i, j] = input[j];
                    if (input[j] == 'B')
                    {
                        bRow = i;
                        bCol = j;
                    }
                }
            }

            while (isOut == false)
            {
                input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                field[bRow, bCol] = '.';
                switch (input)
                {
                    case "up":
                        bRow--;
                        if (!isIn(field, bRow, bCol))
                        {
                            isOut = true;
                            break;
                        }
                        else if (field[bRow, bCol] == 'O')
                        {
                            field[bRow, bCol] = '.';
                            bRow--;
                            if (field[bRow, bCol] == 'f')
                            {
                                polinationed++;
                                field[bRow, bCol] = '.';
                            }
                        }
                        else if (field[bRow, bCol] == 'f')
                        {
                            polinationed++;
                            field[bRow, bCol] = '.';
                        }
                        field[bRow, bCol] = 'B';
                        break;
                    case "down":
                        bRow++;
                        if (!isIn(field, bRow, bCol))
                        {
                            isOut = true;
                            break;
                        }
                        else if (field[bRow, bCol] == 'O')
                        {
                            field[bRow, bCol] = '.';
                            bRow++;
                            if (field[bRow, bCol] == 'f')
                            {
                                polinationed++;
                                field[bRow, bCol] = '.';
                            }
                        }
                        else if (field[bRow, bCol] == 'f')
                        {
                            polinationed++;
                            field[bRow, bCol] = '.';
                        }
                        field[bRow, bCol] = 'B';
                        break;
                    case "left":
                        bCol--;
                        if (!isIn(field, bRow, bCol))
                        {
                            isOut = true;
                            break;
                        }
                        else if (field[bRow, bCol] == 'O')
                        {
                            field[bRow, bCol] = '.';
                            bCol--;
                            if (field[bRow, bCol] == 'f')
                            {
                                polinationed++;
                                field[bRow, bCol] = '.';
                            }
                        }
                        else if (field[bRow, bCol] == 'f')
                        {
                            polinationed++;
                            field[bRow, bCol] = '.';
                        }
                        field[bRow, bCol] = 'B';
                        break;
                    case "right":
                        bCol++;
                        if (!isIn(field, bRow, bCol))
                        {
                            isOut = true;
                            break;
                        }
                        else if (field[bRow, bCol] == 'O')
                        {
                            field[bRow, bCol] = '.';
                            bCol++;
                            if (field[bRow, bCol] == 'f')
                            {
                                polinationed++;
                                field[bRow, bCol] = '.';
                            }
                        }
                        else if (field[bRow, bCol] == 'f')
                        {
                            polinationed++;
                            field[bRow, bCol] = '.';
                        }
                        field[bRow, bCol] = 'B';
                        break;
                }
            }

            if (isOut == true)
            {
                Console.WriteLine("The bee got lost!");
            }

            Console.WriteLine(polinationed < 5 ? $"The bee couldn't pollinate the flowers, she needed {5 - polinationed} flowers more"
                : $"Great job, the bee managed to pollinate {polinationed} flowers!");

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    Console.Write(field[i, j].ToString());
                }
                Console.WriteLine();
            }
        }

        private static bool isIn(char[,] map, int row, int col)
        {
            return row >= 0 && row < map.GetLength(0)
                && col >= 0 && col < map.GetLength(1);
        }
    }
}
