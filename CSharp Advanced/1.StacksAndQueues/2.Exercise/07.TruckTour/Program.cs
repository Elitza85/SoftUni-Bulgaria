using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < lines; i++)
            {
                int[] petrolPump = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                pumps.Enqueue(petrolPump);
            }
            int index = 0;
            while (true)
            {
                int totalFuel = 0;
                foreach (var petrolPump in pumps)
                {
                    int petrolInPump = petrolPump[0];
                    int distance = petrolPump[1];

                    totalFuel += petrolInPump - distance;
                    if (totalFuel < 0)
                    {
                        pumps.Enqueue(pumps.Dequeue());
                        index++;
                        break;
                    }
                }
                if (totalFuel >= 0)
                {
                    break;
                }
            }
            Console.WriteLine(index);
        }
    }
}
