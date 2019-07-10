using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] arr = new int[matrixSize, matrixSize];

            for (int row = 0; row < arr.GetLength(0); row++)
            {
                int[] tokens = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    arr[row, col] = tokens[col];
                }
            }

            int sum = 0;
            for (int currRow = 0; currRow < arr.GetLength(0); currRow++)
            {
                int currCol = currRow;
                sum += arr[currRow, currCol];
            }
            Console.WriteLine(sum);
        }
    }
}
