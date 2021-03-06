using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            int elementsToEnque = elements[0];
            int elementsToDequeue = elements[1];
            int elementInQueue = elements[2];

            for (int i = 0; i < elementsToEnque; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            for (int j = 0; j < elementsToDequeue; j++)
            {
                queue.Dequeue();
            }
            Console.WriteLine(queue.Count == 0 ? "0" : queue.Contains(elementInQueue) ? "true" : $"{queue.Min()}");
        }
    }
}
