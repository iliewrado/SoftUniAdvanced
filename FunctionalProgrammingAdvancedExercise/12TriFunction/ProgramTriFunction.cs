using System;
using System.Collections.Generic;
using System.Linq;

namespace _12TriFunction
{
    class ProgramTriFunction
    {
        static void Main(string[] args)
        {
            Func<string, int> sum = chars =>
            {
                int sum = 0;
                foreach (var ch in chars)
                {
                    sum += ch;
                }
                return sum;
            };
            Func<string, int, bool> filter = (name, num) => sum(name) >= num;
            int number = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            foreach (var name in names.Where(name => filter(name, number)))
            {
                Console.WriteLine(name);
                break;
            }
        }
    }
}
