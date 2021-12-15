using System;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] backery = new char[size, size];
            int row = -1;
            int col = -1;
            string input = string.Empty;
            
            for (int i = 0; i < size; i++)
            {
                input = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    backery[i, j] = input[j];
                    if (input[j] == 'S')
                    {
                        row = i;
                        col = j;
                    }
                }
            }

            bool isOut = false;
            int money = 0;

            while (money < 50 && isOut == false)
            {
                input = Console.ReadLine();
                backery[row, col] = '-';
                if (input == "up")
                {
                    row--;
                    BackeryCheck(size, backery, ref row, ref col, ref isOut, ref money);
                }
                else if (input == "down")
                {
                    row++;
                    BackeryCheck(size, backery, ref row, ref col, ref isOut, ref money);
                }
                else if (input == "left")
                {
                    col--;
                    BackeryCheck(size, backery, ref row, ref col, ref isOut, ref money);
                }
                else if (input == "right")
                {
                    col++;
                    BackeryCheck(size, backery, ref row, ref col, ref isOut, ref money);
                }
            }

            Console.WriteLine(isOut == true ? "Bad news, you are out of the bakery."
                : "Good news! You succeeded in collecting enough money!");
            Console.WriteLine($"Money: {money}");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(backery[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static void BackeryCheck(int size, char[,] backery, ref int row, ref int col, ref bool isOut, ref int money)
        {
            if (IsIn(row, col, size) == false)
            {
                isOut = true;
            }
            else if (backery[row, col] == 'O')
            {
                backery[row, col] = '-';
                for (int i = row; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (backery[i, j] == 'O')
                        {
                            row = i;
                            col = j;
                            backery[row, col] = 'S';
                            break;
                        }
                    }
                }
            }
            else if (char.IsDigit(backery[row, col]))
            {
                money += backery[row, col] - 48;
                backery[row, col] = 'S';
            }
        }

        private static bool IsIn(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }
    }
}
