using System;
using System.Collections.Generic;
using System.Linq;

namespace _07TruckTour
{
    class ProgramTruckTour
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Queue<List<int>> fuelStations = new Queue<List<int>>();

            for (int i = 0; i < count; i++)
            {
                List<int> input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                fuelStations.Enqueue(new List<int>(input));
            }

            int index = 0;

            while (true)
            {
                int sum = 0;
                foreach (var item in fuelStations)
                {
                    sum += item[0] - item[1];
                    if (sum < 0)
                    {
                        index++;
                        fuelStations.Enqueue(fuelStations.Dequeue());
                        break;
                    }
                }
                if (sum >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}
