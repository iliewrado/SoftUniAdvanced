using System;
using System.Collections.Generic;
using System.Linq;

namespace _08Ranking
{
    class ProgramRanking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> students = new Dictionary<string, Dictionary<string, int>>();
            string[] input = Console.ReadLine()
                .Split(':', StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "end of contests")
            {
                string contest = input[0];
                string password = input[1];
                contests.Add(contest, password);
                input = Console.ReadLine()
                .Split(':', StringSplitOptions.RemoveEmptyEntries);
            }
            input = Console.ReadLine()
                .Split("=>", StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "end of submissions")
            {
                string contest = input[0];
                string password = input[1];
                string username = input[2];
                int points = int.Parse(input[3]);

                if (contests.ContainsKey(contest) && contests.ContainsValue(password))
                {
                    if (!students.ContainsKey(username))
                    {
                        students.Add(username, new Dictionary<string, int>());
                    }
                    if (!students[username].ContainsKey(contest))
                    {
                        students[username].Add(contest, 0);
                    }
                    if (students[username][contest] < points)
                    {
                        students[username][contest] = points;
                    }
                }

                input = Console.ReadLine()
                .Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }
            int bestPoints = 0;
            string user = string.Empty;
            foreach (var student in students)
            {
                int sum = 0;
                foreach (var points in student.Value)
                {
                    sum += points.Value;
                }
                if (bestPoints < sum)
                {
                    bestPoints = sum;
                    user = student.Key;
                }

            }

            Console.WriteLine($"Best candidate is {user} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var student in students.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{student.Key}");
                foreach (var contest in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
