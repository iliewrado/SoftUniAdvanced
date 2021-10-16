using System;
using System.Linq;

namespace GenericSwapMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            Box<string> words = new Box<string>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                words.Add(input);
            }
            int[] swapIndexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            words.Swap(words, swapIndexes[0], swapIndexes[1]);

            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine($"{words[i].GetType().FullName}: {words[i]}");
            }
        }
    }
}
