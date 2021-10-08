using System;
using System.Collections.Generic;
using System.Linq;

namespace _09Miner
{
    class ProgramMiner
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = ReadStringArrayConsole();
            string[,] field = MatrixFiller(size, size);
            int r = 0;
            int c = 0;
            int totalCoal = 0;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i,j] == "s")
                    {
                        r = i;
                        c = j;
                    }
                    if (field[i,j] == "c")
                    {
                        totalCoal++;
                    }
                }
            }
            bool isAll = false;
            bool isOver = false;
            foreach (var item in commands)
            {
                if (isAll || isOver)
                {
                    break;
                }
                switch (item)
                {
                    case "up":
                        if (r - 1 >= 0)
                        {
                            r = r - 1;
                            switch (field[r, c])
                            {
                                case"e":
                                    isOver = true;
                                    break;
                                case "c":
                                    totalCoal--;
                                    field[r, c] = "*";
                                    if (totalCoal == 0)
                                    {
                                        isAll = true;
                                    }
                                    break;
                            }
                        }
                        break;
                    case "down":
                        if (r + 1 < field.GetLength(0))
                        {
                            r = r + 1;
                            switch (field[r, c])
                            {
                                case "e":
                                    isOver = true;
                                    break;
                                case "c":
                                    totalCoal--;
                                    field[r, c] = "*";
                                    if (totalCoal == 0)
                                    {
                                        isAll = true;
                                    }
                                    break;
                            }
                        }
                        break;
                    case "left":
                        if (c - 1 >= 0)
                        {
                            c = c - 1;
                            switch (field[r, c])
                            {
                                case "e":
                                    isOver = true;
                                    break;
                                case "c":
                                    totalCoal--;
                                    field[r, c] = "*";
                                    if (totalCoal == 0)
                                    {
                                        isAll = true;
                                    }
                                    break;
                            }
                        }
                        break;
                    case "right":
                        if (c + 1 < field.GetLength(1))
                        {
                            c = c + 1;
                            switch (field[r, c])
                            {
                                case "e":
                                    isOver = true;
                                    break;
                                case "c":
                                    totalCoal--;
                                    field[r, c] = "*";
                                    if (totalCoal == 0)
                                    {
                                        isAll = true;
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
            if (isAll)
            {
                Console.WriteLine($"You collected all coals! ({r}, {c})");
            }
            if (isOver)
            {
                Console.WriteLine($"Game over! ({r}, {c})");
            }
            if (!isOver && !isAll)
            {
                Console.WriteLine($"{totalCoal} coals left. ({r}, {c})");
            }
            

        }
        public static string[] ReadStringArrayConsole()
        {
            return Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
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
