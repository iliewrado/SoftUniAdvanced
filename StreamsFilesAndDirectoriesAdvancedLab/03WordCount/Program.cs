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
            List<string> words = new List<string>();
            using (StreamReader wordsReader = new StreamReader("words.txt"))
            {
                string line = await wordsReader.ReadLineAsync();
                words = line.Split().ToList();
            }
            Dictionary<string, int> matches = new Dictionary<string, int>();
            foreach (var word in words)
            {
                using (StreamReader textReader = new StreamReader("text.txt"))
                {
                    string line = await textReader.ReadLineAsync();
                    while (line != null)
                    {
                        string[] textWords = line.ToLower()
                            .Split(new char[] { '-', ' ', '!', '?', '.', ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
                        foreach (var text in textWords)
                        {
                            if (word == text)
                            {
                                if (matches.ContainsKey(word))
                                {
                                    matches[word]++;
                                }
                                else
                                {
                                    matches.Add(word, 1);
                                }
                            }
                        }
                        line = await textReader.ReadLineAsync();
                    }
                }
            }
            using (StreamWriter streamWriter = new StreamWriter("Output.txt"))
            {
                foreach (var match in matches.OrderByDescending(x => x.Value))
                {
                    await streamWriter.WriteLineAsync($"{match.Key} - {match.Value}");
                }
            }
        }
    }
}
