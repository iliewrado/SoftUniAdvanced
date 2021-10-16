using System;

namespace GenericBoxOfInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                Box<int> items = new Box<int>(int.Parse(input));
                Console.WriteLine(items.ToString());
            }
        }
    }
}
