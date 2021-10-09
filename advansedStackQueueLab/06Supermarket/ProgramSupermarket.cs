using System;
using System.Collections.Generic;

namespace _06Supermarket
{
    class ProgramSupermarket
    {
        static void Main(string[] args)
        {
            string name = string.Empty;
            Queue<string> names = new Queue<string>();

            while ((name = Console.ReadLine()) != "End")
            {
                if (name != "Paid")
                {
                    names.Enqueue(name);
                }
                else
                {
                    while (names.Count > 0)
                    {
                        Console.WriteLine(names.Dequeue()); 
                    }
                }
            }
            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
