using System;

namespace _02SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int mariosLives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] castle = new char[rows][];
            int mRow = -1;
            int mCol = -1;
            
            for (int i = 0; i < rows; i++)
            {
                castle[i] = Console.ReadLine().ToCharArray();
                for (int j = 0; j < castle[i].Length; j++)
                {
                    if (castle[i][j] == 'M')
                    {
                        mRow = i;
                        mCol = j;
                    }
                }
            }

            bool isDead = false;
            bool isSave = false;

            while (isDead == false && isSave == false)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                char direction = char.Parse(input[0]);
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                castle[row][col] = 'B';
                mariosLives--;
                castle[mRow][mCol] = '-';

                switch (direction)
                {
                    case'W': // up
                        mRow--;
                        if (IsItIn(mRow, mCol, castle))
                        {
                            CheckMoveSpot(ref mariosLives, castle, mRow, mCol, ref isDead, ref isSave);
                        }
                        else
                        {
                            mRow++;
                        }
                        break;
                    case 'S': // down
                        mRow++;
                        if (IsItIn(mRow, mCol, castle))
                        {
                            CheckMoveSpot(ref mariosLives, castle, mRow, mCol, ref isDead, ref isSave);
                        }
                        else
                        {
                            mRow--;
                        }
                        break;
                    case 'A': // left
                        mCol--;
                        if (IsItIn(mRow, mCol, castle))
                        {
                            CheckMoveSpot(ref mariosLives, castle, mRow, mCol, ref isDead, ref isSave);
                        }
                        else
                        {
                            mCol++;
                        }
                        break;
                    case 'D': // right
                        mCol++;
                        if (IsItIn(mRow, mCol, castle))
                        {
                            CheckMoveSpot(ref mariosLives, castle, mRow, mCol, ref isDead, ref isSave);
                        }
                        else
                        {
                            mCol--;
                        }
                        break;
                }
                if (mariosLives <= 0)
                {
                    isDead = true;
                    castle[mRow][mCol] = 'X';
                }
            }

            if (isSave)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {mariosLives}");
            }
            else if (isDead)
            {
                Console.WriteLine($"Mario died at {mRow};{mCol}.");
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < castle[i].Length; j++)
                {
                    Console.Write(castle[i][j]);
                }
                Console.WriteLine();
            }
        }

        private static void CheckMoveSpot(ref int mariosLives, char[][] castle, int mRow, int mCol, ref bool isDead, ref bool isSave)
        {
            if (castle[mRow][mCol] == 'B')
            {
                mariosLives -= 2;
                if (mariosLives <= 0)
                {
                    isDead = true;
                    castle[mRow][mCol] = 'X';
                }
            }
            else if (castle[mRow][mCol] == 'P')
            {
                isSave = true;
                castle[mRow][mCol] = '-';
            }
        }

        private static bool IsItIn(int row, int col, char[][] field)
        {
            return row >= 0 && row < field.Length
                && col >= 0 && col < field[row].Length;
        }
    }
}
