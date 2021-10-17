using System;
using System.Collections.Generic;

namespace _01UniqueUsernames
{
    class ProgramUniqueUsernames
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                usernames.Add(input);
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }
    }
}
