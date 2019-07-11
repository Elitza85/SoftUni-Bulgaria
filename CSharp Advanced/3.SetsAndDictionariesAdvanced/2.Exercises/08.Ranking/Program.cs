using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = string.Empty;

            List<string> contests = new List<string>();
            Dictionary<string, Dictionary<string, int>> db =
                new Dictionary<string, Dictionary<string, int>>();

            while ((line = Console.ReadLine()) != "end of contests")
            {
                contests.Add(line);
            }

            while ((line = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = line.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];
                string user = tokens[2];
                int points = int.Parse(tokens[3]);
                bool validContest = false;
                bool validPass = false;

                for (int i = 0; i < contests.Count; i++)
                {
                    string[] initialInputTokens = contests[i].Split(":");
                    string initialContest = initialInputTokens[0];
                    string initialPass = initialInputTokens[1];
                    if (contest == initialContest)
                    {
                        validContest = true;
                    }
                    if (password == initialPass)
                    {
                        validPass = true;
                    }
                    if (validContest && validPass)
                    {
                        break;
                    }
                }
                if (validContest && validPass)
                {
                    if (!db.ContainsKey(user))
                    {
                        db[user] = new Dictionary<string, int>();

                    }
                    if (!db[user].ContainsKey(contest))
                    {
                        db[user][contest] = 0;
                    }
                    if (db[user][contest] < points)
                    {
                        db[user][contest] = points;
                    }
                }
            }

            int bestPoints = 0;
            string bestUser = string.Empty;
            foreach (var item in db)
            {
                int currentSum = 0;
                var contestsAndPoints = item.Value;
                foreach (var contest in contestsAndPoints)
                {
                    currentSum += contest.Value;
                }
                if (currentSum > bestPoints)
                {
                    bestPoints = currentSum;
                    bestUser = item.Key;
                }
            }
            Console.WriteLine($"Best candidate is {bestUser} with total {bestPoints} points.");
            Console.WriteLine("Ranking: ");
            foreach (var student in db.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);
                foreach (var item in student.Value.OrderByDescending(p => p.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
