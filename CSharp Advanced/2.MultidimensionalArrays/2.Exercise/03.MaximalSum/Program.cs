using System;
using System.Linq;

namespace P03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dim = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] arr = new int[dim[0], dim[1]];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int[] nums = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = nums[j];
                }
            }

            int maxSum = int.MinValue;
            int currRow = 0;
            int currCol = 0;

            for (int row = 0; row < arr.GetLength(0) - 2; row++)
            {
                int sum = 0;
                for (int col = 0; col < arr.GetLength(1) - 2; col++)
                {
                    sum = arr[row, col]
                        + arr[row, col + 1]
                        + arr[row, col + 2]
                        + arr[row + 1, col]
                        + arr[row + 1, col + 1]
                        + arr[row + 1, col + 2]
                        + arr[row + 2, col]
                        + arr[row + 2, col + 1]
                        + arr[row + 2, col + 2];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        currRow = row;
                        currCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            Console.WriteLine($"{arr[currRow, currCol]} {arr[currRow, currCol + 1]} {arr[currRow, currCol + 2]}");
            Console.WriteLine($"{arr[currRow + 1, currCol]} {arr[currRow + 1, currCol + 1]} {arr[currRow + 1, currCol + 2]}");
            Console.WriteLine($"{arr[currRow + 2, currCol]} {arr[currRow + 2, currCol + 1]} {arr[currRow + 2, currCol + 2]}");

        }
    }
}
