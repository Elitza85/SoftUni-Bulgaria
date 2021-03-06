using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalFood = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                int currentOrder = queue.Peek();
                if (totalFood - currentOrder < 0)
                {
                    break;
                }
                totalFood -= queue.Dequeue();

            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.Write($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
