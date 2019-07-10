using System;
using System.Linq;

namespace P06.BombTheBasement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dims = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] basement = new int[dims[0], dims[1]];

            int[] coordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int targetRow = coordinates[0];
            int targetCol = coordinates[1];
            int radius = coordinates[2];

            for (int i = 0; i < dims[0]; i++)
            {
                for (int j = 0; j < dims[1]; j++)
                {
                    basement[i, j] = 0;
                }
            }

            for (int row = 0; row < basement.GetLength(0); row++)
            {
                for (int col = 0; col < basement.GetLength(1); col++)
                {
                    bool isInRadius = Math.Pow(row - targetRow, 2) + Math.Pow(col - targetCol, 2) <= Math.Pow(radius, 2);

                    if (isInRadius)
                    {
                        basement[row, col] = 1;
                    }
                }
            }

            for (int col = 0; col < basement.GetLength(1); col++)
            {
                int counter = 0;
                for (int row = 0; row < basement.GetLength(0); row++)
                {
                    if (basement[row, col] == 1)
                    {
                        counter++;
                        basement[row, col] = 0;
                    }
                }
                for (int row = 0; row < counter; row++)
                {
                    basement[row, col] = 1;
                }
            }

            for (int i = 0; i < basement.GetLength(0); i++)
            {
                for (int j = 0; j < basement.GetLength(1); j++)
                {
                    Console.Write(basement[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
