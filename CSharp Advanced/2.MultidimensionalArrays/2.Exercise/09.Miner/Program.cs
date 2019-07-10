using System;
using System.Linq;

namespace P09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();

            char[,] field = new char[size, size];
            int currRow = 0;
            int currCol = 0;
            int countCoals = 0;

            int totalCoals = 0;

            for (int i = 0; i < size; i++)
            {
                char[] lineOfFiled = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => x != " ")
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = lineOfFiled[j];
                    if (field[i, j] == 's')
                    {
                        currRow = i;
                        currCol = j;
                    }
                    if (field[i, j] == 'c')
                    {
                        totalCoals++;
                    }
                }
            }

            bool oneHappened = false;
            for (int k = 0; k < commands.Length; k++)
            {
                int remainCoals = 0;
                string command = commands[k];
                switch (command)
                {
                    case "left":

                        if (currCol - 1 >= 0 && currCol - 1 < field.GetLength(1))
                        {
                            currCol = currCol - 1;
                            if (field[currRow, currCol] == 'c')
                            {
                                field[currRow, currCol] = '*';
                                countCoals++;
                                foreach (var item in field)
                                {
                                    if (item == 'c')
                                    {
                                        remainCoals++;
                                        break;
                                    }
                                }
                                if (remainCoals == 0)
                                {
                                    oneHappened = true;
                                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                    break;
                                }
                            }
                            else if (field[currRow, currCol] == 'e')
                            {
                                oneHappened = true;
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                break;
                            }
                        }
                        break;
                    case "right":
                        if (currCol + 1 >= 0 && currCol + 1 < field.GetLength(1))
                        {
                            currCol = currCol + 1;
                            if (field[currRow, currCol] == 'c')
                            {
                                field[currRow, currCol] = '*';
                                countCoals++;
                                foreach (var item in field)
                                {
                                    if (item == 'c')
                                    {
                                        remainCoals++;
                                        break;
                                    }
                                }
                                if (remainCoals == 0)
                                {
                                    oneHappened = true;
                                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                    break;
                                }
                            }
                            else if (field[currRow, currCol] == 'e')
                            {
                                oneHappened = true;
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                            }
                        }
                        break;
                    case "up":
                        if (currRow - 1 >= 0 && currRow - 1 < field.GetLength(0))
                        {
                            currRow = currRow - 1;
                            if (field[currRow, currCol] == 'c')
                            {
                                field[currRow, currCol] = '*';
                                countCoals++;
                                foreach (var item in field)
                                {
                                    if (item == 'c')
                                    {
                                        remainCoals++;
                                        break;
                                    }
                                }
                                if (remainCoals == 0)
                                {
                                    oneHappened = true;
                                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                    break;
                                }
                            }
                            else if (field[currRow, currCol] == 'e')
                            {
                                oneHappened = true;
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                            }
                        }
                        break;
                    case "down":
                        if (currRow + 1 >= 0 && currRow + 1 < field.GetLength(0))
                        {
                            currRow = currRow + 1;
                            if (field[currRow, currCol] == 'c')
                            {
                                field[currRow, currCol] = '*';
                                countCoals++;
                                foreach (var item in field)
                                {
                                    if (item == 'c')
                                    {
                                        remainCoals++;
                                        break;
                                    }
                                }
                                if (remainCoals == 0)
                                {
                                    oneHappened = true;
                                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                    break;
                                }
                            }
                            else if (field[currRow, currCol] == 'e')
                            {
                                oneHappened = true;
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                            }
                        }
                        break;
                }
            }
            if (!oneHappened)
            {
                Console.WriteLine($"{totalCoals - countCoals} coals left. ({currRow}, {currCol})");
            }
        }
    }
}
