using System;
using System.Linq;

namespace _03CustomMinFunction
{
    class ProgramCustomMinFunction
    {
        static void Main(string[] args)
        {
            Func<int, int, int> min = (a, b) =>  a < b ?  a : b;

            int[] digits = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int digit = digits[0];
            for (int i = 0; i < digits.Length; i++)
            {
                digit = min(digit, digits[i]);
            }
            Console.WriteLine(digit);
        }
    }
}
