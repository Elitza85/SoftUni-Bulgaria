using System;
using System.Collections.Generic;

namespace P03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            SortedSet<string> set = new SortedSet<string>();

            for (int i = 0; i < linesCount; i++)
            {
                string[] line = Console.ReadLine().Split();
                for (int j = 0; j < line.Length; j++)
                {
                    set.Add(line[j]);
                }
            }
            Console.WriteLine(string.Join(" ", set));
        }
    }
}
