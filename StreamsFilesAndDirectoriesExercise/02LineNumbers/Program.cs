using System;
using System.IO;
using System.Threading.Tasks;

namespace _02LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("text.txt"))
            {
                string line = await streamReader.ReadLineAsync();
                int lineCount = 1;
                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    while (line != null)
                    {
                        int letterCount = 0;
                        int markCount = 0;
                        foreach (var letter in line)
                        {
                            switch (letter)
                            {
                                case '-':
                                case ',':
                                case '.':
                                case '!':
                                case '?':
                                case '\'':
                                    markCount++;
                                    break;
                                case ' ':
                                    break;
                                default:
                                    letterCount++;
                                    break;
                            }
                        }
                        await writer.WriteLineAsync($"Line {lineCount}: {line} ({letterCount})({markCount})");
                        line = await streamReader.ReadLineAsync();
                        lineCount++;
                    }
                }
            }
        }
    }
}
