using System;
using System.Linq;

namespace P02.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dims = Console.ReadLine().Split().Select(int.Parse).ToArray();

            char[,] arr = new char[dims[0], dims[1]];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                char[] charsArr = Console.ReadLine().ToCharArray().Where(c => c != ' ').ToArray();
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = charsArr[j];
                }
            }

            int counter = 0;
            for (int row = 0; row < arr.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < arr.GetLength(1) - 1; col++)
                {
                    if (arr[row, col] == arr[row, col + 1]
                        && arr[row, col + 1] == arr[row + 1, col]
                        && arr[row + 1, col] == arr[row + 1, col + 1])
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
