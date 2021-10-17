using System;
using System.Collections.Generic;

namespace _05CountSymbols
{
    class ProgramCountSymbols
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();
            foreach (char symbol in text)
            {
                if (symbols.ContainsKey(symbol))
                {
                    symbols[symbol]++;
                }
                else
                {
                    symbols.Add(symbol, 1);
                }
            }
            foreach (var item in symbols)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
