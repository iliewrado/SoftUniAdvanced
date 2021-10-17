using System;
using System.Collections.Generic;
using System.Linq;

namespace _07TheVLogger
{
    class ProgramTheVLogger
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vLoggers = 
                new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string[] input = ReadArrayConsole();

            while (input[0] != "Statistics")
            {
                string username = input[0];
                if (input[1] == "joined")
                {
                    if (!vLoggers.ContainsKey(username))
                    {
                        vLoggers.Add(username, new Dictionary<string, HashSet<string>>());
                        vLoggers[username].Add("Followers", new HashSet<string>());
                        vLoggers[username].Add("Folloing", new HashSet<string>());
                    }

                }
                else if (input[1] == "followed")
                {
                    string fallowing = input[2];

                    if (vLoggers.ContainsKey(username)
                        && vLoggers.ContainsKey(fallowing)
                        && username != fallowing)
                    {
                        vLoggers[fallowing]["Followers"].Add(username);
                        vLoggers[username]["Folloing"].Add(fallowing);
                    }
                }

                input = ReadArrayConsole();
            }

            Console.WriteLine($"The V-Logger has a total of {vLoggers.Count} vloggers in its logs.");

            int No = 1;

            foreach (var vlogger in vLoggers.OrderByDescending(x => x.Value["Followers"].Count).ThenBy(x => x.Value["Folloing"].Count))
            {
                Console.WriteLine($"{No}. {vlogger.Key} : {vlogger.Value["Followers"].Count} followers, {vlogger.Value["Folloing"].Count} following");

                if (No == 1)
                {
                    foreach (var fallower in vlogger.Value["Followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {fallower}");
                    }
                }
                No++;
            }
        }
        public static string[] ReadArrayConsole()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

