using System;
using System.Collections.Generic;
using System.Linq;

namespace _07KnightGame
{
    class ProgramKnightGame
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[][] chessBoard = new char[size][];

            for (int i = 0; i < size; i++)
            {
                chessBoard[i] = Console.ReadLine().ToCharArray();
            }
            int knights = 0;
            while (true)
            {
                int row = -1;
                int col = -1;
                int maxAttacs = 0;

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (chessBoard[i][j] == 'K')
                        {
                            int currentAttack = AttacksCount(chessBoard, i, j);
                            if (currentAttack > maxAttacs)
                            {
                                maxAttacs = currentAttack;
                                row = i;
                                col = j;
                            }
                        }
                    }
                }
                if (maxAttacs > 0)
                {
                    chessBoard[row][col] = '0';
                    knights++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(knights);
        }

        private static int AttacksCount(char[][] board, int row, int col)
        {
            int attack = 0;

            if (row >= 0 && col >= 0 && row < board.Length && col < board.Length)
            {
                if (row - 2 >= 0 && col - 1 >= 0 && board[row - 2][col - 1] == 'K')
                {
                    attack++;
                }
                if (row - 1 >= 0 && col - 2 >= 0 && board[row - 1][col - 2] == 'K')
                {
                    attack++;
                }
                if (row - 2 >= 0 && col + 1 < board.Length && board[row - 2][col + 1] == 'K')
                {
                    attack++;
                }
                if (row - 1 >= 0 && col + 2 < board.Length && board[row - 1][col + 2] == 'K')
                {
                    attack++;
                }
                if (row + 1 < board.Length && col - 2 >= 0 && board[row + 1][col - 2] == 'K')
                {
                    attack++;
                }
                if (row + 2 < board.Length && col - 1 >= 0 && board[row + 2][col - 1] == 'K')
                {
                    attack++;
                }
                if (row + 2 < board.Length && col + 1 < board.Length && board[row + 2][col + 1] == 'K')
                {
                    attack++;
                }
                if (row + 1 < board.Length && col + 2 < board.Length && board[row + 1][col + 2] == 'K')
                {
                    attack++;
                }
            }
            return attack;
        }
    }
}
