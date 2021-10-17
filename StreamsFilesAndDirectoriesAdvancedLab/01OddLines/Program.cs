using System.IO;
using System.Threading.Tasks;

namespace _01OddLines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("input.txt"))
            {
                int lines = 0;
                string currentLine = await streamReader.ReadLineAsync();
                using (StreamWriter streamWriter = new StreamWriter("output.txt"))
                {
                    while (currentLine != null)
                    {
                        if (lines % 2 != 0)
                        {
                            await streamWriter.WriteLineAsync(currentLine);
                        }
                        lines++;
                        currentLine = await streamReader.ReadLineAsync();
                    }
                }
            }
        }
    }
}
