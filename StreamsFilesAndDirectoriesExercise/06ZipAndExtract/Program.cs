using System;
using System.IO.Compression;

namespace _06ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\.\Desktop\New folder";
            string zipPath = @"C:\Users\.\Desktop\rezult.zip";
            ZipFile.CreateFromDirectory(filePath, zipPath);
        }
    }
}
