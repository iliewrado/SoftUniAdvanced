using System.IO;
using System.Threading.Tasks;

namespace _02LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("Input.txt"))
            {
                int line = 1;
                string currentLine = await streamReader.ReadLineAsync();
                using (StreamWriter streamWriter = new StreamWriter("Output.txt"))
                {
                    while (currentLine != null)
                    {
                        await streamWriter.WriteLineAsync($"{line}. {currentLine}");
                        line++;
                        currentLine = await streamReader.ReadLineAsync();
                    }
                }
            }
        }
    }
}
