using System;


namespace P04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int dims = int.Parse(Console.ReadLine());

            char[,] arr = new char[dims, dims];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                char[] chars = Console.ReadLine().ToCharArray();
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = chars[j];
                }
            }

            bool exists = false;
            char symbol = char.Parse(Console.ReadLine());

            for (int rows = 0; rows < arr.GetLength(0); rows++)
            {
                for (int cols = 0; cols < arr.GetLength(1); cols++)
                {
                    if (arr[rows, cols] == symbol)
                    {
                        int currRow = rows;
                        int currCol = cols;
                        Console.WriteLine($"({currRow}, {currCol})");
                        exists = true;
                        break;
                    }
                }
                if (exists)
                {
                    break;
                }
            }

            if (!exists)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
