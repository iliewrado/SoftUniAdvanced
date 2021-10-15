using System;
using System.Linq;

namespace _04AddVAT
{
    class ProgramAddVAT
    {
        static void Main(string[] args)
        {
            Func<double, double> addVAT = d => d * 1.2;

            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(d => addVAT(d))
                .ToList()
                .ForEach(d => Console.WriteLine($"{d:f2}"));
        }
    }
}
