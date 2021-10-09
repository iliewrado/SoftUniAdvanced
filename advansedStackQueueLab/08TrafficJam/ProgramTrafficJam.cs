using System;
using System.Collections.Generic;

namespace _08TrafficJam
{
    class ProgramTrafficJam
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string input = string.Empty;
            int passedCars = 0;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else
                {
                    if (count >= cars.Count)
                    {
                        count = cars.Count;
                    }
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        passedCars++;
                    }
                }
            }
            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
