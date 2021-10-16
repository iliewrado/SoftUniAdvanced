using System;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = ConsoleReadSplit();
            Tuple<string, string> person =
                new Tuple<string, string>(new string(input[0]+" "+input[1]), input[2]);
            input = ConsoleReadSplit();
            Tuple<string, int> beerPerson = new Tuple<string, int>(input[0], int.Parse(input[1]));
            input = ConsoleReadSplit();
            Tuple<int, double> numbers = new Tuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));

            Console.WriteLine(person.ToString());
            Console.WriteLine(beerPerson.ToString());
            Console.WriteLine(numbers.ToString());
        }

        private static string[] ConsoleReadSplit()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
