using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.AverageStudentGrade
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>();

            for (int i = 0; i < count; i++)
            {
                string[] entires = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = entires[0];
                double grade = double.Parse(entires[1]);

                if (!dict.ContainsKey(name))
                {
                    dict[name] = new List<double>();
                }
                dict[name].Add(grade);
            }

            foreach (var item in dict)
            {
                Console.Write($"{item.Key} -> ");
                foreach (var grade in item.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {item.Value.Average():f2})");
            }
        }
    }
}
