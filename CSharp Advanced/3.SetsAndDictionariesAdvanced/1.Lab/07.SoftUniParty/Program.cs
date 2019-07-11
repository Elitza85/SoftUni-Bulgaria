using System;
using System.Collections.Generic;

namespace P07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vips = new HashSet<string>();
            HashSet<string> guests = new HashSet<string>();

            string line = Console.ReadLine();

            while (line != "PARTY")
            {
                if (Char.IsDigit(line[0]))
                {
                    vips.Add(line);
                }
                else
                {
                    guests.Add(line);
                }
                line = Console.ReadLine();
            }
            line = Console.ReadLine();

            while (line != "END")
            {
                if (Char.IsDigit(line[0]))
                {
                    vips.Remove(line);
                }
                else
                {
                    guests.Remove(line);
                }
                line = Console.ReadLine();

            }
            
            Console.WriteLine(guests.Count + vips.Count);

            foreach (var item in vips)
            {
                Console.WriteLine(item);
            }
            foreach (var item in guests)
            {
                Console.WriteLine(item);
            }
        }
    }
}
