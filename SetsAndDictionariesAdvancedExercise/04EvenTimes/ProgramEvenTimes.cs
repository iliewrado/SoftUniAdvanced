using System;
using System.Collections.Generic;
using System.Linq;

namespace _04EvenTimes
{
    class ProgramEvenTimes
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (numbers.ContainsKey(number))
                {
                    numbers[number]++;
                }
                else
                {
                    numbers.Add(number, 1);
                }
            }
            foreach (var num in numbers.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(num.Key);
            }
        }
    }
}
