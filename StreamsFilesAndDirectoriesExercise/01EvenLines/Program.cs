using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01EvenLines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<List<string>> words = new List<List<string>>();
            using (StreamReader streamReader = new StreamReader("text.txt"))
            {
                int lines = 0;
                string line = await streamReader.ReadLineAsync();
                while (line != null)
                {
                    if (lines % 2 == 0)
                    {
                        StringBuilder temp = new StringBuilder();
                        char[] chars = line.ToCharArray();
                        for (int i = 0; i < chars.Length; i++)
                        {
                            switch (chars[i])
                            {
                                case '-':
                                case ',':
                                case '.':
                                case '!':
                                case '?':
                                    temp.Append('@');
                                    break;
                                default:
                                    temp.Append(chars[i]);
                                    break;
                            }
                        }
                        words.Add(temp.ToString().Split().Reverse().ToList());
                    }
                    lines++;
                    line = await streamReader.ReadLineAsync();
                }
            }
            foreach (var word in words)
            {
                Console.WriteLine(string.Join(' ', word));
            }
        }
    }
}
