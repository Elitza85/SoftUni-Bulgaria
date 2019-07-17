using System;
using System.IO;

namespace P06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            var dirs = new DirectoryInfo("Test");

            foreach (var dir in dirs.GetFiles())
            {
                Console.WriteLine($"{dir.Name} - {dir.Length}");
            }
        }
    }
}
