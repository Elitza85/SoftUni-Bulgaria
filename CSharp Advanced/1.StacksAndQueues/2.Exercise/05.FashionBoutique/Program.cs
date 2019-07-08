using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine()
                .Split().Select(int.Parse).ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());
            int total = 0;
            int racks = 1;

            while (stack.Count > 0)
            {
                int pieceOfCloth = stack.Peek();
                total += pieceOfCloth;

                if (total < rackCapacity)
                {
                    stack.Pop();
                }
                else if (total == rackCapacity)
                {
                    stack.Pop();
                    if (stack.Count > 0)
                    {
                        racks++;
                        total = 0;
                    }
                }
                else if (total > rackCapacity)
                {
                    stack.Pop();
                    racks++;
                    total = pieceOfCloth;
                }
            }
            Console.WriteLine($"{racks}");
        }
    }
}
