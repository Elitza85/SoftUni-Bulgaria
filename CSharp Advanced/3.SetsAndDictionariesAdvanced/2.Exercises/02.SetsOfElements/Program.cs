using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            List<int> lineOfNums = new List<int>();

            for (int i = 0; i < lengths[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                first.Add(num);
                lineOfNums.Add(num);
            }
            for (int j = lengths[0]; j < lengths[0] + lengths[1]; j++)
            {
                int num = int.Parse(Console.ReadLine());
                second.Add(num);
                lineOfNums.Add(num);
            }

            for (int k = 0; k < lineOfNums.Count; k++)
            {
                int numToCheck = lineOfNums[k];
                if (first.Contains(numToCheck) && second.Contains(numToCheck))
                {

                    first.Remove(numToCheck);
                    second.Remove(numToCheck);
                    Console.Write($"{numToCheck} ");
                }
                lineOfNums.Remove(numToCheck);
                k--;
            }
        }
    }
}
