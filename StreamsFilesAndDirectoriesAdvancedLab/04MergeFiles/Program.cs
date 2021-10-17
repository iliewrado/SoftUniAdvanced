using System;
using System.IO;
using System.Threading.Tasks;

namespace _04MergeFiles
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader readerOne = new StreamReader("fileOne.txt"),
                readerTwo = new StreamReader("fileTwo.txt"))
            {
                string lineOne = await readerOne.ReadLineAsync();
                string lineTwo = await readerTwo.ReadLineAsync();

                using (StreamWriter streamWriter = new StreamWriter("Output.txt"))
                {
                    while (lineOne != null || lineTwo != null)
                    {
                        if (lineOne != null)
                        {
                            await streamWriter.WriteLineAsync(lineOne);
                        }
                        if (lineTwo != null)
                        {
                            await streamWriter.WriteLineAsync(lineTwo);
                        }
                        lineOne = await readerOne.ReadLineAsync();
                        lineTwo = await readerTwo.ReadLineAsync();
                    }
                }  
            }
        }
    }
}
