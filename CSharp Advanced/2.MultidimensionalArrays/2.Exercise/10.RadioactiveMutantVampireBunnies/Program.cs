using System;
using System.Linq;
using System.Collections.Generic;

namespace P10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dims = Console.ReadLine()
             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();

            char[,] liar = new char[dims[0], dims[1]];
            int playerCurrRow = 0;
            int playerCurrCol = 0;
            List<int> coordinates = new List<int>();
            bool isDead = false;
            bool hasWon = false;

            for (int i = 0; i < liar.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < liar.GetLength(1); j++)
                {
                    liar[i, j] = input[j];
                    if (liar[i, j] == 'P')
                    {
                        playerCurrRow = i;
                        playerCurrCol = j;
                    }
                }
            }

            char[] commands = Console.ReadLine().ToCharArray();
            for (int k = 0; k < commands.Length; k++)
            {
                char command = commands[k];
                for (int i = 0; i < liar.GetLength(0); i++)
                {
                    for (int j = 0; j < liar.GetLength(1); j++)
                    {
                        if (liar[i, j] == 'B')
                        {
                            coordinates.Add(i);
                            coordinates.Add(j);
                        }
                    }
                }
                switch (command)
                {
                    case 'L':
                        if (playerCurrCol - 1 >= 0 && playerCurrCol - 1 < liar.GetLength(1))
                        {
                            playerCurrCol = playerCurrCol - 1;
                            if (liar[playerCurrRow, playerCurrCol] == 'B')
                            {
                                isDead = true;
                                break;
                            }
                            else
                            {
                                liar[playerCurrRow, playerCurrCol] = 'P';
                                liar[playerCurrRow, playerCurrCol + 1] = '.';
                            }
                        }

                        else
                        {
                            liar[playerCurrRow, playerCurrCol] = '.';
                            hasWon = true;
                            break;
                        }

                        break;
                    case 'R':
                        if (playerCurrCol + 1 >= 0 && playerCurrCol + 1 < liar.GetLength(1))
                        {
                            playerCurrCol = playerCurrCol + 1;
                            if (liar[playerCurrRow, playerCurrCol] == 'B')
                            {
                                isDead = true;
                                break;
                            }
                            else
                            {
                                liar[playerCurrRow, playerCurrCol] = 'P';
                                liar[playerCurrRow, playerCurrCol - 1] = '.';
                            }
                        }
                        else
                        {
                            liar[playerCurrRow, playerCurrCol] = '.';
                            hasWon = true;
                            break;
                        }

                        break;
                    case 'U':
                        if (playerCurrRow - 1 >= 0 && playerCurrRow - 1 < liar.GetLength(0))
                        {
                            playerCurrRow = playerCurrRow - 1;
                            if (liar[playerCurrRow, playerCurrCol] == 'B')
                            {
                                isDead = true;
                                break;
                            }
                            else
                            {
                                liar[playerCurrRow, playerCurrCol] = 'P';
                                liar[playerCurrRow + 1, playerCurrCol] = '.';
                            }
                        }
                        else
                        {
                            liar[playerCurrRow, playerCurrCol] = '.';
                            hasWon = true;
                            break;
                        }
                        break;
                    case 'D':
                        if (playerCurrRow + 1 >= 0 && playerCurrRow + 1 < liar.GetLength(0))
                        {
                            playerCurrRow = playerCurrRow + 1;
                            if (liar[playerCurrRow, playerCurrCol] == 'B')
                            {
                                isDead = true;
                                break;
                            }
                            else
                            {
                                liar[playerCurrRow, playerCurrCol] = 'P';
                                liar[playerCurrRow - 1, playerCurrCol] = '.';
                            }
                        }
                        else
                        {
                            liar[playerCurrRow, playerCurrCol] = '.';
                            hasWon = true;
                            break;
                        }
                        break;
                }
                for (int m = 0; m < coordinates.Count; m += 2)
                {
                    int bunnyCurrRow = coordinates[m];
                    int bunnyCurrCol = coordinates[m + 1];
                    if (bunnyCurrRow - 1 >= 0 && bunnyCurrRow - 1 < liar.GetLength(0))
                    {
                        if (liar[bunnyCurrRow - 1, bunnyCurrCol] == '.')
                        {
                            liar[bunnyCurrRow - 1, bunnyCurrCol] = 'B';
                        }
                        else if (liar[bunnyCurrRow - 1, bunnyCurrCol] == 'P')
                        {
                            liar[bunnyCurrRow - 1, bunnyCurrCol] = 'B';
                            isDead = true;
                        }

                    }
                    if (bunnyCurrRow + 1 >= 0 && bunnyCurrRow + 1 < liar.GetLength(0))
                    {
                        if (liar[bunnyCurrRow + 1, bunnyCurrCol] == '.')
                        {
                            liar[bunnyCurrRow + 1, bunnyCurrCol] = 'B';
                        }
                        else if (liar[bunnyCurrRow + 1, bunnyCurrCol] == 'P')
                        {
                            liar[bunnyCurrRow + 1, bunnyCurrCol] = 'B';
                            isDead = true;
                        }
                    }
                    if (bunnyCurrCol - 1 >= 0 && bunnyCurrCol - 1 < liar.GetLength(1))
                    {
                        if (liar[bunnyCurrRow, bunnyCurrCol - 1] == '.')
                        {
                            liar[bunnyCurrRow, bunnyCurrCol - 1] = 'B';
                        }
                        else if (liar[bunnyCurrRow, bunnyCurrCol - 1] == 'P')
                        {
                            liar[bunnyCurrRow, bunnyCurrCol - 1] = 'B';
                            isDead = true;
                        }
                    }
                    if (bunnyCurrCol + 1 >= 0 && bunnyCurrCol + 1 < liar.GetLength(1))
                    {
                        if (liar[bunnyCurrRow, bunnyCurrCol + 1] == '.')
                        {
                            liar[bunnyCurrRow, bunnyCurrCol + 1] = 'B';
                        }
                        else if (liar[bunnyCurrRow, bunnyCurrCol + 1] == 'P')
                        {
                            liar[bunnyCurrRow, bunnyCurrCol + 1] = 'B';
                            isDead = true;
                        }
                    }
                    if (m == coordinates.Count - 2)
                    {
                        coordinates.Clear();
                    }
                }

                if (isDead || hasWon)
                {
                    break;
                }
            }

            for (int row = 0; row < liar.GetLength(0); row++)
            {
                for (int col = 0; col < liar.GetLength(1); col++)
                {
                    Console.Write(liar[row, col]);
                }
                Console.WriteLine();
            }
            if (isDead)
            {
                Console.WriteLine($"dead: {playerCurrRow} {playerCurrCol}");
            }
            else if (hasWon)
            {
                Console.WriteLine($"won: {playerCurrRow} {playerCurrCol}");
            }
        }
    }
}
