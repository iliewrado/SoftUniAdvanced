using System;
using System.Collections.Generic;
using System.Linq;

namespace _01ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            ListyIterator<string> elements = null;
            while ((input = Console.ReadLine()) != "END")
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
                        try
                        {
                            elements.Print();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                            break;
                    }   
            }
        }
    }
}
