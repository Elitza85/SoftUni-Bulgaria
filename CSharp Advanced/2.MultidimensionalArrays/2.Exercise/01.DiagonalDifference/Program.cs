using System;
using System.Linq;

namespace P01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] arr = new int[size, size];


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

            int sum1 = 0;
            int sum2 = 0;
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                int currCol1 = row;
                sum1 += arr[row, currCol1];
            }

            int currRow = 0;
            for (int col = arr.GetLength(1) - 1; col >= 0; col--)
            {
                sum2 += arr[currRow, col];
                currRow++;
            }
            Console.WriteLine($"{Math.Abs(sum1 - sum2)}");
        }
    }
}
