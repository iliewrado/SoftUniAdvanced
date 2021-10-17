using System;
using System.Collections.Generic;

namespace _07SoftUniParty
{
    class ProgramSoftUniParty
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> vipGests = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vipGests.Add(input);
                }
                else
                {
                    regular.Add(input);
                }
            }
            while ((input = Console.ReadLine()) != "END")
            {
                if (vipGests.Contains(input))
                {
                    vipGests.Remove(input);
                }
                else
                {
                    regular.Remove(input);
                }
            }
            Console.WriteLine($"{vipGests.Count + regular.Count}");
            foreach (var gest in vipGests)
            {
                Console.WriteLine(gest);
            }
            foreach (var gest in regular)
            {
                Console.WriteLine(gest);
            }

        }
    }
}
