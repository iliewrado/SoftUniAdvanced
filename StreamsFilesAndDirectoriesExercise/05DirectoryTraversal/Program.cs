using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allFiles = Directory.GetFiles(".");
            Dictionary<string, Dictionary<string, double>> files =
                new Dictionary<string, Dictionary<string, double>>();
            foreach (var file in allFiles)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (!files.ContainsKey(fileInfo.Extension))
                {
                    files.Add(fileInfo.Extension, 
                        new Dictionary<string, double>());
                }
                double size = fileInfo.Length / 1024;
                files[fileInfo.Extension].Add(fileInfo.Name, size);
            }
            List<string> orderedFiles = new List<string>();
            foreach (var file in files.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                orderedFiles.Add(file.Key);
                foreach (var item in file.Value)
                {
                    orderedFiles.Add($"--{item.Key} - {item.Value:f3}");
                }
            }
            string path = Environment.GetFolderPath
                (Environment.SpecialFolder.Desktop)+"/report.txt";
            File.WriteAllLinesAsync(path, orderedFiles);
        }
    }
}
