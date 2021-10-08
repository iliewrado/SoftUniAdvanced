using System;
using System.Linq;

namespace _06JaggedArrayModification
{
    class ProgramJaggedArrayModification
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagget = new int[rows][];

            for (int i = 0; i < jagget.Length; i++)
            {
                jagget[i] = ReadIntArrayConsole();
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()).ToUpper() != "END")
            {
                string[] command = input
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                
                if (row >= 0 && col >= 0 && row < jagget.Length && col < jagget[col].Length)
                {
                    switch (command[0])
                    {
                        case "Add":
                            jagget[row][col] += value;
                            break;
                        case "Subtract":
                            jagget[row][col] -= value;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }
            foreach (var item in jagget)
            {
                Console.WriteLine(string.Join(' ', item));
            }
        }
        public static int[] ReadIntArrayConsole()
        {
            return Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
