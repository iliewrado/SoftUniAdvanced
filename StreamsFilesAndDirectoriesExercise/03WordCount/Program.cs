using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _03WordCount
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] lines = await File.ReadAllLinesAsync("text.txt");
            char[] sybols = new char[] { '.', '-', '!', '?', ',' };
            for (int i = 0; i < lines.Length; i++)
            {
                foreach (var symbol in sybols)
                {
                    lines[i] = lines[i].Replace(symbol, ' ');
                }
            }
            string[] words = await File.ReadAllLinesAsync("words.txt");
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] temp = lines[i]
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in temp)
                    {
                        if (string.Compare(word, item, StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            if (!wordsCount.ContainsKey(word))
                            {
                                wordsCount.Add(word, 0);
                            }
                            wordsCount[word]++;
                        }
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter("actualResults.txt"))
            {
                foreach (var kvp in wordsCount)
                {
                    await writer.WriteLineAsync($"{kvp.Key} - {kvp.Value}");
                }
            }
            List<string> toCompare = new List<string>();
            foreach (var item in wordsCount.OrderByDescending(x => x.Value))
            {
                toCompare.Add($"{item.Key} - {item.Value}");
            }

            await File.AppendAllLinesAsync("expectedResult.txt", toCompare);
        }
    }
}
