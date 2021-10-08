using System;
using System.Linq;

namespace _06JaggedArrayManipulator
{
    class ProgramJaggedArrayManipulator
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            double[][] jagget = new double[size][];

            for (int i = 0; i < size; i++)
            {
                jagget[i] = ReadIntArrayConsole();
            }
            for (int i = 0; i < jagget.GetLength(0)-1; i++)
            {
                if (jagget[i].Length == jagget[i+1].Length)
                {
                    for (int j = 0; j < jagget[i].Length; j++)
                    {
                        jagget[i][j] *= 2;
                        jagget[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jagget[i].Length; j++)
                    {
                        jagget[i][j] /= 2;
                    }
                    for (int k = 0; k < jagget[i+1].Length; k++)
                    {
                        jagget[i + 1][k] /= 2;
                    }
                }
            }
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (command[0] == "Add")
                {
                    if (row >= 0 && row < jagget.GetLength(0) && col >= 0 && col < jagget[row].Length)
                    {
                        jagget[row][col] += value;
                    }
                }
                else if (command[0] == "Subtract")
                {
                    if (row >= 0 && row < jagget.GetLength(0) && col >= 0 && col < jagget[row].Length)
                    {
                        jagget[row][col] -= value;
                    }
                }
            }
            for (int i = 0; i < jagget.GetLength(0); i++)
            {
                Console.WriteLine(string.Join(' ', jagget[i]));
            }
        }
        public static double[] ReadIntArrayConsole()
        {
            return Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
        }
    }
}
