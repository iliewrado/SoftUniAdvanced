using System;
using System.Linq;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Threeuple<string, string, string> person =
                new Threeuple<string, string, string>()
                { Titem = input[0] + " " + input[1], Uitem = input[2], Vitem = input[3] };
            input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            bool isDrunk = (input[2] == "drunk") ? true : false;
            Threeuple<string, int, bool> beerPerson = new Threeuple<string, int, bool>()
            { Titem = input[0], Uitem = int.Parse(input[1]), Vitem = isDrunk };
            input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Threeuple<string, double, string> bancAccount = new Threeuple<string, double, string>()
            { Titem = input[0], Uitem = double.Parse(input[1]), Vitem = input[2] };

            Console.WriteLine(person.ToString());
            Console.WriteLine(beerPerson.ToString());
            Console.WriteLine(bancAccount.ToString());
        }
    }
}
