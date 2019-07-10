using System;
using System.Linq;

namespace P06.JaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] arr = new int[rows][];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                arr[i] = nums;
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                int currRow = int.Parse(tokens[1]);
                int currCol = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (currRow < 0 || currRow >= rows || currCol < 0 || currCol >= arr[currRow].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }
                switch (action)
                {
                    case "Add":
                        arr[currRow][currCol] += value;
                        break;
                    case "Subtract":
                        arr[currRow][currCol] -= value;
                        break;
                }

            }
            foreach (var item in arr)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
