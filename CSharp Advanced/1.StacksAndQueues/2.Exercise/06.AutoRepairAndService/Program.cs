using System;
using System.Collections.Generic;
using System.Linq;


namespace P06.AutoRepairAndService
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cars = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> carsQueue = new Queue<string>(cars);
            string command = string.Empty;
            Stack<string> servedCars = new Stack<string>();

            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Service" && carsQueue.Count > 0)
                {
                    string currentCar = carsQueue.Dequeue();
                    servedCars.Push(currentCar);
                    Console.WriteLine($"Vehicle {currentCar} got served.");
                }
                else if (command.Contains('-'))
                {
                    string[] carInfo = command.Split('-');
                    string carType = carInfo[1];
                    Console.WriteLine(carsQueue.Contains(carType) ?
                        "Still waiting for service." : "Served.");
                }
                else if (command == "History")
                {
                    Console.WriteLine(string.Join(", ", servedCars));
                }
            }
            if (carsQueue.Count > 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", carsQueue)}");
            }
            Console.WriteLine($"Served vehicles: {string.Join(", ", servedCars)}");
        }
    }
}
