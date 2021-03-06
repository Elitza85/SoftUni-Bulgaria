using System;
using System.Collections.Generic;
using System.Linq;

namespace P11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] locks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int intelligencePay = int.Parse(Console.ReadLine());

            Stack<int> bulletsLine = new Stack<int>(bullets);
            Queue<int> locksLine = new Queue<int>(locks);
            int currGunBarrel = gunBarrel;
            bool outOfBullets = false;
            bool outOfLocks = false;

            while (locksLine.Count > 0 && bulletsLine.Count > 0)
            {
                for (int j = 0; j < locksLine.Count; j++)
                {
                    int currLock = locksLine.Peek();
                    int currBullet = bulletsLine.Pop();
                    intelligencePay -= bulletPrice;
                    currGunBarrel--;
                    if (currBullet <= currLock)
                    {
                        Console.WriteLine("Bang!");
                        locksLine.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }
                    if (currGunBarrel == 0 && bulletsLine.Count > 0)
                    {
                        currGunBarrel = gunBarrel;
                        Console.WriteLine("Reloading!");
                    }
                    if (locksLine.Count == 0)
                    {
                        outOfLocks = true;
                        break;
                    }
                    if (bulletsLine.Count == 0)
                    {
                        outOfBullets = true;
                        break;
                    }

                }
            }
            if (outOfLocks)
            {
                Console.WriteLine($"{bulletsLine.Count} bullets left. Earned ${intelligencePay}");
            }
            if (outOfBullets)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksLine.Count}");
            }
        }
    }
}
