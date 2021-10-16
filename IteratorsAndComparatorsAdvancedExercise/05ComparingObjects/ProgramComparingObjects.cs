using System;
using System.Collections.Generic;

namespace _05ComparingObjects
{
    public class ProgramComparingObjects
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Person> people = new List<Person>();
            while ((input = Console.ReadLine()) != "END")
            {
                string[] info = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(info[0], int.Parse(info[1]), info[2]);
                people.Add(person);
            }
            int index = int.Parse(Console.ReadLine()) - 1;
            int equal = 0;
            int notEqual = 0;
            foreach (Person person in people)
            {
                if (people[index].CompareTo(person) == 0)
                {
                    equal++;
                }
                else
                {
                    notEqual++;
                }
            }
            if (equal <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {notEqual} {people.Count}");
            }
        }
    }
}
