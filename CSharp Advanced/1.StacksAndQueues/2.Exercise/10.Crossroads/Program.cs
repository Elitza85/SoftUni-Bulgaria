using System;
using System.Collections.Generic;

namespace P10.Crossroad
{
    class Program
    {
        static void Main(string[] args)
        {
            int previousGreen = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string input = Console.ReadLine();
            char carHitSymbol = '\0';
            int totalCars = 0;
            bool isHit = false;
            string hitCar = string.Empty;

            while (input != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                    input = Console.ReadLine();
                    continue;
                }
                int greenLightDuration = previousGreen;
                while (greenLightDuration > 0 && cars.Count > 0)
                {
                    string carName = cars.Dequeue();
                    int carLength = carName.Length;

                    if (greenLightDuration >= carLength)
                    {
                        greenLightDuration -= carLength;
                        totalCars++;
                    }
                    else
                    {
                        greenLightDuration += freeWindowDuration;
                        if (greenLightDuration >= carLength)
                        {
                            totalCars++;
                            break;
                        }
                        else
                        {
                            isHit = true;
                            hitCar = carName;
                            carHitSymbol = carName[greenLightDuration];
                            break;
                        }
                    }
                }
                if (isHit)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            if (isHit)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{hitCar} was hit at {carHitSymbol}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCars} total cars passed the crossroads.");
            }
        }
    }
}
