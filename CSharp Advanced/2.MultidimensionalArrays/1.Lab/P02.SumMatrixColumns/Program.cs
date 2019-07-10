using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] arr = new int[dimensions[0], dimensions[1]];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = tokens[j];
                }
            }

            for (int col = 0; col < arr.GetLength(1); col++)
            {
                int sum = 0;
                for (int rows = 0; rows < arr.GetLength(0); rows++)
                {
                    sum += arr[rows, col];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
