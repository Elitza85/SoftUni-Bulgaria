using System;
using System.Collections.Generic;

namespace P06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            string line = string.Empty;

            while ((line = Console.ReadLine()) != "END")
            {
                string[] tokens = line.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "IN")
                {
                    cars.Add(tokens[1]);
                }
                else if (tokens[0] == "OUT")
                {
                    cars.Remove(tokens[1]);
                }
            }
            if (cars.Count > 0)
            {
                foreach (var item in cars)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
