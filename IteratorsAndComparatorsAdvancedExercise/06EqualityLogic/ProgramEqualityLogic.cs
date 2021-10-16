using System;
using System.Collections.Generic;

namespace _06EqualityLogic
{
    class ProgramEqualityLogic
    {
        static void Main(string[] args)
        {
            HashSet<Person> hashPeople = new HashSet<Person>();
            SortedSet<Person> sortedpeople = new SortedSet<Person>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person() { Name = input[0], Age = int.Parse(input[1]) };
                
                hashPeople.Add(person);
                sortedpeople.Add(person);
            }
            Console.WriteLine(hashPeople.Count);
            Console.WriteLine(sortedpeople.Count);
        }
    }
}
