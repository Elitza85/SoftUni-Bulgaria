using System;
using System.IO;
using System.Linq;

namespace P04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file1 = File.ReadAllLines("FileOne.txt");
            string[] file2 = File.ReadAllLines("FileTwo.txt");

            File.WriteAllText("output.txt", "");

            string[] result = file1.Concat(file2).OrderBy(x => x).ToArray();

            foreach (var item in result)
            {
                File.AppendAllText("output.txt", $"{item}{Environment.NewLine}");
            }
        }
    }
}
