using System;
using System.Linq;

namespace _10RadioactiveMutantVampireBunnies
{
    class ProgramRadioactiveMutantVampireBunnies
    {
        static void Main(string[] args)
        {
            int[] size = ReadIntArrayConsole();
            char[,] lair = new char[size[0], size[1]];
            string input = string.Empty;

            int r = 0;
            int c = 0;

            for (int i = 0; i < lair.GetLength(0); i++)
            {
                input = Console.ReadLine();

                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    lair[i, j] = input[j];

                    if (lair[i, j] == 'P')
                    {
                        r = i;
                        c = j;
                    }
                }
            }

            input = Console.ReadLine();
            char[] moves = new char[input.Length];

            for (int j = 0; j < input.Length; j++)
            {
                moves[j] = input[j];
            }

            bool isDead = false;
            bool isGone = false;
            char[,] temp = new char[size[0], size[1]];
            temp = CloneMatrix(lair);

            foreach (var item in moves)
            {
                if (isGone == true || isDead == true)
                {
                    break;
                }
                if (r < 0 || c < 0 || r >= lair.GetLength(0) || c >= lair.GetLength(1))
                {
                    continue;
                }
                
                if (item == 'L')
                {
                    if (c - 1 < 0)
                    {
                        isGone = true;
                    }
                    else if (c - 1 >= 0 && lair[r, c - 1] != 'B')
                    {
                        temp[r, c] = '.';
                        c = c - 1;
                    }
                    else
                    {
                        isDead = true;
                        c = c - 1;
                    }

                }
                else if (item == 'R')
                {
                    if (c + 1 >= lair.GetLength(1))
                    {
                        isGone = true;
                    }
                    else if (c +1 < lair.GetLength(1) && lair[r, c + 1] != 'B')
                    {
                        temp[r, c] = '.';
                        c = c + 1;
                    }
                    else
                    {
                        isDead = true;
                        c = c + 1;
                    }
                }
                else if (item == 'U')
                {
                    if (r - 1 < 0)
                    {
                        isGone = true;
                    }
                    else if (r - 1 >= 0 && lair[r - 1, c] != 'B')
                    {
                        temp[r, c] = '.';
                        r = r - 1;
                    }
                    else
                    {
                        isDead = true;
                        r = r - 1;
                    }
                }
                else //D
                {
                    if (r + 1 >= lair.GetLength(0))
                    {
                        isGone = true;
                    }
                    else if (r + 1 < lair.GetLength(0) && lair[r + 1, c] != 'B')
                    {
                        temp[r, c] = '.';
                        r = r + 1;
                    }
                    else
                    {
                        isDead = true;
                        r = r + 1;
                    }
                }
                for (int i = 0; i < lair.GetLength(0); i++)
                {
                    for (int j = 0; j < lair.GetLength(1); j++)
                    {
                        if (lair[i, j] == 'B')
                        {
                            
                            if (i + 1 < lair.GetLength(0))
                            {
                                temp[i + 1, j] = 'B';
                            }
                            if (j - 1 >= 0)
                            {
                                temp[i, j - 1] = 'B';
                            }
                            if (i - 1 >= 0)
                            {
                                temp[i - 1, j] = 'B';
                            }
                            if (j + 1 < lair.GetLength(1))
                            {
                                temp[i, j + 1] = 'B';
                            }
                        }
                    }
                }
                lair = CloneMatrix(temp);
            }
            Printmatrix(lair);

            if (isGone)
            {
                Console.WriteLine($"won: {r} {c}");
            }
            if (isDead)
            {
                Console.WriteLine($"dead: {r} {c}");
            }
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
        public static char[,] CloneMatrix(char[,] temp)
        {
            char[,] newmatrix = new char[temp.GetLength(0), temp.GetLength(1)];
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    newmatrix[i, j] = temp[i, j];
                }
            }
            return newmatrix;
        }
    }
}
