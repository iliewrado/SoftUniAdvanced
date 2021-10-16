using System;
using System.Linq;

namespace _02Collection
{
    class ProgramCollection
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            ListyIterator<string> elements = null;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] items = input
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string command = items[0];
                    switch (command)
                    {
                        case "Create":
                            elements = new ListyIterator<string>(items.Skip(1).ToArray());
                            break;
                        case "HasNext":
                            Console.WriteLine(elements.HasNext());
                            break;
                        case "Move":
                            Console.WriteLine(elements.Move());
                            break;
                        case "Print":
                            elements.Print();
                            break;
                        case "PrintAll":
                            elements.PrintAll();
                            break;
                    }
                }
                catch (Exception exeption)
                {
                    Console.WriteLine(exeption.Message);
                }
            }
        }
    }
}
