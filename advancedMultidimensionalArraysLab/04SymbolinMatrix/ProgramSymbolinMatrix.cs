using System;

namespace _04SymbolinMatrix
{
    class ProgramSymbolinMatrix
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int r = 0; r < size; r++)
            {
                string filler = Console.ReadLine();
                for (int c = 0; c < size; c++)
                {
                    matrix[r, c] = filler[c];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            bool isFound = false;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i,j] == symbol)
                    {
                        isFound = true;
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }
            if (isFound == false)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix ");
            }
        }
    }
}
