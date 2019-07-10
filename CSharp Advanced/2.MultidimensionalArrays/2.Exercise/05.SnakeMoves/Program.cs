using System;
using System.Linq;

namespace P05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dims = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string snake = Console.ReadLine();

            char[,] arr = new char[dims[0], dims[1]];
            int count = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {

                    arr[i, j] = snake[count++];
                    if (snake.Length == count)
                    {
                        count = 0;
                    }
                }
            }

            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    Console.Write($"{arr[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
