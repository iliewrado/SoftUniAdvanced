using System;
using System.Linq;

namespace _01RecursiveArraySum
{
    class ProgramRecursiveArraySum
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int sum = Sum(array, 0);
            Console.WriteLine(sum);
        }
        private static int Sum(int[] temp, int index)
        {
            if (index == temp.Length - 1)
            {
                return temp[index];
            }
            return temp[index] + Sum(temp, index + 1);
        }
    }
}
