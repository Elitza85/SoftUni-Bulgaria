using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();
            int N = firstLine[0];
            int S = firstLine[1];
            int X = firstLine[2];


            for (int i = 0; i < N; i++)
            {
                stack.Push(secondLine[i]);
            }

            for (int j = 0; j < S; j++)
            {
                stack.Pop();
            }


            Console.WriteLine(stack.Count == 0 ? "0" : stack.Contains(X) ? "true" : $"{stack.Min()}");
        }
    }
}

