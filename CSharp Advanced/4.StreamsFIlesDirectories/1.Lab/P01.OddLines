using System;
using System.IO;

namespace P01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "files";
            string fileName = "input.txt";

            using (var reader = new StreamReader(Path.Combine(path, fileName)))
            {
                int counter = 0;

                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                }
            }
        }
    }
}
