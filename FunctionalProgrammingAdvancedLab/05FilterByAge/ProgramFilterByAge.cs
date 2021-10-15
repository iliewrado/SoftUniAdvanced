using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FilterByAge
{
    class ProgramFilterByAge
    {
        static void Main(string[] args)
        {
            Func<(string name, int age), int, bool> younger = (person, age) => person.age < age;
            Func<(string name, int age), int, bool> older = (person, age) => person.age >= age;
            List<(string name, int age)> people = new List<(string name, int age)>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] person = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                people.Add((person[0], int.Parse(person[1])));
            }

            string condition = Console.ReadLine();
            int ages = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (condition == "younger")
            {
                people = people.Where(x => younger(x, ages))
                    .ToList();
            }
            else if (condition == "older")
            {
                people = people.Where(x => older(x, ages))
                    .ToList();
            }

            foreach (var person in people)
            {
                List<string> output = new List<string>();

                if (format.Contains("name"))
                {
                    output.Add(person.name);
                }
                if (format.Contains("age"))
                {
                    output.Add(person.age.ToString());
                }

                Console.WriteLine(string.Join(" - ", output));
            }
        }
    }
}
