using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe =
                new Dictionary<string, Dictionary<string, int>>();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ")
                    .ToArray();
                string colour = input[0];
                if (!wardrobe.ContainsKey(colour))
                {
                    wardrobe[colour] = new Dictionary<string, int>();
                }
                string[] items = input[1].Split(",").ToArray();
                for (int j = 0; j < items.Length; j++)
                {
                    string cloth = items[j];
                    if (!wardrobe[colour].ContainsKey(cloth))
                    {
                        wardrobe[colour][cloth] = 0;
                    }
                    wardrobe[colour][cloth]++;
                }
            }
            string[] lookFor = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string lookForColour = lookFor[0];
            string lookForCloth = lookFor[1];

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var colour in item.Value)
                {
                    if (item.Key == lookForColour && colour.Key == lookForCloth)
                    {
                        Console.WriteLine($"* {colour.Key} - {colour.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {colour.Key} - {colour.Value}");
                    }

                }
            }
        }
    }
}
