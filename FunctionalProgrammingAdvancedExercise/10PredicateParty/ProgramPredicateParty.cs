using System;
using System.Collections.Generic;
using System.Linq;

namespace _10PredicateParty
{
    class ProgramPredicateParty
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (command.Contains("Remove"))
                {
                    switch (command[1])
                    {
                        case "StartsWith":
                            people.RemoveAll(x => x.StartsWith(command[2]));
                            break;
                        case "EndsWith":
                            people.RemoveAll(x => x.EndsWith(command[2]));
                            break;
                        case "Length":
                            int length = int.Parse(command[2]);
                            people.RemoveAll(x => x.Length == length);
                            break;
                    }
                }
                else if(command.Contains("Double"))
                {
                    switch (command[1])
                    {
                        case "StartsWith":
                            int index = people.IndexOf(people.Find(x => x.StartsWith(command[2])));
                            List<string> name = people.FindAll(x => x.StartsWith(command[2]));
                            name.ForEach(x => people.Insert(index, x));
                            break;
                        case "EndsWith":
                            index = people.IndexOf(people.Find(x => x.EndsWith(command[2])));
                            name = people.FindAll(x => x.EndsWith(command[2]));
                            name.ForEach(x => people.Insert(index, x));
                            break;
                        case "Length":
                            int length = int.Parse(command[2]);
                            index = people.IndexOf(people.Find(x => x.Length == length));
                            name = people.FindAll(x => x.Length == length);
                            name.ForEach(x => people.Insert(index, x));
                            break;
                    }
                }
            }

            Console.WriteLine(people.Count > 0 
                ? $"{string.Join(", ", people)} are going to the party!" 
                : "Nobody is going to the party!");
        }
    }
}
