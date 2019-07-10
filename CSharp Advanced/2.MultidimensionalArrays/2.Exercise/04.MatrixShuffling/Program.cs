using System;
using System.Linq;


namespace P04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dims = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] arr1 = new string[dims[0], dims[1]];
            int[,] arr2 = new int[dims[0], dims[1]];
            bool isString = false;


            for (int i = 0; i < dims[0]; i++)
            {
                string[] matrixInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int valuesOfCols = 0;
                for (int j = 0; j < dims[1]; j++)
                {
                    if (int.TryParse(matrixInput[j], out valuesOfCols))
                    {
                        arr2[i, j] = int.Parse(matrixInput[j]);
                        continue;
                    }
                    else
                    {
                        arr1[i, j] = matrixInput[j];
                        isString = true;
                    }

                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                bool isValid = false;
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 5 && tokens[0] == "swap"
                    && (int.Parse(tokens[1]) >= 0
                    && int.Parse(tokens[1]) < dims[0])
                    && (int.Parse(tokens[2]) >= 0
                    && int.Parse(tokens[2]) < dims[1])
                    && (int.Parse(tokens[3]) >= 0
                    && int.Parse(tokens[3]) < dims[0])
                    && (int.Parse(tokens[4]) >= 0
                    && int.Parse(tokens[4]) < dims[1]))
                {
                    isValid = true;
                }

                if (!isValid)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int currRow = int.Parse(tokens[1]);
                int currCol = int.Parse(tokens[2]);
                int newRow = int.Parse(tokens[3]);
                int newCol = int.Parse(tokens[4]);
                if (isString)
                {
                    string currWord = arr1[currRow, currCol];
                    string replacementWord = arr1[newRow, newCol];
                    arr1[currRow, currCol] = replacementWord;
                    arr1[newRow, newCol] = currWord;
                    for (int row = 0; row < arr1.GetLength(0); row++)
                    {
                        for (int col = 0; col < arr1.GetLength(1); col++)
                        {
                            Console.Write($"{arr1[row, col]} ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    int currNum = arr2[currRow, currCol];
                    int replacementNum = arr2[newRow, newCol];
                    arr2[currRow, currCol] = replacementNum;
                    arr2[newRow, newCol] = currNum;
                    for (int row = 0; row < arr2.GetLength(0); row++)
                    {
                        for (int col = 0; col < arr2.GetLength(1); col++)
                        {
                            Console.Write($"{arr2[row, col]} ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
