using System;
using System.Collections.Generic;
using System.Linq;

namespace _11ThePartyReservationFilterModule
{
    class ProgramThePartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> filters = new List<string>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] command = input
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                if (command.Contains("Add filter"))
                {
                    filters.Add(command[1] + " " + command[2]);
                }
                else
                {
                    filters.Remove(command[1] + " " + command[2]);
                }

            }

            foreach (var filter in filters)
            {
                string[] command = filter
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Starts":
                        guests.RemoveAll(x => x.StartsWith(command[2]));
                        break;
                    case "Ends":
                        guests.RemoveAll(x => x.EndsWith(command[2]));
                        break;
                    case "Length":
                        int length = int.Parse(command[1]);
                        guests.RemoveAll(x => x.Length == length);
                        break;
                    case "Contains":
                        guests.RemoveAll(x => x.Contains(command[1]));
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", guests));
        }
    }
}
