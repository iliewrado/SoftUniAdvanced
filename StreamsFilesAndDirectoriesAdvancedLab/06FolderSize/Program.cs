using System.IO;

namespace _06FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileNames =
                Directory.GetFiles("D:/Users/ray_m/source/LabStreamsFilesAndDirectoriesAdvanced/06FolderSize/TestFolder");
            double totalSize = 0;

            foreach (var file in fileNames)
            {
                FileInfo fileInfo = new FileInfo(file);
                totalSize += fileInfo.Length;
            }

            totalSize = totalSize / 1024 / 1024;
            File.WriteAllText("Output.txt", totalSize.ToString());
        }
    }
}
