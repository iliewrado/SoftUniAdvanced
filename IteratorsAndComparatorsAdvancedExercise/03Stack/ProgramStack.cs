using System;
using System.Linq;

namespace _03Stack
{
    class ProgramStack
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Stack<string> items = new Stack<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "Pop")
                {
                    items.Pop();
                }
                else
                {
                    string[] elements = input
                        .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 1; i < elements.Length; i++)
                    {
                        items.Push(elements[i]);
                    }
                }
            }
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

        }
    }
}
