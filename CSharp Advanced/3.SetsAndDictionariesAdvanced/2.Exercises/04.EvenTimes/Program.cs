using System;
using System.Collections.Generic;

namespace P04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < lines; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!dict.ContainsKey(num))
                {
                    dict[num] = 0;
                }
                dict[num]++;
            }

            foreach (var item in dict)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
