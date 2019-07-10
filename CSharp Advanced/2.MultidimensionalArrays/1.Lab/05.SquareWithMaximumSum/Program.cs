using System;
using System.Linq;

namespace P05.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dims = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] arr = new int[dims[0], dims[1]];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = tokens[j];
                }
            }

            int maxSum = int.MinValue;
            int currRow = 0;
            int currCol = 0;

            for (int row = 0; row < arr.GetLength(0) - 1; row++)
            {
                int sum = 0;
                for (int col = 0; col < arr.GetLength(1) - 1; col++)
                {
                    sum = arr[row, col] + arr[row, col + 1]
                        + arr[row + 1, col] + arr[row + 1, col + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        currRow = row;
                        currCol = col;
                    }
                }
            }
            Console.WriteLine($"{arr[currRow, currCol]} {arr[currRow, currCol + 1]}");
            Console.WriteLine($"{arr[currRow + 1, currCol]} {arr[currRow + 1, currCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
