using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggerColl =
                new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input = Console.ReadLine();
            while (input != "Statistics")
            {
                if (input.Contains("joined"))
                {
                    string username = input.Split()[0];

                    if (!vloggerColl.ContainsKey(username))
                    {
                        vloggerColl[username] = new Dictionary<string, HashSet<string>>();
                        vloggerColl[username]["followings"] = new HashSet<string>();
                        vloggerColl[username]["followers"] = new HashSet<string>();
                    }
                }
                else if (input.Contains("followed"))
                {
                    string[] usernames = input.Split();
                    string firstVlogger = usernames[0];
                    string secondVlogger = usernames[2];

                    if (!vloggerColl.ContainsKey(firstVlogger)
                        || !vloggerColl.ContainsKey(secondVlogger)
                        || firstVlogger == secondVlogger)
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    vloggerColl[firstVlogger]["followings"].Add(secondVlogger);
                    vloggerColl[secondVlogger]["followers"].Add(firstVlogger);

                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {vloggerColl.Count} vloggers in its logs.");

            int count = 1;

            var sortedVloggers = vloggerColl
                .OrderByDescending(f => f.Value["followers"].Count)
                .ThenBy(f => f.Value["followings"].Count)
                .ToDictionary(k => k.Key, y => y.Value);


            foreach (var (username, value) in sortedVloggers)
            {
                int followersCOunt = sortedVloggers[username]["followers"].Count;
                int followingsCOunt = sortedVloggers[username]["followings"].Count;
                Console.WriteLine($"{count}. {username} : {followersCOunt} followers, {followingsCOunt} following");

                if (count == 1)
                {
                    var followersCOllection = value["followers"].OrderBy(x => x).ToList();

                    foreach (var currentUsername in followersCOllection)
                    {
                        Console.WriteLine($"*  {currentUsername}");
                    }
                }
                count++;
            }
        }
    }
}
