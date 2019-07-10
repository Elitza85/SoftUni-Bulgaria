using System;

namespace P07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] board = new char[size, size];

            int[] indexes = new int[]
            {
                1,2,
                2,1,
                1,-2,
                2,-1,
                -1,2,
                -1,-2,
                -2,1,
                -2,-1
            };

            for (int i = 0; i < size; i++)
            {
                char[] lines = Console.ReadLine().ToCharArray();
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = lines[j];
                }
            }

            int counter = 0;

            while (true)
            {
                int maxCount = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        int currentCOunt = 0;
                        if (board[row, col] == 'K')
                        {
                            for (int i = 0; i < indexes.Length; i += 2)
                            {
                                if (row + indexes[i] >= 0 && row + indexes[i] < board.GetLength(0)
                                    && col + indexes[i + 1] >= 0 && col + indexes[i + 1] < board.GetLength(1)
                                    && board[row + indexes[i], col + indexes[i + 1]] == 'K')
                                {
                                    currentCOunt++;
                                }
                            }
                        }

                        if (currentCOunt > maxCount)
                        {
                            maxCount = currentCOunt;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }
                if (maxCount == 0)
                {
                    break;
                }

                board[knightRow, knightCol] = '0';
                counter++;
            }
            Console.WriteLine(counter);

        }
    }
}
