using System;
using System.IO;
using System.Threading.Tasks;

namespace _05SliceAFile
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int parts = 4;
            byte[] buffer = new byte[4096];
            int totalBytes = 0;
            using (FileStream fileStream = new FileStream("sliceMe.txt", FileMode.Open ,FileAccess.Read))
            {
                int partSize = (int)Math.Ceiling((decimal)fileStream.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    int readBytes = 0;
                    using (FileStream fileWrite = new FileStream($"Part-{i+1}.txt", FileMode.Create, FileAccess.Write))
                    {
                        while (readBytes < partSize && totalBytes < fileStream.Length)
                        {
                            int bytesToRead = Math.Min(buffer.Length, partSize - readBytes);
                            int bytes = await fileStream.ReadAsync(buffer, 0, bytesToRead);
                            await fileWrite.WriteAsync(buffer, 0, bytes);
                            readBytes += bytes;
                            totalBytes += bytes;
                        }
                    }
                }
            }
        }
    }
}
