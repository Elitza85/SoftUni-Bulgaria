using System;
using System.Collections.Generic;

namespace P04.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> map =
                new Dictionary<string, Dictionary<string, List<string>>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = line[0];
                string country = line[1];
                string city = line[2];

                if (!map.ContainsKey(continent))
                {
                    map[continent] = new Dictionary<string, List<string>>();
                }
                if (!map[continent].ContainsKey(country))
                {
                    map[continent][country] = new List<string>();
                }
                map[continent][country].Add(city);
            }
            foreach (var contintent in map)
            {
                Console.WriteLine($"{contintent.Key}:");
                foreach (var item in contintent.Value)
                {
                    Console.WriteLine($"{item.Key} -> {string.Join(", ", item.Value)}");
                }
            }
        }
    }
}
