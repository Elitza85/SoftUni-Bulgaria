using System;
using System.Collections.Generic;
using System.Linq;

namespace P12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] bottlesLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bottles = new Stack<int>(bottlesLine);
            Queue<int> cups = new Queue<int>(cupsLine);

            bool finishCups = false;
            bool finishBottles = false;
            int wastedWater = 0;

            while (bottles.Count > 0 && cups.Count > 0)
            {
                for (int i = 0; i < cups.Count; i++)
                {
                    if (cups.Peek() > bottles.Peek())
                    {
                        int currCup = cups.Peek();
                        while (currCup > 0 && bottles.Count > 0)
                        {
                            int currBottle = bottles.Pop();
                            if (currBottle >= currCup)
                            {
                                currBottle -= currCup;
                                wastedWater += currBottle;
                                cups.Dequeue();
                                break;
                            }
                            else
                            {
                                currCup -= currBottle;
                            }
                        }
                        if (currCup <= 0)
                        {
                            cups.Dequeue();
                        }
                    }
                    else if (cups.Peek() <= bottles.Peek())
                    {
                        int currentBottle = bottles.Pop();
                        currentBottle -= cups.Dequeue();
                        wastedWater += currentBottle;
                    }
                    if (cups.Count == 0)
                    {
                        finishCups = true;
                        break;
                    }
                    if (bottles.Count == 0)
                    {
                        finishBottles = true;
                        break;
                    }
                }
            }
            if (finishBottles)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            if (finishCups)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
