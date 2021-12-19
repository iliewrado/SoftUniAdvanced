using System;

namespace _02Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] armory = new char[size, size];
            int aRow = -1;
            int aCol = -1;
            string input = string.Empty;

            for (int i = 0; i < size; i++)
            {
                input = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    armory[i, j] = input[j];
                    if (armory[i,j] == 'A')
                    {
                        aRow = i;
                        aCol = j;
                    }
                }
            }
            
            int coins = 0;
            bool isOut = false;

            while (coins < 65 && isOut == false)
            {
                input = Console.ReadLine();
                armory[aRow, aCol] = '-';
                switch (input)
                {
                    case"up":
                        aRow--;
                        if (IsItIn(aRow,aCol,size))
                        {
                            CheckArmorySpot(size, armory, ref aRow, ref aCol, ref coins);
                        }
                        else
                        {
                            aRow++;
                            isOut = true;
                        }

                        break;
                    case "down":
                        aRow++;
                        if (IsItIn(aRow, aCol, size))
                        {
                            CheckArmorySpot(size, armory, ref aRow, ref aCol, ref coins);
                        }
                        else
                        {
                            aRow--;
                            isOut = true;
                        }
                            break;
                    case "left":
                        aCol--;
                        if (IsItIn(aRow, aCol, size))
                        {
                            CheckArmorySpot(size, armory, ref aRow, ref aCol, ref coins);
                        }
                        else
                        {
                            aCol++;
                            isOut = true;
                        }
                        break;
                    case "right":
                        aCol++;
                        if (IsItIn(aRow, aCol, size))
                        {
                            CheckArmorySpot(size, armory, ref aRow, ref aCol, ref coins);
                        }
                        else
                        {
                            aCol--;
                            isOut = true;
                        }
                        break;
                }
            }

            if (isOut)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else if (coins >= 65)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {coins} gold coins.");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(armory[i,j]);
                }
                Console.WriteLine();
            }

        }

        private static void CheckArmorySpot(int size, char[,] armory, ref int aRow, ref int aCol, ref int coins)
        {
            if (char.IsDigit(armory[aRow, aCol]))
            {
                coins += armory[aRow, aCol] - 48;
                if (coins >= 65)
                {
                    armory[aRow, aCol] = 'A';
                }
                else
                {
                    armory[aRow, aCol] = '-';
                }
            }
            else if (armory[aRow, aCol] == 'M')
            {
                armory[aRow, aCol] = '-';
                for (int i = aRow; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (armory[i, j] == 'M')
                        {
                            aRow = i;
                            aCol = j;
                            armory[aRow, aCol] = 'A';
                        }
                    }
                }
            }
        }

        private static bool IsItIn(int row, int col, int size)
        {
            return row >= 0 && row < size
                && col >= 0 && col < size;
        }
    }
}
