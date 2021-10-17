using System;
using System.Collections.Generic;
using System.Linq;

namespace _01CountSameValuesInArray
{
    class ProgramCountSameValuesinArray
    {
        static void Main(string[] args)
        {
            double[] values = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> countsValues = new Dictionary<double, int>();

            for (int i = 0; i < values.Length; i++)
            {
                if (countsValues.ContainsKey(values[i]))
                {
                    countsValues[values[i]]++;
                }
                else
                {
                    countsValues.Add(values[i], 1);
                }
            }

            foreach (var number in countsValues)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
