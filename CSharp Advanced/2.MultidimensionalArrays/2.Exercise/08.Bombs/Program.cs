using System;
using System.Linq;

namespace P08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] field = new int[size, size];

            for (int i = 0; i < field.GetLength(0); i++)
            {
                int[] nums = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = nums[j];
                }
            }

            string[] coordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int k = 0; k < coordinates.Length; k++)
            {
                int[] rowColSet = coordinates[k].Split(",").Select(int.Parse).ToArray();
                int currRow = rowColSet[0];
                int currCol = rowColSet[1];
                int damage = field[currRow, currCol];

                if (damage > 0)
                {
                    if (currRow - 1 >= 0 && currRow - 1 < field.GetLength(0)
                    && currCol - 1 >= 0 && currCol - 1 < field.GetLength(1)
                    && field[currRow - 1, currCol - 1] > 0)
                    {
                        field[currRow - 1, currCol - 1] -= damage;
                    }
                    if (currCol - 1 >= 0 && currCol - 1 < field.GetLength(1)
                        && field[currRow, currCol - 1] > 0)
                    {
                        field[currRow, currCol - 1] -= damage;
                    }
                    if (currRow + 1 >= 0 && currRow + 1 < field.GetLength(0)
                        && currCol - 1 >= 0 && currCol - 1 < field.GetLength(1)
                        && field[currRow + 1, currCol - 1] > 0)
                    {
                        field[currRow + 1, currCol - 1] -= damage;
                    }
                    if (currRow + 1 >= 0 && currRow + 1 < field.GetLength(0)
                        && field[currRow + 1, currCol] > 0)
                    {
                        field[currRow + 1, currCol] -= damage;
                    }
                    if (currRow + 1 >= 0 && currRow + 1 < field.GetLength(0)
                        && currCol + 1 >= 0 && currCol + 1 < field.GetLength(1)
                        && field[currRow + 1, currCol + 1] > 0)
                    {
                        field[currRow + 1, currCol + 1] -= damage;
                    }
                    if (currCol + 1 >= 0 && currCol + 1 < field.GetLength(1)
                        && field[currRow, currCol + 1] > 0)
                    {
                        field[currRow, currCol + 1] -= damage;
                    }
                    if (currRow - 1 >= 0 && currRow - 1 < field.GetLength(0)
                        && currCol + 1 >= 0 && currCol + 1 < field.GetLength(1)
                        && field[currRow - 1, currCol + 1] > 0)
                    {
                        field[currRow - 1, currCol + 1] -= damage;
                    }
                    if (currRow - 1 >= 0 && currRow - 1 < field.GetLength(0)
                        && field[currRow - 1, currCol] > 0)
                    {
                        field[currRow - 1, currCol] -= damage;
                    }

                    field[currRow, currCol] = 0;
                }

            }

            int sum = 0;
            int countAlive = 0;
            foreach (var item in field)
            {
                if (item > 0)
                {
                    sum += item;
                    countAlive++;
                }
            }
            Console.WriteLine($"Alive cells: {countAlive}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write($"{field[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
