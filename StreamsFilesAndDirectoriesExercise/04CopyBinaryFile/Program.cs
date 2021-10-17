using System;
using System.IO;
using System.Threading.Tasks;

namespace _04CopyBinaryFile
{
    class Program
    {
        static async Task Main(string[] args)
        {
            byte[] bytes = new byte[4096];
            int totalBytes = 0;
            using (FileStream reader = 
                new FileStream("copyMe.png", FileMode.Open, FileAccess.Read))
            {
                int readBytes = await reader.ReadAsync(bytes, 0, bytes.Length);
                using (FileStream writer =
                    new FileStream("copyOfCopyMe.png", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    while (totalBytes < reader.Length)
                    {
                        await writer.WriteAsync(bytes, 0, readBytes);
                        totalBytes += readBytes;
                        readBytes = await reader.ReadAsync(bytes, 0, bytes.Length);
                    }
                }
            }
        }
    }
}
